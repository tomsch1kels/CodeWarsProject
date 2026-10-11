# 🧠 Complexiteitsanalyse: MoveZeroes

*Bronbestand: [MoveZeroes.cs](../Solutions/MoveZeroes.cs)*

---

1. **Complexiteit**: 
   - Tijd: $\mathcal{O}(N \log N)$ door het gebruik van LINQ `OrderBy`.
   - Ruimte: $\mathcal{O}(N)$ voor het opslaan van de nieuwe array.

2. **Efficiëntst?**: 
   - Nee. De optimale tijdscomplexiteit voor dit probleem is $\mathcal{O}(N)$.

3. **Optimalisatiemogelijkheid**: 
   - De huidige oplossing gebruikt een stabiele sorteeralgoritme (`OrderBy`), wat overkill is en onnodige overhead veroorzaakt. Dit kan efficiënter in $\mathcal{O}(N)$ tijd door een tweepunter-benadering of een enkele array-iteratie: kopieer alle niet-nul elementen naar een nieuwe array (of dezelfde array) en vul de resterende plekken op met nullen.