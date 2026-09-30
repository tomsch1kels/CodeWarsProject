import os
import re

github_repo = os.environ.get("GITHUB_REPOSITORY", "tomsch1kels/CodeWarsProject")
SOLUTIONS_DIR = "./Solutions"  # Pas aan naar jouw mapnaam

def get_kata_info():
    kata_list = []
    if not os.path.exists(SOLUTIONS_DIR):
        return kata_list

    for root, dirs, files in os.walk(SOLUTIONS_DIR):
        for file in files:
            if file.endswith(".cs") and not file.endswith("Tests.cs"):
                file_path = os.path.join(root, file).replace("\\", "/")
                
                # Lees de inhoud van het C# bestand om de URL te zoeken
                codewars_url = None
                with open(file_path, "r", encoding="utf-8") as f:
                    content = f.read()
                    # Zoekt naar patronen zoals https://www.codewars.com/kata/...
                    url_match = re.search(r"https?://www\.codewars\.com/kata/[a-zA-Z0-9_-]+", content)
                    if url_match:
                        codewars_url = url_match.group(0)

                # Kyu/Rank bepalen uit de bestandsnaam (bijv. "6kyu_TwoSum.cs")
                rank_match = re.search(r"(\d)kyu", file, re.IGNORECASE)
                rank = f"{rank_match.group(1)} kyu" if rank_match else "N/A"
                
                clean_name = file.replace(".cs", "").replace("_", " ")
                # Strip de kyu uit de naam voor een schone titel
                clean_name = re.sub(r"^\d+kyu\s*", "", clean_name, flags=re.IGNORECASE)

                kata_list.append({
                    "name": clean_name,
                    "rank": rank,
                    "path": file_path,
                    "url": codewars_url
                })
                
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
        # Als er een URL gevonden is, maken we een link van de naam. Anders tonen we alleen de tekst.
        if kata['url']:
            kata_link = f"[{kata['name']}]({kata['url']})"
        else:
            kata_link = kata['name']

        readme_content += f"| `{kata['rank']}` | **{kata_link}** | [Bekijk Code]({kata['path']}) |\n"

    with open("README.md", "w", encoding="utf-8") as f:
        f.write(readme_content)

if __name__ == "__main__":
    generate_readme()