# 🧠 Complexiteitsanalyse: DuplicateEncoder

*Bronbestand: [DuplicateEncoder.cs](../Solutions/DuplicateEncoder.cs)*

---

1. **Tijdscomplexiteit (Time Complexity)**: $O(N)$
2. **Ruimtecomplexiteit (Space Complexity)**: $O(N)$
3. **Optimalisatie**: 
   - Vermijd LINQ-allocaties (`ToList()`) en herhaalde enumeraties door een traditionele `for`-loop of `foreach`-loop te gebruiken in combinatie met een `Span<char>` of `StringBuilder`.
   - Voor de frequentietelling is een `Dictionary<char, int>` goed, maar aangezien het alfabet vaak beperkt is (of ASCII), kan een vaste `int[256]` array of `Span` op de stack nog sneller werken en extra heap-allocaties voorkomen.