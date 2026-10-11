# 🧠 Complexiteitsanalyse: BattleshipField

*Bronbestand: [BattleshipField.cs](../Solutions/BattleshipField.cs)*

---

1. **Complexiteit**: 
   - **Tijdcomplexiteit**: $\mathcal{O}(N \times M)$ (waarbij $N$ en $M$ de dimensies van het veld zijn), omdat elke cel in het speelveld constant aantal keer wordt bezocht en gecontroleerd.
   - **Ruimtecomplexiteit**: $\mathcal{O}(N \times M)$ vanwege de `visited`-matrix en de opslag van gedetecteerde schepen.

2. **Efficiëntst?**: 
   - **Ja**, de asymptotische tijdscomplexiteit is optimaal ($\mathcal{O}(V)$ met $V$ het aantal cellen), aangezien elk element minimaal één keer moet worden geïspekteerd om een geldig vlootbestand te garanderen.

3. **Optimalisatiemogelijkheid**: 
   - De huidige oplossing is qua algoritme al optimaal. Kleine micro-optimalisaties zijn mogelijk door overbodige objectallocaties (zoals records en LINQ-aanroepen binnen de inner loops) te verminderen, en de `visited`-matrix direct op het `int[,]`-veld bij te houden (bijv. door cellen te muteren of bitwise flags te gebruiken) om extra geheugenallocatie voor een aparte `bool[,]` te elimineren.