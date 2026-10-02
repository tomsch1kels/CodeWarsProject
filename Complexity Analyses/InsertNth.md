# 🧠 Complexiteitsanalyse: InsertNth

*Bronbestand: [InsertNth.cs](../Solutions/InsertNth.cs)*

---

1. **Complexiteit**
   * **Tijdskomplexiteit:** $\mathcal{O}(n)$, waarbij $n$ de index is waar het nieuwe knooppunt moet worden ingevoegd (omdat de lijst tot aan de index moet worden doorlopen).
   * **Ruimtekomplexiteit:** $\mathcal{O}(1)$, aangezien er slechts een constant aantal extra variabelen en één nieuw knooppunt wordt gealloceerd.

2. **Efficiëntst?**
   * **Ja**, de implementatie heeft de optimale Big O tijdscomplexiteit ($\mathcal{O}(n)$) en ruimtekomplexiteit ($\mathcal{O}(1)$) die mogelijk is voor een gelinkte lijst, omdat men minimaal de eerste $n$ elementen moet passeren om de invoegpositie te bereiken.

3. **Optimalisatiemogelijkheid**
   * De huidige oplossing is qua algoritme al optimaal. Kleine code-vereenvoudigingen zijn mogelijk (zoals het direct initialiseren van `previous` in de loop of het vermijden van redundante null-checks), maar dit verandert de asymptotische efficiëntie niet.