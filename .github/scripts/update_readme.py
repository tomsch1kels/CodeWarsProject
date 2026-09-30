import os
import re
import json
from google import genai

# Geheime API sleutel wordt door GitHub Actions meegegeven via GEMINI_API_KEY
client = genai.Client() if os.environ.get("GEMINI_API_KEY") else None

github_repo = os.environ.get("GITHUB_REPOSITORY", "tomsch1kels/CodeWarsProject")
SOLUTIONS_DIR = "./Solutions"
TESTS_DIR = "./Tests"

def analyze_complexity_with_gemini(code):
    """Vraagt Gemini AI om de Time en Space complexity te bepalen van de C# code."""
    if not client:
        return {"time": "O(?)", "space": "O(?)"}

    prompt = f"""
    Analyseer de volgende C# oplossing voor een Codewars kata op tijds- en ruimtecomplexiteit.

    ```csharp
    {code}
    ```

    Geef UITSLUITEND een geldig JSON object terug in het volgende formaat zonder extra tekst of markdown formatting:
    {{"time": "O(N)", "space": "O(1)"}}
    """

    try:
        response = client.models.generate_content(
            model="gemini-2.5-flash",
            contents=prompt,
        )
        
        # Schoon eventuele markdown codeblock tags af (```json ... ```)
        clean_json = re.sub(r"```(?:json)?\n?", "", response.text).strip().strip("```")
        data = json.loads(clean_json)
        return {
            "time": data.get("time", "-"),
            "space": data.get("space", "-")
        }
    except Exception as e:
        print(f"Gemini API fout: {e}")
        return {"time": "-", "space": "-"}

def parse_cs_file(file_path, file_name):
    """Leest het .cs-bestand voor URL en Kyu, en vraagt Gemini om de Big O."""
    url = None
    rank = "N/A"

    with open(file_path, "r", encoding="utf-8") as f:
        content = f.read()

        # 1. URL ophalen uit commentaar
        url_match = re.search(r"https?://www\.codewars\.com/kata/[a-zA-Z0-9_-]+", content)
        if url_match:
            url = url_match.group(0)

        # 2. Kyu rating ophalen uit commentaar
        rank_match = re.search(r"(\d)\s*kyu", content, re.IGNORECASE)
        if rank_match:
            rank = f"{rank_match.group(1)} kyu"

    # 3. Vraag Gemini AI om Big O analyse van de code
    complexity = analyze_complexity_with_gemini(content)

    clean_name = file_name.replace(".cs", "")
    clean_name = re.sub(r"^\d+\_?kyu\_?", "", clean_name, flags=re.IGNORECASE)
    display_name = re.sub(r"([a-z0-9])([A-Z])", r"\1 \2", clean_name)

    return {
        "raw_name": file_name.replace(".cs", ""),
        "name": display_name,
        "rank": rank,
        "path": file_path,
        "url": url,
        "time": f"`{complexity['time']}`" if complexity['time'] != "-" else "-",
        "space": f"`{complexity['space']}`" if complexity['space'] != "-" else "-"
    }

def count_tests_for_kata(search_dir, raw_name):
    """Zoekt in search_dir naar {raw_name}Tests.cs en telt [TestCase] / [Test] attributen."""
    test_count = 0
    test_file_pattern = f"{raw_name}Tests.cs".lower()

    for root, dirs, files in os.walk(search_dir):
        for file in files:
            if file.lower() == test_file_pattern:
                test_path = os.path.join(root, file)
                with open(test_path, "r", encoding="utf-8") as f:
                    content = f.read()

                    test_cases = re.findall(r"\[\s*TestCase\b", content)
                    standalone_tests = re.findall(r"\[\s*(Test|Fact|TestMethod)\b", content)

                    if test_cases:
                        test_count = len(test_cases)
                    else:
                        test_count = len(standalone_tests)
                break
    return test_count

def get_kata_info():
    kata_list = []
    if not os.path.exists(SOLUTIONS_DIR):
        return kata_list

    search_tests_dir = TESTS_DIR if os.path.exists(TESTS_DIR) else "."

    for root, dirs, files in os.walk(SOLUTIONS_DIR):
        for file in files:
            if file.endswith(".cs") and not file.endswith("Tests.cs"):
                file_path = os.path.join(root, file).replace("\\", "/")
                kata_data = parse_cs_file(file_path, file)
                kata_data["tests_count"] = count_tests_for_kata(search_tests_dir, kata_data["raw_name"])
                kata_list.append(kata_data)

    return sorted(kata_list, key=lambda x: x["rank"])

def generate_readme():
    katas = get_kata_info()
    total_tests = sum(k["tests_count"] for k in katas)
    
    readme_content = f"""# 🥋 Codewars C# Solutions

[![.NET CI](https://github.com/{github_repo}/actions/workflows/dotnet.yml/badge.svg)](https://github.com/{github_repo}/actions/workflows/dotnet.yml)

Automatisch gegenereerd overzicht van opgeloste Codewars kata's met AI-gegenereerde Big O complexiteitsanalyse.

## 📊 Opgeloste Kata's

| Totaal Opgelost | Totaal Tests |
| :---: | :---: |
| **{len(katas)}** | **{total_tests}** |

| Rank / Kyu | Kata Probleem | Time | Space | Tests | Bronbestand |
| :--- | :--- | :---: | :---: | :---: | :--- |
"""
    
    for kata in katas:
        kata_link = f"[{kata['name']}]({kata['url']})" if kata['url'] else kata['name']
        test_badge = f"`{kata['tests_count']}`" if kata['tests_count'] > 0 else "-"

        readme_content += f"| `{kata['rank']}` | **{kata_link}** | {kata['time']} | {kata['space']} | {test_badge} | [Bekijk Code]({kata['path']}) |\n"

    with open("README.md", "w", encoding="utf-8") as f:
        f.write(readme_content)

if __name__ == "__main__":
    generate_readme()