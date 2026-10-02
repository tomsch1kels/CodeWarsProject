import os
import re
import time
from google import genai

client = genai.Client() if os.environ.get("GEMINI_API_KEY") else None

ANALYSIS_DIR = "./Complexity Analyses"
MODEL_NAME = "gemini-3.5-flash-lite"
MAX_RETRIES = 3
RETRY_DELAY = 180  # 3 minuten backoff bij 503/429 rate-limits

def analyze_code_with_gemini(code, filename):
    """Vraagt Gemini 3.5 Flash Lite om een uitgebreide Markdown complexiteitsanalyse."""
    if not client:
        print("⚠️ DEBUG: Geen GEMINI_API_KEY gevonden.")
        return None

    prompt = f"""
    Je bent een expert C# software architect en algoritme-analist.
    Analyseer de onderstaande C# oplossing voor een Codewars kata ({filename}).

    ```csharp
    {code}
    ```

    Schrijf een gestructureerde Markdown analyse met de volgende onderdelen (in het Nederlands):
    1. **Overzicht & Samenvatting**: Korte uitleg van de gekozen aanpak.
    2. **Tijdscomplexiteit (Time Complexity)**: Exacte Big Onotatie met onderbouwing.
    3. **Ruimtecomplexiteit (Space Complexity)**: Exacte Big O notatie met onderbouwing.
    4. **Optimalisatie & Code Quality**: Zijn er knelpunten, geheugenlekken of leesbaarheidstips?

    Geef direct de Markdown inhoud terug zonder extra omhullende tekst.
    """

    for attempt in range(1, MAX_RETRIES + 1):
        try:
            print(f"🔄 Analyse aanvragen voor {filename} via {MODEL_NAME} (poging {attempt}/{MAX_RETRIES})...")
            response = client.models.generate_content(
                model=MODEL_NAME,
                contents=prompt,
            )
            return response.text
        except Exception as e:
            print(f"⚠️ Fout bij analyse van {filename}: {e}")
            if attempt < MAX_RETRIES:
                print(f"⏳ Wachten op retry over 3 minuten ({RETRY_DELAY} sec)...")
                time.sleep(RETRY_DELAY)

    return None

def main():
    changed_files_str = os.environ.get("CHANGED_FILES", "")
    if not changed_files_str:
        print("Geen gewijzigde C# bestanden om te analyseren.")
        return

    os.makedirs(ANALYSIS_DIR, exist_ok=True)
    changed_files = changed_files_str.split(" ")

    for file_path in changed_files:
        # Sla eventuele testbestanden of bestanden buiten Solutions over
        if not file_path.endswith(".cs") or file_path.endswith("Tests.cs") or not file_path.startswith("Solutions/"):
            continue

        file_name = os.path.basename(file_path)
        base_name = file_name.replace(".cs", "")

        print(f"\n🔍 Verwerken van gewijzigd bestand: {file_path}")

        with open(file_path, "r", encoding="utf-8") as f:
            code = f.read()

        report_markdown = analyze_code_with_gemini(code, file_name)

        if report_markdown:
            report_path = os.path.join(ANALYSIS_DIR, f"{base_name}.md")
            
            # Voeg een nette titel en link bovenaan de gegenereerde analyse toe
            final_content = f"# 🧠 Complexiteitsanalyse: {base_name}\n\n"
            final_content += f"*Bronbestand: [{file_name}](../{file_path})*\n\n---\n\n"
            final_content += report_markdown

            with open(report_path, "w", encoding="utf-8") as f:
                f.write(final_content)

            print(f"✅ Analyse succesvol opgeslagen in: {report_path}")

if __name__ == "__main__":
    main()