# 🧠 Complexiteitsanalyse: WeightForWeight

*Bronbestand: [WeightForWeight.cs](../Solutions/WeightForWeight.cs)*

---

1. **Complexiteit**: 
   - Tijd: $O(N \cdot M \log N)$, waarbij $N$ het aantal gewichten is en $M$ de maximale lengte van een gewicht (vanwege de stringvergelijking bij het sorteren).
   - Ruimte: $O(N \cdot M)$ voor het opslaan van de objecten en strings in geheugen.

2. **Efficiëntst?**: 
   - Nee. Hoewel de tijdscomplexiteit $O(N \log N)$ optimaal is voor vergelijking-gebaseerd sorteren, veroorzaakt het gebruik van `ToList()`, LINQ en tuple-allocaties onnodige garbage collection overhead.

3. **Optimalisatiemogelijkheid**: 
   - Vermijd LINQ en objectallocaties door de invoer direct te parsen naar een `Span<T>` of array van structs met de numerieke som en de originele string. 
   - Gebruik een `Array.Sort` of een custom `IComparer<string>` die de som berekent en bij een gelijke som een alfagenerieke `StringComparer.Ordinal` vergelijking uitvoert, zonder extra geheugentoewijzingen per element.