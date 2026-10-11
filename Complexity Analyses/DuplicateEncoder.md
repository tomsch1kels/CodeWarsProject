# 🧠 Complexiteitsanalyse: DuplicateEncoder

*Bronbestand: [DuplicateEncoder.cs](../Solutions/DuplicateEncoder.cs)*

---

1. **Complexiteit**: 
   - Tijd: $\mathcal{O}(N)$
   - Ruimte: $\mathcal{O}(N)$
   (waarbij $N$ de lengte van de string is).

2. **Efficiëntst?**: 
   Nee. Hoewel de tijdscomplexiteit $\mathcal{O}(N)$ optimaal is, creëert de huidige implementatie te veel onnodige tussentijdse objecten en enumerables (`.ToList()`, LINQ `ForEach` en `Select`).

3. **Optimalisatiemogelijkheid**: 
   Vervang de LINQ-operaties en conversies door traditionele `for`-loops en een `Span<char>` of `StringBuilder` om geheugenallocaties (garbage collection pressure) drastisch te verminderen. Een `int[256]` lookup-tabel (of `Dictionary` met vooraf toegewezen capaciteit) is bovendien sneller dan `GetValueOrDefault`.