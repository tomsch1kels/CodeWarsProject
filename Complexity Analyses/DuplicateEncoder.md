# 🧠 Complexiteitsanalyse: DuplicateEncoder

*Bronbestand: [DuplicateEncoder.cs](../Solutions/DuplicateEncoder.cs)*

---

### 1. Complexiteit
* **Tijdcomplexiteit:** $\mathcal{O}(n)$
* **Ruimtecomplexiteit:** $\mathcal{O}(n)$

### 2. Efficiëntst?
* **Nee**, de Big O tijdscomplexiteit is optimaal ($\mathcal{O}(n)$), maar de *geheugenallocaties* en *overhead* kunnen aanzienlijk worden verminderd.

### 3. Optimalisatiemogelijkheid
De huidige implementatie maakt onnodige iteraties en objectallocaties door het gebruik van `.ToList()`, LINQ-methoden (`ForEach`, `Select`) en lambdas. Dit kan efficiënter door:
1. Een `Span<char>` of `StringBuilder` te gebruiken om linq-allocaties te vermijden.
2. Een `Dictionary` vooraf te alloceren op basis van de lengte van het woord, of beter nog: een vaste array van `int[256]` te gebruiken voor frequentietelling (aangezien het om ASCII/Unicode karakters gaat).
3. Een traditionele `foreach`-lus te gebruiken in plaats van LINQ.