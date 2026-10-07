# 🧠 Complexiteitsanalyse: Snail

*Bronbestand: [Snail.cs](../Solutions/Snail.cs)*

---

### 1. Complexiteit
* **Tijdskomplexiteit**: $\mathcal{O}(N^2)$ (waarbij $N$ de lengte van de zijde van de matrix is, wat neerkomt op $\mathcal{O}(K)$ totaal aantal elementen $K$).
* **Ruimtecomplexiteit**: $\mathcal{O}(N^2)$ extra geheugen vanwege de `visited`-matrix en de resultaatarray.

### 2. Efficiëntst?
* **Tijd**: **Ja**, elke cel in de matrix moet minstens één keer worden gelezen, waardoor $\mathcal{O}(N^2)$ de theoretisch optimale tijdscomplexiteit is.
* **Ruimte**: **Nee**, de ruimtecomplexiteit kan worden teruggebracht naar $\mathcal{O}(1)$ extra geheugen (exclusief de resultaatarray).

### 3. Optimalisatiemogelijkheid
De `visited`-matrix en de hulpfunctie `AllSurroundingBlocksWereVisited` zijn overbodig. Het slakkenhuispatroon kan veel efficiënter worden door grenzen (`top`, `bottom`, `left`, `right`) bij te houden die na elke voltooide ring krimpen. Dit verwijdert de geheugenoverhead van de `visited`-array, elimineert dure conditiecontroles per stap, en vereenvoudigt de code aanzienlijk.