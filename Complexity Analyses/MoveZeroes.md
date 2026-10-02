# 🧠 Complexiteitsanalyse: MoveZeroes

*Bronbestand: [MoveZeroes.cs](../Solutions/MoveZeroes.cs)*

---

1. **Complexiteit**
   - Tijd: $O(n \log n)$ door het gebruik van `OrderBy`.
   - Ruimte: $O(n)$ voor het opslaan van de geordende array en de LINQ-interne collecties.

2. **Efficiëntst?**
   - **Nee**. De optimale tijdscomplexiteit voor dit probleem is $O(n)$.

3. **Optimalisatiemogelijkheid**
   - De huidige oplossing gebruikt een vergelijking (`i == 0`) binnen `OrderBy` die niet-stabiel is, waardoor de oorspronkelijke volgorde van non-zero elementen potentieel verloren kan gaan (afhankelijk van de LINQ implementatie, al sorteert `OrderBy` stabiel, de boolean logica kan dit verstoren en is trager dan nodig). 
   - Dit kan efficiënter in $O(n)$ tijd en $O(n)$ ruimte door een nieuwe array te vullen: loop één keer door de input, plaats alle non-zero elementen in een nieuwe array (of `Span<T>`), en vul de resterende plekken aan met nullen.