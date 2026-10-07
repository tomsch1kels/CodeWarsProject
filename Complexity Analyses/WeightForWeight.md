# 🧠 Complexiteitsanalyse: WeightForWeight

*Bronbestand: [WeightForWeight.cs](../Solutions/WeightForWeight.cs)*

---

1. **Complexiteit**: 
   - Tijd: $\mathcal{O}(N \cdot L \log N)$ (waarbij $N$ het aantal getallen is en $L$ de maximale lengte van een getal).
   - Ruimte: $\mathcal{O}(N \cdot L)$ voor het opslaan van de objecten en de gesplitste strings.

2. **Efficiëntst?**: 
   Nee. De tijdscomplexiteit kan optimaal $\mathcal{O}(N \cdot L + N \log N \cdot L)$ zijn, maar het geheugengebruik kan fors omlaag.

3. **Optimalisatiemogelijkheid**: 
   De huidige code maakt onnodig veel allocaties door `ToList()` en LINQ-methoden (`char.GetNumericValue`, `.Split(' ')`). Dit kan efficiënter door:
   - `Span<T>` of `ReadOnlyMemory<char>` te gebruiken om string-allocaties tijdens het parsen te vermijden.
   - Een custom `IComparer<(long Weight, string Mass)>` te schrijven om LINQ-overhead te reduceren.
   - `Array.Sort` te gebruiken in plaats van LINQ `OrderBy`, wat sneller werkt en minder geheugen kost.