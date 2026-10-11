import os
import re
import sys
import time
from google import genai

# Initialiseer de Gemini client met de API key uit de environment
client = genai.Client() if os.environ.get("GEMINI_API_KEY") else None

SOLUTIONS_DIR = "./Solutions"
ANALYSIS_DIR = "./Complexity Analyses"
MODEL_NAME = "gemini-3.5-flash-lite"
MAX_RETRIES = 3
RETRY_DELAY = 180  # 3 minuten backoff bij 503/429 rate-limits


def analyze_code_with_gemini(code, filename):
    """Vraagt Gemini 3.5 Flash Lite om een uitgebreide Markdown complexiteitsanalyse met retry logica."""
    if not client:
        print("⚠️ DEBUG: Geen GEMINI_API_KEY gevonden in de omgevingsvariabelen.")
        return None

    prompt = f"""
    Je bent een expert C# software architect en algoritme-analist.
    Analyseer de onderstaande C# oplossing voor een Codewars kata ({filename}).

    ```csharp
    {code}
    ```

    Schrijf een heel korte Markdown analyse met de volgende onderdelen (in het Nederlands):
    1. **Complexiteit**: Exacte Big O-notatie voor tijd en ruimte.
    2. **Efficiëntst?**: Geef met ja/nee aan of de implementatie de optimale Big O tijdscomplexiteit heeft die mogelijk is.
    Beschrijf als huidige oplossing efficienter kan en hoe. : 3. **Optimalisatiemogelijkheid**: Beschrijf hoe de huidige oplossing efficienter kan. 
    Geef UITSLUITEND de Markdown inhoud terug zonder extra omhullende tekst.
    """

    for attempt in range(1, MAX_RETRIES + 1):
        try:
            print(f"🔄 Analyse aanvragen voor '{filename}' via {MODEL_NAME} (poging {attempt}/{MAX_RETRIES})...")
            
            response = client.models.generate_content(
                model=MODEL_NAME,
                contents=prompt,
            )
            
            print(f"✅ Succesvolle analyse ontvangen voor '{filename}'!")
            return response.text

        except Exception as e:
            error_msg = str(e)
            print(f"⚠️ Fout bij analyse van '{filename}' (poging {attempt}/{MAX_RETRIES}): {error_msg}")
            
            if attempt < MAX_RETRIES:
                print(f"⏳ Wachten op retry... Volgende poging over 3 minuten ({RETRY_DELAY} sec)...")
                time.sleep(RETRY_DELAY)
            else:
                print(f"❌ Alle {MAX_RETRIES} pogingen voor '{filename}' zijn mislukt.")

    return None


def main():
    # Haal de lijst van gewijzigde bestanden uit de omgevingsvariabele
    changed_files_raw = os.environ.get("CHANGED_FILES", "")
    
    if not changed_files_raw:
        print("⚠️ Geen CHANGED_FILES omgevingsvariabele gevonden. Scan alle bestanden (fallback).")
        changed_file_list = []
    else:
        # Parse newline-gescheiden lijst van bestanden
        changed_file_list = [f.strip() for f in changed_files_raw.split('\n') if f.strip()]
    
    print(f"📋 Gewijzigde bestanden om te verwerken: {len(changed_file_list)}")
    
    if not os.path.exists(SOLUTIONS_DIR):
        print(f"Map '{SOLUTIONS_DIR}' niet gevonden. Niets om te verwerken.")
        return

    # Zorg dat de uitvoermap bestaat
    os.makedirs(ANALYSIS_DIR, exist_ok=True)

    files_processed = 0
    files_skipped = 0
    
    # Scan alle C# bestanden in de Solutions map (inclusief submappen)
    for root, dirs, files in os.walk(SOLUTIONS_DIR):
        for file in files:
            # Negeer niet-C# bestanden en unit test bestanden
            if not file.endswith(".cs") or file.endswith("Tests.cs"):
                continue

            file_path = os.path.join(root, file)
            relative_path = os.path.relpath(file_path, start=".").replace("\\", "/")
            
            # Als er een specifieke lijst is, sla over als bestand niet daarin staat
            if changed_file_list and relative_path not in changed_file_list:
                print(f"⏭️ Overslaan: {file_path} (niet gewijzigd)")
                files_skipped += 1
                continue

            base_name = file.replace(".cs", "")
            report_path = os.path.join(ANALYSIS_DIR, f"{base_name}.md")

            print(f"\n🔍 Verwerken van gewijzigd bestand: {file_path}")

            with open(file_path, "r", encoding="utf-8") as f:
                code = f.read()

            report_markdown = analyze_code_with_gemini(code, file)

            if report_markdown:
                # Format een mooie header met relatieve link naar het C# bronbestand
                relative_cs_path = os.path.relpath(file_path, start=".").replace("\\", "/")
                
                final_content = f"# 🧠 Complexiteitsanalyse: {base_name}\n\n"
                final_content += f"*Bronbestand: [{file}](../{relative_cs_path})*\n\n---\n\n"
                final_content += report_markdown

                with open(report_path, "w", encoding="utf-8") as f:
                    f.write(final_content)

                print(f"✅ Rapport succesvol opgeslagen in: {report_path}")
                files_processed += 1
            else:
                print(f"❌ Analyse mislukt voor: {file_path}")

    print(f"\n📊 Samenvatting: {files_processed} verwerkt, {files_skipped} overgeslagen")


if __name__ == "__main__":
    main()