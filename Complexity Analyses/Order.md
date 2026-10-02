# 🧠 Complexiteitsanalyse: Order

*Bronbestand: [Order.cs](../Solutions/Order.cs)*

---

1. **Complexiteit**:
   - **Tijd**: $O(N \log K)$ waar $N$ het aantal woorden is en $K$ het aantal elementen in de `SortedDictionary`. Door het gebruik van `SortedDictionary` en LINQ (`Single(char.IsDigit)`) is dit niet optimaal voor de tijd.
   - **Ruimte**: $O(N)$ voor de opslag in de dictionary en de array.

2. **Efficiëntst?**:
   - **Nee**. Hoewel $O(N)$ theoretisch mogelijk is door direct een array van vaste grootte te vullen, is de huidige implementatie trager door overhead van `SortedDictionary` (RBT-structuur), LINQ en boxing/unboxing bij `char.IsDigit`.

3. **Optimalisatiemogelijkheid**:
   De code kan efficiënter door een simpele `string[]` of `Span<string>` te gebruiken van vaste grootte (gebaseerd op het aantal woorden). Omdat de cijfers altijd van 1 tot $N$ lopen, kun je het cijfer direct als array-index gebruiken (minus 1), wat de tijdscomplexiteit verlaagt naar $O(N)$ zonder sorteer-overhead.