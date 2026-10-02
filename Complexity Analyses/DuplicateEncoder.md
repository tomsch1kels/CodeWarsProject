# 🧠 Complexiteitsanalyse: DuplicateEncoder

*Bronbestand: [DuplicateEncoder.cs](../Solutions/DuplicateEncoder.cs)*

---

1. **Complexiteit**: 
   - Tijd: $\mathcal{O}(n)$
   - Ruimte: $\mathcal{O}(n)$
   *(waarbij $n$ de lengte van de invoerstring is)*

2. **Efficiëntst?**: Ja. Een lineaire tijdscomplexiteit $\mathcal{O}(n)$ is optimaal omdat elk karakter minstens één keer gelezen moet worden om te bepalen of het uniek is.

3. **Optimalisatiemogelijkheid**: 
   De huidige implementatie gebruikt overbodige LINQ-allocaties (`.ToList()`, `.ForEach()`, `.Select()`). Dit kan efficiënter en geheugenvriendelijker door:
   - Een `Dictionary` te vullen met een traditionele `foreach`-lus over de string.
   - Het resultaat te bouwen via een `Span<char>` of `StringBuilder` i.p.v. `string.Concat` met LINQ.
   - Alternatief: een `int[256]` array als lookup-tabel gebruiken in plaats van een `Dictionary` om overhead te vermijden (indien de tekenset beperkt is).