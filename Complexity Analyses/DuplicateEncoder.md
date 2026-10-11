# 🧠 Complexiteitsanalyse: DuplicateEncoder

*Bronbestand: [DuplicateEncoder.cs](../Solutions/DuplicateEncoder.cs)*

---

1. **Complexiteit**: 
   - Tijd: $\mathcal{O}(n)$
   - Ruimte: $\mathcal{O}(n)$

2. **Efficiëntst?**: Ja. Een lineaire tijdscomplexiteit is optimaal omdat elk karakter minstens één keer gelezen moet worden.

3. **Optimalisatiemogelijkheid**: 
   De code kan optimaler qua geheugenallocatie en leesbaarheid. Het meerdere keren converteren naar lijsten (`.ToList()`) en gebruiken van LINQ veroorzaakt onnodige garbage collection. Dit kan worden verbeterd door:
   - Een `ReadOnlySpan<char>` te gebruiken i.p.v. `ToUpperInvariant()` op de hele string.
   - Een `Span<char>` of `StringBuilder` te gebruiken voor de resultaatstring.
   - Een simpele `Dictionary<char, int>` te vullen via een `foreach`-loop en direct te doorlopen met een indexers-loop i.p.v. LINQ.