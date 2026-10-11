# 🧠 Complexiteitsanalyse: DuplicateEncoder

*Bronbestand: [DuplicateEncoder.cs](../Solutions/DuplicateEncoder.cs)*

---

1. **Complexiteit**: 
   - Tijd: $\mathcal{O}(n)$
   - Ruimte: $\mathcal{O}(n)$
   *(waarbij $n$ de lengte van de invoerstring is)*

2. **Efficiëntst?**: 
   - Ja, de tijdscomplexiteit van $\mathcal{O}(n)$ is optimaal omdat elk karakter minstens één keer gelezen moet worden om te bepalen of het uniek is.

3. **Optimalisatiemogelijkheid**: 
   De huidige oplossing gebruikt onnodige LINQ-allocaties (`.ToList()`, `.ForEach()`, `.Select()`) en itereert tweemaal over de string (één keer voor de frequentietabel, één keer voor de translatie). 
   
   Dit kan efficiënter door:
   - Een `System.Collections.Generic.Dictionary` (of array/stackalloc bij een bekende tekset) direct te vullen via een traditionele `foreach`-lus over de string.
   - Een `System.Text.StringBuilder` of een `Span<char>` te gebruiken voor het opbouwen van het resultaat om LINQ-overhead en geheugenallocaties te minimaliseren.