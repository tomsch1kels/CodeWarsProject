# 🧠 Complexiteitsanalyse: DuplicateEncoder

*Bronbestand: [DuplicateEncoder.cs](../Solutions/DuplicateEncoder.cs)*

---

1. **Complexiteit**: 
   - Tijd: $\mathcal{O}(n)$
   - Ruimte: $\mathcal{O}(n)$

2. **Efficiëntst?**: 
   - **Ja**, de tijdscomplexiteit van $\mathcal{O}(n)$ is optimaal omdat elk karakter minstens één keer gelezen moet worden om te bepalen of het uniek is.

3. **Optimalisatiemogelijkheid**: 
   Hoewel de Big O-complexiteit optimaal is, kan de *prestatie* (runtime en geheugen) worden verbeterd door LINQ-overhead (`ToList()`, `ForEach()`, `Select()`) te vermijden. Dit kan door een traditionele `for`-lus te gebruiken in combinatie met een `Span<char>` of `StringBuilder` om allocaties te minimaliseren en enumeratie te halveren (één pass voor de frequentietabel, één pass voor het bouwen van het resultaat).