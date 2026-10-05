# 🧠 Complexiteitsanalyse: MoveZeroes

*Bronbestand: [MoveZeroes.cs](../Solutions/MoveZeroes.cs)*

---

1. **Complexiteit**
   - Tijd: $\mathcal{O}(n \log n)$ door het gebruik van LINQ's `OrderBy`.
   - Ruimte: $\mathcal{O}(n)$ voor het opslaan van de nieuwe array en de tussentijdse resultaten van de sortering.

2. **Efficiëntst?**
   - Nee. De optimale tijdscomplexiteit voor dit probleem is $\mathcal{O}(n)$.

3. **Optimalisatiemogelijkheid**
   - De huidige `OrderBy`-aanpak sorteert de array, wat onnodige overhead veroorzaakt. Dit kan efficiënter in één enkele pass ($\mathcal{O}(n)$ tijd en $\mathcal{O}(n)$ ruimte) door gebruik te maken van een nieuwe array (of `Span<T>`) waarbij alle niet-nul elementen op volgorde worden gekopieerd, waarna de resterende plekken automatisch op nul worden gelaten.