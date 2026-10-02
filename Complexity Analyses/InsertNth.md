# 🧠 Complexiteitsanalyse: InsertNth

*Bronbestand: [InsertNth.cs](../Solutions/InsertNth.cs)*

---

1. **Complexiteit**:
   - **Tijdcomplexiteit**: $O(n)$ in het slechtste geval, waarbij $n$ de index is, omdat de lijst tot aan de opgegeven index moet worden doorlopen.
   - **Ruimtecomplexiteit**: $O(1)$ aangezien er slechts een constante hoeveelheid extra geheugen wordt gealloceerd (voor de nieuwe `Node` en enkele pointers), ongeacht de lengte van de lijst.

2. **Optimalisatiemogelijkheid**:
   De huidige oplossing is qua tijd- en ruimtecomplexiteit al optimaal voor een gekoppelde lijst ($O(n)$ tijd, $O(1)$ ruimte). Wel kan de code iets idiomaticer en robuuster worden gemaakt door `current == null` expliciet af te vangen binnen de loop (in plaats van een `InvalidOperationException`) om zo out-of-bounds indices duidelijker af te handelen.