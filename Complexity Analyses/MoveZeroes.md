# 🧠 Complexiteitsanalyse: MoveZeroes

*Bronbestand: [MoveZeroes.cs](../Solutions/MoveZeroes.cs)*

---

1. **Complexiteit**: 
   - Tijd: $\mathcal{O}(N \log N)$ door het gebruik van `OrderBy`.
   - Ruimte: $\mathcal{O}(N)$ voor het opslaan van de nieuwe array en de tussentijdse sortering.

2. **Efficientst?**: 
   - Nee. De optimale tijdscomplexiteit voor dit probleem is $\mathcal{O}(N)$.

3. **Optimalisatiemogelijkheid**: 
   De huidige oplossing gebruikt LINQ sortering, wat onnodig traag is. Het kan efficiënter door in een enkele `for`-loop alle niet-nul elementen naar een nieuwe array (of buffer) te kopiëren en de resterende plaatsen automatisch met nullen te vullen. Dit bereikt een lineaire tijdcomplexiteit van $\mathcal{O}(N)$ en bewaart de oorspronkelijke volgorde (stabiel).