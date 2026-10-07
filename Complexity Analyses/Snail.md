# 🧠 Complexiteitsanalyse: Snail

*Bronbestand: [Snail.cs](../Solutions/Snail.cs)*

---

1. **Complexiteit**:
   - **Tijdcomplexiteit**: $\mathcal{O}(N^2)$ (waarbij $N \times N$ de afmeting is van de matrix, omdat elk element exact één keer wordt bezocht).
   - **Ruimtecomplexiteit**: $\mathcal{O}(N^2)$ vanwege de toewijzing van de `visited`-matrix en de `result`-array.

2. **Efficiëntst?**:
   - **Tijd**: **Ja**, de tijdscomplexiteit van $\mathcal{O}(N^2)$ is optimaal omdat elk element in de matrix minimaal één keer gelezen moet worden.
   - **Ruimte**: **Nee**, de ruimtecomplexiteit kan worden geoptimaliseerd.

3. **Optimalisatiemogelijkheid**:
   De `visited`-matrix van $\mathcal{O}(N^2)$ is overbodig. De slak kan ook worden doorgedrukt door grenzen (`top`, `bottom`, `left`, `right`) bij te houden die na elke voltooide ring krimpen. Dit reduceert de extra geheugenoverhead tot **$\mathcal{O}(1)$** (exclusief de resultaatarray) en verwijdert de dure `AllSurroundingBlocksWereVisited`-controles per stap.