# 🧠 Complexiteitsanalyse: FirstNonRepeatingLetter

*Bronbestand: [FirstNonRepeatingLetter.cs](../Solutions/FirstNonRepeatingLetter.cs)*

---

1. **Complexiteit**: 
   - Tijd: $\mathcal{O}(n^2)$ in het slechtste geval, vanwege het herhaaldelijk doorzoeken van substrings met `Contains` voor elk karakter.
   - Ruimte: $\mathcal{O}(n)$ vanwege het alloceren van substrings (met `s[..i]` en `s[(i + 1)..]`) en string-transformaties.

2. **Efficiëntst?**: 
   Nee.

3. **Optimalisatiemogelijkheid**: 
   De tijdscomplexiteit kan worden verbeterd naar $\mathcal{O}(n)$ door een frequentietabel (bijv. een `Dictionary<char, int>` of een array voor ASCII/Unicode) te gebruiken. Eerst tel je de frequentie van alle hoofdletterongevoelige karakters in één pass ($\mathcal{O}(n)$). In een tweede pass door de originele string retourneer je het eerste karakter waarvan de frequentie (gebaseerd op de lowercase/uppercase equivalenten) gelijk is aan 1. Dit voorkomt dure substring-operaties en herhalende zoekopdrachten.