# 🧠 Complexiteitsanalyse: MoveZeroes

*Bronbestand: [MoveZeroes.cs](../Solutions/MoveZeroes.cs)*

---

1. **Complexiteit**: 
   - Tijd: $\mathcal{O}(n \log n)$ door het gebruik van LINQ `OrderBy`.
   - Ruimte: $\mathcal{O}(n)$ voor het alloceren van de nieuwe array en de interne sorteerstructuren.

2. **Efficiëntst?**: 
   - Nee. Voor dit probleem is een tijdscomplexiteit van $\mathcal{O}(n)$ mogelijk en wenselijk.

3. **Optimalisatiemogelijkheid**: 
   - De huidige oplossing gebruikt een vergelijkingssorteeralgoritme dat trager is dan nodig. Het kan efficiënter door in een enkele iteratie ($\mathcal{O}(n)$ tijd) alle niet-nul elementen naar een nieuwe array te kopiëren (of ter plekke te verschuiven) en de resterende plekken automatisch met nullen te vullen.