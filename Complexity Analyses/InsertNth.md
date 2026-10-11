# 🧠 Complexiteitsanalyse: InsertNth

*Bronbestand: [InsertNth.cs](../Solutions/InsertNth.cs)*

---

1. **Complexiteit**: 
   - Tijd: $\mathcal{O}(n)$ (waarbij $n$ de index is waar ingevoegd moet worden).
   - Ruimte: $\mathcal{O}(1)$ (constante extra geheugenruimte).

2. **Efficiëntst?**: 
   - Ja. Voor een gekoppelde lijst (linked list) is het onmogelijk om het $n$-de element te bereiken in minder dan $\mathcal{O}(n)$ tijd, omdat willekeurige toegang (random access) ontbreekt.

3. **Optimalisatiemogelijkheid**: 
   De huidige implementatie is qua Big O optimaal. Wel kan de code iets idiomaticser en korter geschreven worden door de `head == null` check te combineren met de index-validatie en het gebruik van `throw new ArgumentOutOfRangeException()` direct te gebruiken als de lijst te kort is (in plaats van een `InvalidOperationException`), hoewel dit afhangt van de exacte kata-specificaties.