import os
import re

github_repo = os.environ.get("GITHUB_REPOSITORY", "tomsch1kels/CodeWarsProject")
SOLUTIONS_DIR = "./Solutions"  # Pas aan naar jouw oplossingenmap

def parse_cs_file(file_path, file_name):
    """Leest het .cs-bestand en haalt de URL, Kyu en schone naam op."""
    url = None
    rank = "N/A"

    with open(file_path, "r", encoding="utf-8") as f:
        content = f.read()

        # 1. Zoek naar Codewars URL
        url_match = re.search(r"https?://www\.codewars\.com/kata/[a-zA-Z0-9_-]+", content)
        if url_match:
            url = url_match.group(0)

        # 2. Zoek naar Kyu rating
        rank_match = re.search(r"(\d)\s*kyu", content, re.IGNORECASE)
        if rank_match:
            rank = f"{rank_match.group(1)} kyu"

    clean_name = file_name.replace(".cs", "")
    clean_name = re.sub(r"^\d+\_?kyu\_?", "", clean_name, flags=re.IGNORECASE)
    display_name = re.sub(r"([a-z0-9])([A-Z])", r"\1 \2", clean_name)

    return {
        "raw_name": file_name.replace(".cs", ""),
        "name": display_name,
        "rank": rank,
        "path": file_path,
        "url": url
    }

def count_tests_for_kata(root_dir, raw_name):
    """Zoekt het bijbehorende *Tests.cs bestand en telt het aantal tests ([Test], [TestCase], etc.)."""
    test_count = 0
    test_file_pattern = f"{raw_name}Tests.cs"

    for root, dirs, files in os.walk(root_dir):
        for file in files:
            if file.lower() == test_file_pattern.lower():
                test_path = os.path.join(root, file)
                with open(test_path, "r", encoding="utf-8") as f:
                    content = f.read()
                    
                    # Telt het aantal [Test], [Fact], [TestMethod] en [TestCase(...)] attributen
                    test_attributes = re.findall(r"\[\s*(Test\vert{}Fact\vert{}TestMethod\vert{}TestCase\(.*?\))\s*\]", content)
                    test_count = len(test_attributes)
                break
    return test_count

def get_kata_info():
    kata_list = []
    if not os.path.exists(SOLUTIONS_DIR):
        return kata_list

    for root, dirs, files in os.walk(SOLUTIONS_DIR):
        for file in files:
            if file.endswith(".cs") and not file.endswith("Tests.cs"):
                file_path = os.path.join(root, file).replace("\\", "/")
                kata_data = parse_cs_file(file_path, file)
                
                # Tel het aantal tests voor dit specifieke probleem
                kata_data["tests_count"] = count_tests_for_kata(SOLUTIONS_DIR, kata_data["raw_name"])
                
                kata_list.append(kata_data)

    return sorted(kata_list, key=lambda x: x["rank"])

def generate_readme():
    katas = get_kata_info()
    
    total_tests = sum(k["tests_count"] for k in katas)
    
    readme_content = f"""# 🥋 Codewars C# Solutions

[![.NET CI](https://github.com/{github_repo}/actions/workflows/dotnet.yml/badge.svg)](https://github.com/{github_repo}/actions/workflows/dotnet.yml)

Automatisch gegenereerd overzicht van opgeloste Codewars kata's.

## 📊 Opgeloste Kata's

| Totaal Opgelost | Totaal Tests |
| :---: | :---: |
| **{len(katas)}** | **{total_tests}** |

| Rank / Kyu | Kata Probleem | Tests | Bronbestand |
| :--- | :--- | :---: | :--- |
"""
    
    for kata in katas:
        kata_link = f"[{kata['name']}]({kata['url']})" if kata['url'] else kata['name']
        test_badge = f"`{kata['tests_count']}`" if kata['tests_count'] > 0 else "-"

        readme_content += f"| `{kata['rank']}` | **{kata_link}** | {test_badge} | [Bekijk Code]({kata['path']}) |\n"

    with open("README.md", "w", encoding="utf-8") as f:
        f.write(readme_content)

if __name__ == "__main__":
    generate_readme()