# 🧠 Complexiteitsanalyse: FirstNonRepeatingLetter

*Bronbestand: [FirstNonRepeatingLetter.cs](../Solutions/FirstNonRepeatingLetter.cs)*

---

1. **Complexiteit**: 
   - Tijd: $\mathcal{O}(N^2)$ in het slechtste geval (vanwege het herhaaldelijk doorzoeken van substrings met `Contains` voor zowel de onder- als hoofdlettervariant).
   - Ruimte: $\mathcal{O}(N)$ in het slechtste geval (vanwege het alloceren van geheugen voor sub-strings zoals `s[..i]` en `s[(i + 1)..]` en de lowercase/uppercase conversies).

2. **Efficiëntst?**: 
   - Nee.

3. **Optimalisatiemogelijkheid**: 
   - De oplossing kan worden versneld naar een $\mathcal{O}(N)$ tijdscomplexiteit en $\mathcal{O}(N)$ ruimtecomplexiteit door een frequentietabel (bijv. een `Dictionary<char, int>`) te gebruiken. 
   - Door eerst in één loop alle karakters (case-insensitive, door ze bijvoorbeeld te normaliseren) te tellen, en in een tweede loop het originele woord te doorlopen om het eerste karakter te vinden met een frequentie van 1, vermijd je het nested doorzoeken van substrings.