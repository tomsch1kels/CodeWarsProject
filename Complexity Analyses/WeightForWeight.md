# 🧠 Complexiteitsanalyse: WeightForWeight

*Bronbestand: [WeightForWeight.cs](../Solutions/WeightForWeight.cs)*

---

1. **Complexiteit**: 
   - Tijd: $\mathcal{O}(N \cdot L \log N)$ waarin $N$ het aantal gewichten is en $L$ de maximale lengte van een getalsignatuur (vanwege het sorteren van strings bij gelijke gewichten).
   - Ruimte: $\mathcal{O}(N \cdot L)$ voor het opslaan van de tuples en de gesplitste strings.

2. **Efficiëntst?**: 
   - Ja, de asymptotische tijdscomplexiteit ($\mathcal{O}(N \log N)$ vergelijkingen) is optimaal voor een vergelijkingsgebaseerd sorteerprobleem.

3. **Optimalisatiemogelijkheid**: 
   De huidige code bevat overbodige allocaties en conversies. Dit kan efficiënter door:
   - `string.Split(' ')` te vermijden via een handmatige iteratie over de string of `Memory<char>` / `ReadOnlySpan<char>`.
   - `mass.ToList()` binnen de sommatie te elimineren (direct itereren over `string` of `ReadOnlySpan<char>`).
   - Het gebruik van `double` voor de gewichtsberekening te vervangen door `int` (som van cijfers past ruimschoots in een integer), wat snellere vergelijkingen oplevert.