# 🧠 Complexiteitsanalyse: FirstNonRepeatingLetter

*Bronbestand: [FirstNonRepeatingLetter.cs](../Solutions/FirstNonRepeatingLetter.cs)*

---

1. **Complexiteit**
   * **Tijdcomplexiteit:** $\mathcal{O}(n^2)$ in het slechtste geval, omdat voor elk karakter de `[..i]` en `[(i + 1)..]` subarrays worden gekopieerd en doorzocht.
   * **Ruimtecomplexiteit:** $\mathcal{O}(n)$ vanwege het alloceren van substrings bij het slicen.

2. **Efficiëntst?**
   * **Nee**, de optimale tijdscomplexiteit is $\mathcal{O}(n)$.

3. **Optimalisatiemogelijkheid**
   De huidige oplossing kan efficiënter door een frequentietabel (bijv. een `Dictionary<char, int>` of een vaste array voor ASCII/Unicode) te gebruiken. Door de string eerst eenmalig te doorlopen en de hoofdlettergevoelige of -ongevoelige voorkomens van elk karakter te tellen in $\mathcal{O}(n)$ tijd, kun je in een tweede $\mathcal{O}(n)$ pass direct het eerste karakter vinden met telling 1. Dit brengt de totale tijd terug naar $\mathcal{O}(n)$ en elimineert onnodige string-allocaties.