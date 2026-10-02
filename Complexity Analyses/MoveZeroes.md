# 🧠 Complexiteitsanalyse: MoveZeroes

*Bronbestand: [MoveZeroes.cs](../Solutions/MoveZeroes.cs)*

---

1. **Complexiteit**:
   - **Tijdcomplexiteit**: $\mathcal{O}(n \log n)$ als gevolg van het interne sorteringsalgoritme (`OrderBy`), waarbij $n$ het aantal elementen in de array is.
   - **Ruimtecomplexiteit**: $\mathcal{O}(n)$ voor het creëren van de tussentijdse sequenties en de uiteindelijke nieuwe array via de collection expression `[.. ...]`.

2. **Optimalisatiemogelijkheid**:
   - Ja, dit kan efficiënter. De huidige aanpak gebruikt een vergelijkingssortering die trager is dan nodig en bovendien de oorspronkelijke volgorde van non-zero elementen niet garandeert (omdat `OrderBy` niet stabiel is in C# voor gelijke sleutels). 
   - Dit kan worden opgelost in **$\mathcal{O}(n)$ tijd** en **$\mathcal{O}(n)$ ruimte** door een enkelvoudige iteratie: vul een nieuwe array (of `List<int>`) achtereenvolgens met alle non-zero elementen, en vul de resterende plekken aan met nullen. Nog optimaler kan in-place met twee pointers.