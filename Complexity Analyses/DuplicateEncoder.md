# 🧠 Complexiteitsanalyse: DuplicateEncoder

*Bronbestand: [DuplicateEncoder.cs](../Solutions/DuplicateEncoder.cs)*

---

1. **Complexiteit**: 
   - Tijd: $O(N)$
   - Ruimte: $O(N)$
   (waarbij $N$ de lengte is van de string `word`).

2. **Efficiëntst?**: 
   Ja.

3. **Optimalisatiemogelijkheid**: 
   De tijdscomplexiteit is al optimaal, maar de geheugenallocatie kan worden verbeterd door LINQ-methoden (`.ToList()`, `.Select()`, `string.Concat`) te vermijden. Dit voorkomt onnodige iteraties en objectcreatie. Een snellere en geheugenefficiëntere benadering maakt gebruik van een `Span<char>` of `StringBuilder` in combinatie met een simpele `for`-lus.