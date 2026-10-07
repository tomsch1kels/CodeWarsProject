# 🧠 Complexiteitsanalyse: FirstNonRepeatingLetter

*Bronbestand: [FirstNonRepeatingLetter.cs](../Solutions/FirstNonRepeatingLetter.cs)*

---

1. **Complexiteit**: 
   - Tijdscomplexiteit: $\mathcal{O}(n^2)$ in het slechtste geval (vanwege het herhaaldelijk doorzoeken van substrings met `.Contains()` binnen de hoofdloop).
   - Ruimtecomplexiteit: $\mathcal{O}(n)$ vanwege het alloceren van substrings en kopieën bij het converteren naar lowercase/uppercase.

2. **Efficiëntst?**: 
   - Nee.

3. **Optimalisatiemogelijkheid**: 
   - De oplossing kan worden geoptimaliseerd naar $\mathcal{O}(n)$ tijd en $\mathcal{O}(n)$ ruimte door een `Dictionary<char, int>` (of `Span<int>` voor ASCII) te gebruiken. 
   - Tel eerst de frequentie van elk teken (waarbij je hoofdlettergevoeligheid negeert door naar lowercase te converteren, maar het originele teken behoudt). Doorloop daarna de string nogmaals om het eerste teken te vinden waarvan de frequentie gelijk is aan 1. Dit reduceert het aantal iteraties aanzienlijk.