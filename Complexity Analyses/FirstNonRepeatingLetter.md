# 🧠 Complexiteitsanalyse: FirstNonRepeatingLetter

*Bronbestand: [FirstNonRepeatingLetter.cs](../Solutions/FirstNonRepeatingLetter.cs)*

---

1. **Complexiteit**: 
   - **Tijd**: $\mathcal{O}(N^2)$ in het slechtste geval, omdat voor elk karakter in de string substrings worden gekopieerd en doorzocht (`s[..i]` en `s[(i + 1)..]`).
   - **Ruimte**: $\mathcal{O}(N)$ vanwege het alloceren van substrings en lower/upper case conversies.

2. **Efficiëntst?**: 
   - **Nee**. De optimale tijdscomplexiteit voor dit probleem is $\mathcal{O}(N)$.

3. **Optimalisatiemogelijkheid**: 
   - De huidige oplossing kan efficiënter door een frequentietabel (bijv. een `Dictionary<char, int>` of een array voor ASCII/Unicode) te gebruiken. Door in **één enkele pass** ($\mathcal{O}(N)$) alle karakters te tellen (waarbij je hoofdletterongevoeligheid normaliseert), en vervolgens in een tweede korte pass het eerste karakter met frequentie 1 terug te vinden, reduceer je de tijd tot lineaire complexiteit $\mathcal{O}(N)$ en minimaliseer je geheugenallocaties.