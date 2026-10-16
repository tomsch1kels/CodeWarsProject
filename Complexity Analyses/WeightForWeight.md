# 🧠 Complexiteitsanalyse: WeightForWeight

*Bronbestand: [WeightForWeight.cs](../Solutions/WeightForWeight.cs)*

---

1. **Complexiteit**: 
   - Tijd: $O(N \cdot M \log N)$ waarbij $N$ het aantal gewichten is en $M$ de maximale lengte van een gewicht (vanwege de stringvergelijking bij het sorteren).
   - Ruimte: $O(N \cdot M)$ voor het opslaan van de elementen in lijsten en tuples.

2. **Efficiëntst?**: 
   - Nee. Hoewel de tijdscomplexiteit voor sorteren $O(N \log N)$ optimaal is, kan de overhead van geheugenallocaties en LINQ aanzienlijk worden verminderd.

3. **Optimalisatiemogelijkheid**: 
   - Vermijd LINQ-allocaties (`.ToList()`, `.Select()`) en het converteren van strings naar karakters (`.ToList().Sum(...)`) door de som direct over de string te itereren. 
   - Sorteer direct op een custom `IComparer<(long Weight, string Mass)>` of sla de berekende som op in een struct i.p.v. een `double` om autoboxing/overhead te minimaliseren.