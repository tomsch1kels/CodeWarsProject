# 🧠 Complexiteitsanalyse: FirstNonRepeatingLetter

*Bronbestand: [FirstNonRepeatingLetter.cs](../Solutions/FirstNonRepeatingLetter.cs)*

---

### 1. Complexiteit
* **Tijdcomplexiteit:** $\mathcal{O}(n^2)$ in het slechtste geval, omdat voor elk karakter de subgrids (begin en rest van de string) worden doorzocht via `Contains()`.
* **Ruimtecomplexiteit:** $\mathcal{O}(n)$ vanwege het alloceren van substrings (`s[..i]` en `s[(i + 1)..]`) en de conversies naar hoofd- en kleine letters.

### 2. Efficiëntst?
Nee.

### 3. Optimalisatiemogelijkheid
De huidige oplossing kan aanzienlijk efficiënter door gebruik te maken van een frequentietabel (bijv. een `Dictionary<char, int>` of een vaste array voor ASCII/Unicode). Door de string eerst eenmalig te doorlopen en de hoofdletterongevoelige frequenties van alle karakters te tellen in $\mathcal{O}(n)$ tijd en $\mathcal{O}(n)$ ruimte, kan in een tweede iteratie van $\mathcal{O}(n)$ het eerste karakter worden gevonden waarvan de frequentie `1` is. Dit brengt de totale tijdscomplexiteit terug naar $\mathcal{O}(n)$.