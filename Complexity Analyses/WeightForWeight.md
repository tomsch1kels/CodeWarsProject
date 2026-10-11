# 🧠 Complexiteitsanalyse: WeightForWeight

*Bronbestand: [WeightForWeight.cs](../Solutions/WeightForWeight.cs)*

---

1. **Complexiteit**: 
   - Tijd: $O(N \cdot M \log N)$, waarbij $N$ het aantal gewichten is en $M$ de maximale lengte van een getal (vanwege de stringvergelijking bij het sorteren).
   - Ruimte: $O(N \cdot M)$ voor het opslaan van de objecten en de gesplitste strings in geheugen.

2. **Efficiëntst?**: 
   Nee.

3. **Optimalisatiemogelijkheid**: 
   De efficiëntie kan worden verbeterd door LINQ-allocaties ($.ToList()$, anonieme tuples) te verminderen en direct te sorteren op een custom `IComparer<(long Weight, string Mass)>` of een dedicated struct. Daarnaast kan de sommatie van de cijfers geoptimaliseerd worden door direct over de stringkarakters te itereren in plaats van `.ToList().Sum(char.GetNumericValue)`.