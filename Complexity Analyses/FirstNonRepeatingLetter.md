# 🧠 Complexiteitsanalyse: FirstNonRepeatingLetter

*Bronbestand: [FirstNonRepeatingLetter.cs](../Solutions/FirstNonRepeatingLetter.cs)*

---

1. **Complexiteit**: 
   - Tijd: $\mathcal{O}(n^2)$ in het slechtste geval, vanwege herhaalde substring-allocaties en doorzoekingen via `Contains` binnen de nested lussen en helpers.
   - Ruimte: $\mathcal{O}(n)$ vanwege de string slicing (`s[..i]` en `s[(i + 1)..]`) en het genereren van lowercase/uppercase varianten.

2. **Efficiëntst?**: 
   - Nee.

3. **Optimalisatiemogelijkheid**: 
   - De tijdscomplexiteit kan worden teruggebracht naar $\mathcal{O}(n)$ door een frequentietabel (bijv. een `Dictionary<char, int>`) te gebruiken. Door de string eerst eenmalig te doorlopen en de hoofdlettergevoelige frequenties van elk karakter op te slaan (rekening houdend met case-insensitive matching), kan in een tweede, korte iteratie direct het eerste karakter met frequentie 1 worden geretourneerd zonder overbodige substrings of nested lussen.