# 🧠 Complexiteitsanalyse: MoveZeroes

*Bronbestand: [MoveZeroes.cs](../Solutions/MoveZeroes.cs)*

---

1. **Complexiteit**: 
   - Tijd: $\mathcal{O}(n \log n)$ vanwege de `OrderBy` operatie.
   - Ruimte: $\mathcal{O}(n)$ voor het opslaan van de nieuwe array en de tussentijdse resultaten.

2. **Efficiëntst?**: 
   Nee. De optimale tijdscomplexiteit voor dit probleem is $\mathcal{O}(n)$.

3. **Optimalisatiemogelijkheid**: 
   De huidige `LINQ`-aanpak gebruikt een vergelijkingssortering die trager is dan nodig. Het kan efficiënter door in een enkele iteratie ($\mathcal{O}(n)$ tijd) alle non-zero elementen naar een nieuwe array (of in-place) te kopiëren en de resterende plekken met nullen te vullen, bijvoorbeeld met een twee-pointer benadering of door gebruik te maken van `Array.Copy`.