import os
import re

github_repo = os.environ.get("GITHUB_REPOSITORY", "tomsch1kels/CodeWarsProject")

SOLUTIONS_DIR = "./Solutions"
TESTS_DIR = "./Tests"
ANALYSIS_DIR = "./Complexity Analyses"

def check_time_efficiency(analysis_path):
    """
    Zoekt robuust naar het kopje 'Efficientst?' en kijkt of het antwoord met Ja of Nee begint.
    """
    if not os.path.exists(analysis_path):
        return "-"
    
    try:
        with open(analysis_path, "r", encoding="utf-8") as f:
            content = f.read()

        # Zoek naar het gedeelte ná 'Efficientst?' (negeert markdown opmaak zoals **, ###, etc.)
        match = re.search(r"Efficientst\?\*?\*?\s*[:\n]*\s*(Ja|Nee)\b", content, re.IGNORECASE)
        
        if match:
            answer = match.group(1).capitalize()
            return "✅" if answer == "Ja" else "❌"
            
        # Fallback: Zoek simpelweg of 'Efficientst' ergens wordt gevolgd door 'Ja' binnen 30 tekens
        fallback_match = re.search(r"Efficientst.*?\b(Ja|Nee)\b", content, re.IGNORECASE | re.DOTALL)
        if fallback_match:
            answer = fallback_match.group(1).capitalize()
            return "✅" if answer == "Ja" else "❌"

    except Exception as e:
        print(f"[FOUT] Kon {analysis_path} niet lezen: {e}")

    return "-"
def parse_cs_file(file_path, file_name):
    """Leest het .cs-bestand voor URL, Kyu en schone naam."""
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

    raw_name = file_name.replace(".cs", "")
    clean_name = re.sub(r"^\d+\_?kyu\_?", "", raw_name, flags=re.IGNORECASE)
    display_name = re.sub(r"([a-z0-9])([A-Z])", r"\1 \2", clean_name)

    # 3. Controleer analysebestand en tijdsefficiëntie
    analysis_file = f"{raw_name}.md"
    full_analysis_path = os.path.join(ANALYSIS_DIR, analysis_file)
    
    if os.path.exists(full_analysis_path):
        encoded_path = f"Complexity%20Analyses/{analysis_file}"
        analysis_link = f"[📊 Bekijk Analyse]({encoded_path})"
        efficient_badge = check_time_efficiency(full_analysis_path)
    else:
        analysis_link = "-"
        efficient_badge = "-"

    return {
        "raw_name": raw_name,
        "name": display_name,
        "rank": rank,
        "path": file_path,
        "url": url,
        "analysis_link": analysis_link,
        "efficient": efficient_badge
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

Automatisch gegenereerd overzicht van opgeloste Codewars kata's met geïntegreerde complexiteitsanalyses.

## 📊 Opgeloste Kata's

| Totaal Opgelost | Totaal Tests |
| :---: | :---: |
| **{len(katas)}** | **{total_tests}** |

| Rank / Kyu | Kata Probleem | Tests | Efficiënt | Analyse | Bronbestand |
| :--- | :--- | :---: | :---: | :---: | :--- |
"""
    
    for kata in katas:
        kata_link = f"[{kata['name']}]({kata['url']})" if kata['url'] else kata['name']
        test_badge = f"`{kata['tests_count']}`" if kata['tests_count'] > 0 else "-"

        readme_content += f"| `{kata['rank']}` | **{kata_link}** | {test_badge} | {kata['efficient']} | {kata['analysis_link']} | [Bekijk Code]({kata['path']}) |\n"

    with open("README.md", "w", encoding="utf-8") as f:
        f.write(readme_content)

if __name__ == "__main__":
    generate_readme()