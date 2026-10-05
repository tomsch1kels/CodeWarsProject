# 🧠 Complexiteitsanalyse: WeightForWeight

*Bronbestand: [WeightForWeight.cs](../Solutions/WeightForWeight.cs)*

---

1. **Complexiteit**: 
   - Tijd: $\mathcal{O}(N \cdot L \log N)$ (waarbij $N$ het aantal getallen is en $L$ de maximale lengte van een getal, vanwege het sorteren en stringvergelijkingen).
   - Ruimte: $\mathcal{O}(N \cdot L)$ voor het opslaan van de tuples en de gesplitste strings.

2. **Efficiëntst?**: 
   - Nee. Hoewel de asymptotische tijdscomplexiteit voor vergelijkingssorteren optimaal is ($N \log N$), doet de huidige implementatie veel overbodige allocaties en herhaalde berekeningen.

3. **Optimalisatiemogelijkheid**: 
   - De oplossing kan efficiënter door LINQ-allocaties (zoals `.ToList()` en `char.GetNumericValue`) te vermijden. 
   - Door direct te itereren over de string met `Span<T>` of `Memory<T>`, of door de gewichtsberekening inline uit te voeren tijdens het parsen, elimineer je heap-allocaties. 
   - Sla de berekende gewichten op in een eenvoudige struct om boxing te voorkomen, en gebruik een custom `IComparer<(long Weight, string Mass)>` om stringvergelijkingen te optimaliseren.