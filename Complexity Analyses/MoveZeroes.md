# 🧠 Complexiteitsanalyse: MoveZeroes

*Bronbestand: [MoveZeroes.cs](../Solutions/MoveZeroes.cs)*

---

1. **Complexiteit**
   - Tijd: $\mathcal{O}(n \log n)$ door het gebruik van LINQ's `OrderBy`.
   - Ruimte: $\mathcal{O}(n)$ voor het opslaan van de nieuwe array en de tussentijdse resultaten van de sorteerbewerking.

2. **Efficiëntst?**
   - **Nee**. De optimale tijdscomplexiteit voor dit probleem is $\mathcal{O}(n)$, omdat de elementen in één enkele doorgang herschikt kunnen worden zonder te sorteren.

3. **Optimalisatiemogelijkheid**
   - De huidige oplossing gebruikt een vergelijkingssorteeralgoritme (`OrderBy`), wat onnodig traag is. Dit kan optimaler door een array van dezelfde lengte te maken, in één iteratie alle niet-nul elementen op volgorde naar links te kopiëren, en de resterende plekken automatisch te laten vullen met nullen ($\mathcal{O}(n)$ tijd en $\mathcal{O}(n)$ ruimte). Nog efficiënter kan in $\mathcal{O}(n)$ tijd en $\mathcal{O}(1)$ extra ruimte door de elementen in-place te verschuiven met een dubbele pointer-strategie.