# 🧠 Complexiteitsanalyse: Snail

*Bronbestand: [Snail.cs](../Solutions/Snail.cs)*

---

### 1. Complexiteit
* **Tijdcomplexiteit**: $\mathcal{O}(N^2)$ (waarbij $N$ de lengte van de zijde van de matrix is, oftewel totaal aantal elementen $M = N^2$).
* **Ruimtecomplexiteit**: $\mathcal{O}(N^2)$ extra geheugen voor de `visited`-matrix en het resultaat-array.

### 2. Efficiëntst?
* **Ja**, de tijdscomplexiteit is optimaal ($\mathcal{O}(M)$) omdat elk element in de matrix exact één keer bezocht moet worden. 

### 3. Optimalisatiemogelijkheid
De huidige oplossing kan qua **geheugenruimte** en **overhead** worden geoptimaliseerd. 
* **Geen `visited`-array nodig**: Door gebruik te maken van vier dynamische grenzen (`top`, `bottom`, `left`, `right`) die naar binnen krimpen na elke voltooide rand, is de `visited`-matrix overbodig. Dit reduceert de ruimtecomplexiteit tot $\mathcal{O}(1)$ (exclusief het resultaat-array).
* **Geen helperfuncties**: Het bijhouden van grenzen verwijdert ook de dure `AllSurroundingBlocksWereVisited`-controles per stap, wat de constante factor in de uitvoeringstijd significant verlaagt.