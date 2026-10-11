# 🧠 Complexiteitsanalyse: Snail

*Bronbestand: [Snail.cs](../Solutions/Snail.cs)*

---

### 1. Complexiteit
* **Tijdcomplexiteit**: $\mathcal{O}(N^2)$ (waarbij $N$ de lengte van de zijde van de matrix is, wat neerkomt op $\mathcal{O}(K)$ totaal aantal elementen).
* **Ruimtecomplexiteit**: $\mathcal{O}(N^2)$ extra geheugen voor de `visited`-matrix.

### 2. Efficiëntst?
* **Tijd**: **Ja**, elke cel moet minstens één keer worden gelezen.
* **Ruimte**: **Nee**, de `visited`-matrix introduceert $\mathcal{O}(N^2)$ extra geheugengebruik.

### 3. Optimalisatiemogelijkheid
De `visited`-matrix en de methode `AllSurroundingBlocksWereVisited` zijn overbodig en kosten extra geheugen en CPU-cycletjes. 

De oplossing kan efficiënter door **grenzen (boundaries)** bij te houden (`top`, `bottom`, `left`, `right`). Hiermee itereer je in een `while`-lus direct langs de randen van de matrix, waardoor de ruimtecomplexiteit daalt naar **$\mathcal{O}(1)$** (afgezien van de resultaatarray) en de overhead van logische checks per stap verdwijnt.