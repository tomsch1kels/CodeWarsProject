# 🧠 Complexiteitsanalyse: DuplicateEncoder

*Bronbestand: [DuplicateEncoder.cs](../Solutions/DuplicateEncoder.cs)*

---

1. **Complexiteit**: 
   - Tijd: $O(N)$
   - Ruimte: $O(N)$
   (waarbij $N$ de lengte van de string is).

2. **Efficiëntst?**: 
   Nee, hoewel de tijdscomplexiteit $O(N)$ optimaal is, kan de *praktische* efficiëntie (geheugenallocatie en snelheid) flink worden verbeterd door LINQ-overhead te verwijderen.

3. **Optimalisatiemogelijkheid**: 
   Vervang de `LINQ`-methoden (`ToList()`, `ForEach`, `Select`) en het herhaaldelijk doorlopen van de string door een `Span<char>` of een traditionele `for`-lus in combinatie met een `StringBuilder` of `char[]`. Hierdoor worden onnodige objectallocaties op de heap vermeden, wat de Garbage Collector ontlast.