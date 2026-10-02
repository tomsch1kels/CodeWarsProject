# 🧠 Complexiteitsanalyse: WeightForWeight

*Bronbestand: [WeightForWeight.cs](../Solutions/WeightForWeight.cs)*

---

1. **Complexiteit**: 
   - Tijd: $\mathcal{O}(N \cdot L \log N)$, waarbij $N$ het aantal gewichten is en $L$ de maximale lengte van een getal (vanwege de stringvergelijking bij het sorteren).
   - Ruimte: $\mathcal{O}(N \cdot L)$ voor het opslaan van de tuples en de gesplitste strings.

2. **Efficientst?**: 
   - Nee. Hoewel de tijdscomplexiteit voor vergelijking optimaal is, creëert de huidige code te veel onnodige objecten (`List`, tuples, `ToList()`, en array-allocaties door `Split`).

3. **Optimalisatiemogelijkheid**: 
   De code kan efficiënter door LINQ te vermijden en direct te sorteren met een `Comparison<string>` waarbij de som vooraf wordt berekend (of on-the-fly gecached in een struct/tuple om herhaalde sommatie te voorkomen). Dit vermindert de garbage collection druk aanzienlijk door `Memory<char>` of `ReadOnlySpan<char>` te gebruiken i.p.v. `string.Split()`.