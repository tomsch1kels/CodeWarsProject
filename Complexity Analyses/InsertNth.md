# 🧠 Complexiteitsanalyse: InsertNth

*Bronbestand: [InsertNth.cs](../Solutions/InsertNth.cs)*

---

1. **Complexiteit**: 
   - Tijd: $\mathcal{O}(n)$, waarbij $n$ de index is waar ingevoegd moet worden.
   - Ruimte: $\mathcal{O}(1)$ (constante extra geheugenruimte).

2. **Efficiëntst?**: 
   - Ja, de tijdscomplexiteit is optimaal omdat een gekoppelde lijst (linked list) nu eenmaal sequentieel doorlopen moet worden tot de gewenste index.

3. **Optimalisatiemogelijkheid**: 
   - De huidige implementatie is qua algoritme al optimaal. Wel kan de code iets vereenvoudigd en robuuster gemaakt worden door `head` direct als nieuwe startnode terug te geven wanneer `index == 0`, waardoor de `previous == null` check overbodig wordt en de intentie duidelijker is.