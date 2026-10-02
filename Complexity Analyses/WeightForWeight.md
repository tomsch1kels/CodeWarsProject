# 🧠 Complexiteitsanalyse: WeightForWeight

*Bronbestand: [WeightForWeight.cs](../Solutions/WeightForWeight.cs)*

---

1. **Complexiteit**: 
   - Tijd: $\mathcal{O}(N \cdot M \log N)$ waarbij $N$ het aantal gewichten is en $M$ de maximale lengte van een getal (vanwege de stringvergelijking bij het sorteren).
   - Ruimte: $\mathcal{O}(N \cdot M)$ voor het opslaan van de tuples en gesplitste strings.

2. **Efficiëntst?**: 
   - Nee. Hoewel de tijdscomplexiteit voor vergelijking optimaal is ($\mathcal{O}(N \log N)$), bevat de huidige implementatie veel overbodige object-allocaties (zoals `ToList()`, `char.GetNumericValue` en boxed enumerables) die de garbage collector zwaar belasten.

3. **Optimalisatiemogelijkheid**: 
   - Vermijd LINQ-overhead en geheugenallocaties door `ReadOnlySpan<char>` te gebruiken voor het parsen van getallen en een custom `IComparer<string>` toe te passen in plaats van tuples aan te maken. Dit vermindert heap-allocaties tot nagenoeg nul.