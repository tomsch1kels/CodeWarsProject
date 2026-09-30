import os
import re

# Haal de repo op uit de omgevingsvariabelen (bijv. "tomsch1kels/CodeWarsProject")
github_repo = os.environ.get("GITHUB_REPOSITORY", "tomsch1kels/CodeWarsProject")
SOLUTIONS_DIR = "./Solutions"  # Pas dit aan naar de map waarin je C# bestanden staan

def parse_cs_file(file_path, file_name):
    """Leest het .cs-bestand en haalt de URL, Kyu en schone naam op."""
    url = None
    rank = "N/A"

    with open(file_path, "r", encoding="utf-8") as f:
        content = f.read()

        # 1. Zoek naar Codewars URL (bijv. // https://www.codewars.com/kata/...)
        url_match = re.search(r"https?://www\.codewars\.com/kata/[a-zA-Z0-9_-]+", content)
        if url_match:
            url = url_match.group(0)

        # 2. Zoek naar Kyu rating (bijv. // 6 kyu of // 6kyu)
        rank_match = re.search(r"(\d)\s*kyu", content, re.IGNORECASE)
        if rank_match:
            rank = f"{rank_match.group(1)} kyu"

    # 3. Schone naam maken van het bestand (bijv. "CreatePhoneNumber.cs" -> "Create Phone Number")
    clean_name = file_name.replace(".cs", "")
    # Haal eventuele "6kyu_" of "6_kyu_" prefixen uit de bestandsnaam als die er nog staan
    clean_name = re.sub(r"^\d+\_?kyu\_?", "", clean_name, flags=re.IGNORECASE)
    # Voeg spaties toe bij PascalCase (bijv. "CreatePhoneNumber" -> "Create Phone Number")
    display_name = re.sub(r"([a-z0-9])([A-Z])", r"\1 \2", clean_name)

    return {
        "name": display_name,
        "rank": rank,
        "path": file_path,
        "url": url
    }

def get_kata_info():
    kata_list = []
    if not os.path.exists(SOLUTIONS_DIR):
        return kata_list

    for root, dirs, files in os.walk(SOLUTIONS_DIR):
        for file in files:
            # Sla testbestanden en temporary buildbestanden over
            if file.endswith(".cs") and not file.endswith("Tests.cs"):
                file_path = os.path.join(root, file).replace("\\", "/")
                kata_data = parse_cs_file(file_path, file)
                kata_list.append(kata_data)

    # Sorteer op kyu-rank (bijv. 1 kyu bovenaan, of pas de sorteervolgorde aan)
    return sorted(kata_list, key=lambda x: x["rank"])

def generate_readme():
    katas = get_kata_info()
    
    readme_content = f"""# 🥋 Codewars C# Solutions

[![.NET CI](https://github.com/{github_repo}/actions/workflows/dotnet.yml/badge.svg)](https://github.com/{github_repo}/actions/workflows/dotnet.yml)

Automatisch gegenereerd overzicht van opgeloste Codewars kata's.

## 📊 Opgeloste Kata's

| Totaal Opgelost |
| :---: |
| **{len(katas)}** |

| Rank / Kyu | Kata Probleem | Bronbestand |
| :--- | :--- | :--- |
"""
    
    for kata in katas:
        # Als er een URL is gevonden, maken we de naam klikbaar. Anders tonen we alleen de naam.
        if kata['url']:
            kata_link = f"[{kata['name']}]({kata['url']})"
        else:
            kata_link = kata['name']

        readme_content += f"| `{kata['rank']}` | **{kata_link}** | [Bekijk Code]({kata['path']}) |\n"

    with open("README.md", "w", encoding="utf-8") as f:
        f.write(readme_content)

if __name__ == "__main__":
    generate_readme()