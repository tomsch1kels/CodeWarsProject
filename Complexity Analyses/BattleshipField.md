# 🧠 Complexiteitsanalyse: BattleshipField

*Bronbestand: [BattleshipField.cs](../Solutions/BattleshipField.cs)*

---

1. **Complexiteit**: 
   - **Tijdcomplexiteit**: $\mathcal{O}(N \cdot M)$ (waarbij $N$ en $M$ de afmetingen van het veld zijn, aangezien elke cel constant aantal keer wordt bezocht).
   - **Ruimtecomplexiteit**: $\mathcal{O}(N \cdot M)$ (voor de `visited`-matrix en de opslag van schepen).

2. **Efficiëntst?**: 
   - **Ja**. Je moet theoretisch elk veld minstens één keer bekijken om te controleren of het water of een schip is, waardoor een lineaire complexiteit ten opzichte van het aantal cellen optimaal is.

3. **Optimalisatiemogelijkheid**: 
   - De huidige oplossing is asymptotisch optimaal. Kleine micro-optimalisaties (zoals het vermijden van LINQ/enumerators in hete lussen of het direct in-place markeren van het veld in plaats van een aparte `visited`-boolmatrix) kunnen geheugenallocaties en overhead iets verminderen, maar veranderen de Big O-complexiteit niet.