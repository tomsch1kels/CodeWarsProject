# 🧠 Complexiteitsanalyse: Snail

*Bronbestand: [Snail.cs](../Solutions/Snail.cs)*

---

### 1. Complexiteit
* **Tijdcomplexiteit:** $\mathcal{O}(N^2)$ (waarbij $N$ de lengte van de matrix is, omdat elk element exact één keer wordt bezocht).
* **Ruimtecomplexiteit:** $\mathcal{O}(N^2)$ voor de `visited`-matrix en de resultaatarray.

### 2. Efficiëntst?
* **Tijd:** **Ja**, $\mathcal{O}(N^2)$ is optimaal omdat elk element in de matrix minstens één keer gelezen moet worden om de slak-volgorde te bepalen.
* **Ruimte:** **Nee**, de tijdelijke `visited`-matrix van $N \times N$ is redundant en kost extra geheugen en allocatietijd.

### 3. Optimalisatiemogelijkheid
De `visited`-matrix en de `AllSurroundingBlocksWereVisited`-controle zijn overbodig. Het algoritme kan efficiënter worden geschreven door gebruik te maken van vier dynamische grenzen (`top`, `bottom`, `left`, `right`). Hiermee reduceer je de ruimtecomplexiteit tot **$\mathcal{O}(1)$** (exclusief de resultaatarray) door simpelweg in een `while`-lus de grenzen te verkleinen na elke voltooide rand, zonder geheugenallocaties voor een bijhoudmatrix.