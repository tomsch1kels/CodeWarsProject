# 🧠 Complexiteitsanalyse: WeightForWeight

*Bronbestand: [WeightForWeight.cs](../Solutions/WeightForWeight.cs)*

---

1. **Complexiteit**: 
   - **Tijd**: $O(N \cdot M \log N)$, waarbij $N$ het aantal gewichten is en $M$ de maximale lengte van een getalsignatuur (vanwege het splitsen, sommeren per getal en het sorteren van de tuples).
   - **Ruimte**: $O(N \cdot M)$ voor het opslaan van de string-arrays, lijsten en tuples in geheugen.

2. **Optimalisatiemogelijkheid**: 
   De huidige code kan efficiënter door overbodige allocaties te verwijderen. Het gebruik van `.ToList()` op `mass` en `strng.Split(' ').ToList()` creëert onnodige heap-allocaties. Dit is op te lossen door `ReadOnlySpan<char>` te gebruiken voor het parsen en sommeren, en te sorteren op basis van een custom `IComparer<(long Weight, string Mass)>` of rechtstreeks via LINQ op de originele array zonder tussentijdse `List`-instanties.