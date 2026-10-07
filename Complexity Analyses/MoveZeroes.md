# 🧠 Complexiteitsanalyse: MoveZeroes

*Bronbestand: [MoveZeroes.cs](../Solutions/MoveZeroes.cs)*

---

1. **Complexiteit**: 
   - Tijd: $\mathcal{O}(n \log n)$ vanwege de `OrderBy` operatie.
   - Ruimte: $\mathcal{O}(n)$ voor het opslaan van de geordende array en de collection expression.

2. **Efficiëntst?**: 
   - Nee. De optimale tijdscomplexiteit voor dit probleem is $\mathcal{O}(n)$.

3. **Optimalisatiemogelijkheid**: 
   - De huidige `OrderBy`-aanpak sorteert de elementen, wat onnodige vergelijkingen en overhead veroorzaakt. Dit kan efficiënter in $\mathcal{O}(n)$ tijd door gebruik te maken van een enkele iteratie: itereer door de input-array, kopieer alle niet-nul elementen naar een nieuwe array van dezelfde grootte, en vul de resterende plekken automatisch aan met nullen.