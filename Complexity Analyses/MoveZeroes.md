# 🧠 Complexiteitsanalyse: MoveZeroes

*Bronbestand: [MoveZeroes.cs](../Solutions/MoveZeroes.cs)*

---

1. **Complexiteit**: 
   - Tijd: $\mathcal{O}(N \log N)$ door het gebruik van `OrderBy`.
   - Ruimte: $\mathcal{O}(N)$ voor het opslaan van de gesorteerde array.

2. **Efficiëntst?**: 
   - Nee. De optimale tijdscomplexiteit voor dit probleem is $\mathcal{O}(N)$.

3. **Optimalisatiemogelijkheid**: 
   - De huidige oplossing gebruikt LINQ sorteren, wat traag is en de oorspronkelijke volgorde van niet-nul elementen potentieel kan verstoren (hoewel `OrderBy` stabiel is, is het overkill). 
   - Het kan efficiënter in $\mathcal{O}(N)$ tijd en $\mathcal{O}(N)$ ruimte door een nieuwe array te vullen: itereer door de invoer, plaats alle elementen unaniem in een nieuwe array (of `Span<T>`) en vul de resterende plekken aan met nullen, of gebruik een tweepunter-strategie die in één pass de elementen verplaatst.