import os
import re

github_repo = os.environ.get("GITHUB_REPOSITORY", "tomsch1kels/CodeWarsProject")

# Mapinstellingen
SOLUTIONS_DIR = "./Solutions"  # Map waarin je oplossingen staan
TESTS_DIR = "./Tests"          # Map waarin je tests staan (of gebruik "." voor de hele repo)

def parse_cs_file(file_path, file_name):
    """Leest het oplossingsbestand voor URL, Kyu en schone naam."""
    url = None
    rank = "N/A"

    with open(file_path, "r", encoding="utf-8") as f:
        content = f.read()

        # 1. URL ophalen
        url_match = re.search(r"https?://www\.codewars\.com/kata/[a-zA-Z0-9_-]+", content)
        if url_match:
            url = url_match.group(0)

        # 2. Kyu rating ophalen
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

def count_tests_for_kata(search_dir, raw_name):
    """Zoekt in search_dir naar {raw_name}Tests.cs en telt [TestCase] / [Test] attributen."""
    test_count = 0
    test_file_pattern = f"{raw_name}Tests.cs".lower()

    # Zoek door de opgegeven testmap (en submappen)
    for root, dirs, files in os.walk(search_dir):
        for file in files:
            if file.lower() == test_file_pattern:
                test_path = os.path.join(root, file)
                with open(test_path, "r", encoding="utf-8") as f:
                    content = f.read()

                    # 1. Tel het aantal [TestCase(...)] attributen
                    test_cases = re.findall(r"\[\s*TestCase\b", content)
                    
                    # 2. Tel het aantal reguliere [Test], [Fact] of [TestMethod] attributen
                    standalone_tests = re.findall(r"\[\s*(Test|Fact|TestMethod)\b", content)

                    if test_cases:
                        # Als er [TestCase] attributen zijn, is elke TestCase een unieke test
                        test_count = len(test_cases)
                    else:
                        # Anders tellen we het aantal normale [Test] methoden
                        test_count = len(standalone_tests)
                break
    return test_count

def get_kata_info():
    kata_list = []
    if not os.path.exists(SOLUTIONS_DIR):
        return kata_list

    # Bepaal waar we naar testbestanden zoeken (TESTS_DIR als die bestaat, anders hele repo ".")
    search_tests_dir = TESTS_DIR if os.path.exists(TESTS_DIR) else "."

    for root, dirs, files in os.walk(SOLUTIONS_DIR):
        for file in files:
            if file.endswith(".cs") and not file.endswith("Tests.cs"):
                file_path = os.path.join(root, file).replace("\\", "/")
                kata_data = parse_cs_file(file_path, file)
                
                # Zoek de tests op in de testmap
                kata_data["tests_count"] = count_tests_for_kata(search_tests_dir, kata_data["raw_name"])
                
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