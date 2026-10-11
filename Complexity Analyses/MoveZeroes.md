# 🧠 Complexiteitsanalyse: MoveZeroes

*Bronbestand: [MoveZeroes.cs](../Solutions/MoveZeroes.cs)*

---

1. **Complexiteit**: 
   - Tijd: $\mathcal{O}(N \log N)$ door het gebruik van LINQ `OrderBy`.
   - Ruimte: $\mathcal{O}(N)$ voor het opslaan van de nieuwe array en de interne sorteerstructuren.

2. **Efficiëntst?**: 
   - Nee. De optimale tijdscomplexiteit voor dit probleem is $\mathcal{O}(N)$.

3. **Optimalisatiemogelijkheid**: 
   - De huidige oplossing gebruikt een vergelijking (`i == 0`) binnen `OrderBy`, wat onstabiel kan zijn en onnodig sorteerwerk ($\mathcal{O}(N \log N)$) triggert. 
   - Dit kan efficiënter in $\mathcal{O}(N)$ tijd en $\mathcal{O}(N)$ ruimte door een nieuwe array te vullen: itereer eenmalig over de invoer om alle niet-nul waarden te kopiëren, en vul de resterende plekken aan met nullen.