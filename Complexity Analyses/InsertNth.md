# 🧠 Complexiteitsanalyse: InsertNth

*Bronbestand: [InsertNth.cs](../Solutions/InsertNth.cs)*

---

1. **Complexiteit**: 
   - Tijd: $\mathcal{O}(n)$ (waarbij $n$ de index is, omdat we door de lijst moeten itereren tot de gewenste positie).
   - Ruimte: $\mathcal{O}(1)$ (er wordt slechts één nieuw `Node`-object gealloceerd, ongeacht de grootte van de lijst).

2. **Efficiëntst?**: 
   - Ja. Om het $n$-de element in een gelinkte lijst te bereiken en te wijzigen, is een lineaire doorzoeking onvermijdelijk.

3. **Optimalisatiemogelijkheid**: 
   - De huidige implementatie is qua Big O al optimaal. Wel kan de code iets vereenvoudigd worden door overbodige null-checks te reduceren (bijv. door de `head == null` check te combineren met de index-loop of door gebruik te maken van een patroonmatching/pointer-benadering), wat micro-optimalisaties in leesbaarheid oplevert.