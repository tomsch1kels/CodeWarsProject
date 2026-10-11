# 🧠 Complexiteitsanalyse: Snail

*Bronbestand: [Snail.cs](../Solutions/Snail.cs)*

---

### 1. Complexiteit
* **Tijdcomplexiteit**: $\mathcal{O}(N^2)$ (waarbij $N$ de lengte van de zijde van de matrix is, wat neerkomt op $\mathcal{O}(M$ elementen totaal).
* **Ruimtecomplexiteit**: $\mathcal{O}(N^2)$ extra geheugen voor het `visited`-matrix en de resultaatarray.

### 2. Efficiëntst?
* **Tijd**: **Ja**, elke cel wordt exact één keer bezocht en weggeschreven, wat de theoretisch minimale tijdscomplexiteit is voor dit probleem.
* **Ruimte**: **Nee**, de tijds- en ruimtecomplexiteit qua asymptotische groei zijn optimaal ($\mathcal{O}(N^2)$), maar de geheugenallocatie kan const-factor geoptimaliseerd worden.

### 3. Optimalisatiemogelijkheid
De huidige oplossing gebruikt een `visited`-matrix van $\mathcal{O}(N^2)$ geheugen en doet per stap dure `AllSurroundingBlocksWereVisited`-controles. Dit kan efficiënter door **grenzen (boundaries)** bij te houden (`top`, `bottom`, `left`, `right`) in plaats van een `visited`-array. 

Hierdoor:
* Elimineer je de geheugenallocatie en overhead van de `visited`-matrix ($\mathcal{O}(1)$ extra ruimte).
* Vermijd je de complexe conditie-controles per stap.
* Verlaag je de constante factor (faster execution time) aanzienlijk.