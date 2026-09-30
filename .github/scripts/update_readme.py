import os
import re

# Map waar je kata-oplossingen staan
SOLUTIONS_DIR = "./Solutions"  # Pas aan naar jouw mapnaam

def get_kata_info():
    kata_list = []
    
    if not os.path.exists(SOLUTIONS_DIR):
        return kata_list

    for root, dirs, files in os.walk(SOLUTIONS_DIR):
        for file in files:
            if file.endswith(".cs") and not file.endswith("Tests.cs"):
                file_path = os.path.join(root, file).replace("\\", "/")
                
                # Probeer Kyu/Rank uit de mapnaam of bestandsnaam te halen (bijv. "6kyu_TwoSum.cs")
                match = re.search(r"(\d)kyu", file, re.IGNORECASE)
                rank = f"{match.group(1)} kyu" if match else "N/A"
                
                # Schoon de naam op voor weergave
                clean_name = file.replace(".cs", "").replace("_", " ")
                
                kata_list.append({
                    "name": clean_name,
                    "rank": rank,
                    "path": file_path
                })
    return sorted(kata_list, key=lambda x: x["rank"])

def generate_readme():
    katas = get_kata_info()
    
    # Render de status badge bovenaan
    readme_content = """# 🥋 Codewars C# Solutions

![Build Status](https://github.com/${{ github.repository }}/actions/workflows/dotnet.yml/badge.svg)

Automatisch gegenereerd overzicht van opgeloste Codewars kata's.

## 📊 Opgeloste Kata's

| Totaal Opgelost |
| :---: |
| **""" + str(len(katas)) + """** |

| Rank / Kyu | Kata Oplossing | Bronbestand |
| :--- | :--- | :--- |
"""
    
    for kata in katas:
        readme_content += f"| `{kata['rank']}` | **{kata['name']}** | [Bekijk Code]({kata['path']}) |\n"

    with open("README.md", "w", encoding="utf-8") as f:
        f.write(readme_content)

if __name__ == "__main__":
    generate_readme()