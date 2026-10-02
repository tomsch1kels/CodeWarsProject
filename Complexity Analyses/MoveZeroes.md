# 🧠 Complexiteitsanalyse: MoveZeroes

*Bronbestand: [MoveZeroes.cs](../Solutions/MoveZeroes.cs)*

---

### 1. Complexiteit
* **Tijdskomplexiteit**: $\mathcal{O}(n \log n)$ door het gebruik van LINQ's `OrderBy`.
* **Ruimtecomplexiteit**: $\mathcal{O}(n)$ voor het opslaan van de geordende array en de tussentijdse resultaten.

### 2. Efficiëntst?
* **Nee**, de optimale tijdscomplexiteit voor dit probleem is $\mathcal{O}(n)$.

### 3. Optimalisatiemogelijkheid
De huidige oplossing gebruikt een vergelijkingssorteeralgoritme via LINQ, wat trager is dan nodig. Het probleem kan in een enkele pass $\mathcal{O}(n)$ worden opgelost door een nieuwe array van dezelfde grootte aan te maken, alle niet-nul elementen van links naar rechts in te vullen, en de resterende plekken automatisch op nul te laten staan. Dit vermijdt overhead van sorteren en LINQ.