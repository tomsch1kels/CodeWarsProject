# 🧠 Complexiteitsanalyse: WeightForWeight

*Bronbestand: [WeightForWeight.cs](../Solutions/WeightForWeight.cs)*

---

1. **Complexiteit**: 
   - Tijd: $\mathcal{O}(N \cdot L \log N)$ waarbij $N$ het aantal gewichten is en $L$ de maximale lengte (aantal cijfers) van een gewicht.
   - Ruimte: $\mathcal{O}(N \cdot L)$ voor het opslaan van de objecten en de gescheiden strings.

2. **Efficiëntst?**: 
   Nee.

3. **Optimalisatiemogelijkheid**: 
   De huidige code maakt onnodig gebruik van LINQ-allocaties (`ToList()`, `Select()`) en karakterconversies (`mass.ToList().Sum(...)`). Dit kan optimaler door direct over de string te itereren zonder geheugenallocaties per getal en door `Array.Sort` te gebruiken met een custom `Comparison<T>` of `IComparer<T>`, waardoor de tijdscomplexiteit voor het sorteren verbetert naar $\mathcal{O}(N \log N \cdot L)$ en de garbage collection druk aanzienlijk afneemt.