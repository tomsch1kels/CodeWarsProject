# 🧠 Complexiteitsanalyse: InsertNth

*Bronbestand: [InsertNth.cs](../Solutions/InsertNth.cs)*

---

1. **Complexiteit**:
   - **Tijdskomplexiteit**: $\mathcal{O}(N)$, waarbij $N$ de index is waar het nieuwe element wordt ingevoegd, omdat de lus $index$ keer doorloopt.
   - **Ruimtekomplexiteit**: $\mathcal{O}(1)$, er wordt constant extra geheugen gebruikt (alleen de nieuwe node).

2. **Efficiëntst?**:
   - **Ja**, de algoritmische tijdscomplexiteit is optimaal ($\mathcal{O}(N)$), aangezien je een gelinkte lijst nu eenmaal sequentieel moet doorlopen tot de gevraagde index.

3. **Optimalisatiemogelijkheid**:
   - De code kan iets cleaner en idiomatischer door de `previous`-pointer weg te laten. Omdat je `current` iteratief verplaatst, kun je ook direct op `current.next` werken of de `for`-lus herschrijven om direct op het niveau van `current` te muteren, al verandert dit de Big-O niet. Het gebruik van moderne C#-features zoals pattern matching kan de leesbaarheid verder vergroten.