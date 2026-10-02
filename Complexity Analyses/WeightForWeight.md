# 🧠 Complexiteitsanalyse: WeightForWeight

*Bronbestand: [WeightForWeight.cs](../Solutions/WeightForWeight.cs)*

---

1. **Complexiteit**: 
   - Tijd: $\mathcal{O}(N \cdot L \log N)$, waarbij $N$ het aantal gewichten is en $L$ de maximale lengte (aantal cijfers) van een getal. De $\log N$ komt door het sorteren, vermenigvuldigd met $L$ omdat het vergelijken van twee strings van lengte $L$ in het worst-case scenario $\mathcal{O}(L)$ tijd kost (bij gelijke gewichten).
   - Ruimte: $\mathcal{O}(N \cdot L)$ voor het opslaan van de strings en tuples.

2. **Efficiëntst?**: 
   - Nee. Hoewel de tijdscomplexiteit asymptotisch optimaal is voor vergelijkingsgebaseerd sorteren, bevat de code overbodige allocaties en conversies.

3. **Optimalisatiemogelijkheid**: 
   - Vermijd LINQ-overhead en overtollige objectallocaties (zoals `.ToList()` en tuples) door direct te sorteren op basis van een vooraf berekend gewicht en de originele string. 
   - Optimaliseer `CalcWeightFromMass` door over de `ReadOnlySpan<char>` te itereren in plaats van `.ToList()` te gebruiken, wat linq-allocaties voorkomt.
   - Een custom `IComparer<(long Weight, string Mass)>` kan de LINQ-sortering efficiënter maken, of gebruik een stabiel sorteeralgoritme op een array i.p.v. LINQ `OrderBy/ThenBy`.