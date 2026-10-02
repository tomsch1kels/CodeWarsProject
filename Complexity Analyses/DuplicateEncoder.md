# 🧠 Complexiteitsanalyse: DuplicateEncoder

*Bronbestand: [DuplicateEncoder.cs](../Solutions/DuplicateEncoder.cs)*

---

1. **Tijdscomplexiteit (Time Complexity)**: 
   $O(N)$

2. **Ruimtecomplexiteit (Space Complexity)**: 
   $O(N)$

3. **Optimalisatie**: 
   De huidige implementatie doet te veel onnodige iteraties en allocaties door herhaaldelijk `.ToList()` en LINQ te gebruiken. Dit kan efficiënter en sneller door:
   - Een `Dictionary` te vullen met een simpele `foreach`-lus in plaats van LINQ's `ForEach`.
   - Een `Span<char>` of `StringBuilder` te gebruiken voor de uiteindelijke string-constructie om geheugenallocaties op de heap te minimaliseren.
   - Eventueel de frequenties direct in een vaste array van `int[256]` (of `int[65536]` voor alle Unicode BMP karakters) bij te houden in plaats van een `Dictionary`, wat de lookup-overhead volledig elimineert.