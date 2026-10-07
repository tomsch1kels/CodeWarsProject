# 🧠 Complexiteitsanalyse: MoveZeroes

*Bronbestand: [MoveZeroes.cs](../Solutions/MoveZeroes.cs)*

---

1. **Complexiteit**: 
   - Tijd: $\mathcal{O}(n \log n)$ door het gebruik van LINQ's `OrderBy`.
   - Ruimte: $\mathcal{O}(n)$ voor het opslaan van de gesorteerde resultaten en de array-expression.

2. **Efficiëntst?**: 
   - Nee. De optimale tijdscomplexiteit voor dit probleem is $\mathcal{O}(n)$.

3. **Optimalisatiemogelijkheid**: 
   - De huidige `OrderBy`-benadering sorteert de elementen, wat onnodige overhead veroorzaakt en bovendien de *originele* onderlinge volgorde van niet-nul elementen kan verstoren (aangezien `OrderBy` niet stabiel is in alle contexten, hoewel het in dit specifieke geval toevallig vaak goed gaat door de booleaanse conditie).
   - Dit kan efficiënter in $\mathcal{O}(n)$ tijd en $\mathcal{O}(n)$ extra ruimte door één keer door de array te itereren: plaats alle niet-nul elementen in een nieuwe array (of `Span<T>`) en vul de resterende plekken aan met nullen. Een in-place tweewijzer-algoritme (two-pointer) bereikt zelfs $\mathcal{O}(1)$ extra ruimte als mutatie is toegestaan.