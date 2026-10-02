# 🧠 Complexiteitsanalyse: FirstNonRepeatingLetter

*Bronbestand: [FirstNonRepeatingLetter.cs](../Solutions/FirstNonRepeatingLetter.cs)*

---

1. **Complexiteit**: 
   - Tijdslimiet: $\mathcal{O}(N^2)$ in het slechtste geval (door herhaalde string slicing en `Contains` checks per karakter).
   - Ruimtecomplexiteit: $\mathcal{O}(N)$ (vanwege het creëren van substrings en lower/upper case conversies).

2. **Efficientst?**: 
   Nee. Het probleem kan in $\mathcal{O}(N)$ tijd en $\mathcal{O}(N)$ ruimte worden opgelost.

3. **Optimalisatiemogelijkheid**: 
   De huidige oplossing herberekent frequenties door de string herhaaldelijk te doorzoeken. Dit kan drastisch worden versneld door een `Dictionary<char, int>` (of een vaste array van grootte 256/Unicode) te gebruiken om de frequentie van elke letter (ongevoelig voor hoofdletters) in één enkele pass van $\mathcal{O}(N)$ te tellen. In een tweede pass van $\mathcal{O}(N)$ kan dan het eerste teken met frequentie 1 worden geretourneerd, waarbij de oorspronkelijke casing behouden blijft.