# 🧠 Complexiteitsanalyse: MoveZeroes

*Bronbestand: [MoveZeroes.cs](../Solutions/MoveZeroes.cs)*

---

### 1. Complexiteit
* **Tijdcomplexiteit**: $\mathcal{O}(N \log N)$ door het gebruik van `OrderBy`, waarbij $N$ het aantal elementen in de array is.
* **Ruimtecomplexiteit**: $\mathcal{O}(N)$ voor het opslaan van de geordende array en het nieuwe resultaat.

### 2. Efficiëntst?
**Nee**. De optimale tijdscomplexiteit voor dit probleem is $\mathcal{O}(N)$.

### 3. Optimalisatiemogelijkheid
De huidige oplossing is traag door de sortering. Dit kan efficiënter in $\mathcal{O}(N)$ tijd en $\mathcal{O}(N)$ extra ruimte door gebruik te maken van een enkele iteratie: verzamel alle niet-nul elementen in een nieuwe array (of lijst) en vul de resterende plekken aan met nullen, of verschuif elementen in-place van links naar rechts.