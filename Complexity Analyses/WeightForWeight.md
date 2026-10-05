# 🧠 Complexiteitsanalyse: WeightForWeight

*Bronbestand: [WeightForWeight.cs](../Solutions/WeightForWeight.cs)*

---

1. **Complexiteit**: 
   - Tijd: $\mathcal{O}(N \cdot M \log N)$ (waarbij $N$ het aantal gewichten is en $M$ de maximale lengte van een getalstring, vanwege het parsen van cijfers en de stringvergelijking bij het sorteren).
   - Ruimte: $\mathcal{O}(N \cdot M)$ voor het opslaan van de tuples en de gesplitste strings.

2. **Efficiëntst?**: 
   Nee. De tijdscomplexiteit kan niet fundamenteel omlaag vanwege de sortering ($\mathcal{O}(N \log N)$), maar de *constante factor* en geheugentoewijzing kunnen aanzienlijk worden verbeterd.

3. **Optimalisatiemogelijkheid**: 
   De huidige code maakt veel onnodige objecten aan door `ToList()`, LINQ-methoden en `char.GetNumericValue` binnen een lokale functie. Dit kan efficiënter door:
   - Het vermijden van LINQ en het direct in-place parsen van de cijfers (bijv. door een `ReadOnlySpan<char>` te loopen en cijferwaardes op te tellen via `c - '0'`).
   - Het gebruiken van `Array.Sort` i.p.v. LINQ `OrderBy` met een custom `IComparer<(long Weight, string Mass)>` om boxing/unboxing en enumerator-allocaties te elimineren.