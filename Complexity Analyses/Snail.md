# 🧠 Complexiteitsanalyse: Snail

*Bronbestand: [Snail.cs](../Solutions/Snail.cs)*

---

### 1. Complexiteit
* **Tijdcomplexiteit:** $\mathcal{O}(N^2)$, waarbij $N$ de lengte van een zijde van de matrix is (elke cel wordt exact één keer bezocht).
* **Ruimtecomplexiteit:** $\mathcal{O}(N^2)$ voor de `visited`-array en de resultaatarray.

### 2. Efficiëntst?
* **Tijd:** **Ja**, $\mathcal{O}(N^2)$ is optimaal omdat elk element in de matrix minstens één keer gelezen moet worden.
* **Ruimte:** **Nee**, de tijdelijke `visited`-matrix is overbodig.

### 3. Optimalisatiemogelijkheid
De `visited`-matrix en de methode `AllSurroundingBlocksWereVisited` kunnen volledig worden verwijderd. Door gebruik te maken van vier dynamische begrenzingsvariabelen (`top`, `bottom`, `left`, `right`) die inkrimpen na elke afgelegde zijde, kan het slakkenhuis-patroon direct en iteratief worden doorlopen. Dit reduceert de extra geheugencomplexiteit tot $\mathcal{O}(1)$ (exclusief de resultaatarray) en vereenvoudigt de controlflow aanzienlijk.