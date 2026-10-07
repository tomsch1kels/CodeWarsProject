# 🧠 Complexiteitsanalyse: WeightForWeight

*Bronbestand: [WeightForWeight.cs](../Solutions/WeightForWeight.cs)*

---

1. **Complexiteit**: 
   - Tijd: $\mathcal{O}(N \cdot L \log N)$ (waarbij $N$ het aantal getallen is en $L$ de maximale lengte van een getal, vanwege de stringvergelijking bij het sorteren).
   - Ruimte: $\mathcal{O}(N \cdot L)$ voor het opslaan van de tuples en de gesplitste strings.

2. **Efficiëntst?**: 
   Nee. De tijdscomplexiteit kan niet veel omlaag omdat sorteren minimaal $\mathcal{O}(N \log N)$ kost, maar de *constante factor* en geheugenallocaties kunnen flink worden gereduceerd.

3. **Optimalisatiemogelijkheid**: 
   De huidige code gebruikt veel onnodige LINQ-operaties, string-allocaties (`.ToList()`, `.Split(' ')`, `char.GetNumericValue`) en `double`-casts. Dit kan optimaler door:
   - `Memory<char>` of `ReadOnlySpan<char>` te gebruiken om zero-allocation stringmanipulatie te bereiken.
   - Het gewicht direct tijdens het parsen te berekenen zonder `ToList()` of `Sum()` op iterators.
   - Een custom `IComparer<string>` te schrijven die het gewicht en de alfabetische volgorde direct berekent en vergelijkt, waardoor de tuple-lijst overbodig wordt en we in-place of met minimale allocaties kunnen sorteren (`Array.Sort`).