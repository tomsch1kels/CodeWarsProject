# 🧠 Complexiteitsanalyse: WeightForWeight

*Bronbestand: [WeightForWeight.cs](../Solutions/WeightForWeight.cs)*

---

1. **Complexiteit**: 
   - Tijd: $\mathcal{O}(N \cdot M \log N)$ waarbij $N$ het aantal gewichten is en $M$ de maximale lengte van een getal (vanwege de stringvergelijking bij het sorteren).
   - Ruimte: $\mathcal{O}(N \cdot M)$ voor het opslaan van de objecten en de gesplitste strings in geheugen.

2. **Efficiëntst?**: 
   Nee.

3. **Optimalisatiemogelijkheid**: 
   De huidige code gebruikt onnodige LINQ-allocaties zoals `.ToList()`, `mass.ToList()` en het creëren van tuples. Dit kan geoptimaliseerd worden door:
   - `string.Split(' ')` direct te sorteren met een `Comparison<string>` of een custom `IComparer<string>` i.p.v. tuples te maken.
   - Het gewicht direct te berekenen via een simpele `foreach`-loop over de karakters van de string zonder LINQ of `.ToList()`, om `dotnet` garbage collection druk te minimaliseren.