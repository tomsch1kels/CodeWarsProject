# 🧠 Complexiteitsanalyse: DuplicateEncoder

*Bronbestand: [DuplicateEncoder.cs](../Solutions/DuplicateEncoder.cs)*

---

### 1. Complexiteit
* **Tijdcomplexiteit:** $\mathcal{O}(n)$
* **Ruimtecomplexiteit:** $\mathcal{O}(n)$

### 2. Efficiëntst?
* **Nee**, de Big O-tijdcomplexiteit is weliswaar optimaal ($\mathcal{O}(n)$), maar de implementatie gebruikt onnodige LINQ-allocaties en itereert meerdere keren over de data (`ToList()`, `ForEach()`, `Select()`).

### 3. Optimalisatiemogelijkheid
De code kan efficiënter door overbodige conversies (`ToList()`) en extra iteraties te verwijderen. 
* Gebruik een `Span<T>` of een simpele `int[]` lookup-tabel (voor ASCII) in plaats van een `Dictionary<char, int>` om overhead te vermijden.
* Bouw het resultaat direct met een `ReadOnlySpan<char>` of `StringBuilder` in één enkele iteratie door de string, of door de tellingen vooraf te berekenen in een vaste array en direct te mappen naar de output string.