# 🧠 Complexiteitsanalyse: BattleshipField

*Bronbestand: [BattleshipField.cs](../Solutions/BattleshipField.cs)*

---

1. **Complexiteit**:
   - **Tijdscomplexiteit**: $\mathcal{O}(N)$ waarbij $N$ het aantal cellen in het speelveld is ($10 \times 10 = 100$). Elke cel wordt constant aantal keren bezocht en gecontroleerd.
   - **Ruimtecomplexiteit**: $\mathcal{O}(N)$ vanwege de `visited`-matrix van $10 \times 10$ en de lijst van gevonden schepen.

2. **Efficiëntst?**: Ja. 
   Omdat elk veld minimaal één keer gelezen moet worden om te controleren of er een schip staat, is een tijdscomplexiteit van $\mathcal{O}(N)$ asymptotisch optimaal.

3. **Optimalisatiemogelijkheid**:
   De huidige oplossing is qua Big O-notatie optimaal en gezien de vaste, zeer kleine invoer (een $10 \times 10$ speelveld bij Battleship) is micro-optimalisatie niet nodig. Wel kan de code iets efficiënter en geheugenbewuster worden gemaakt door:
   - Het vermijden van LINQ (`SequenceEqual`) en collectie-allocaties (`List<Ship>`) in de hete lus door gebruik te maken van `Span<T>` of simpele `for`-loops.
   - Het vervangen van objectallocaties zoals `Position` records door value types (`readonly struct`) of simpele `int`-coördinaten om de Garbage Collector te ontlasten (hoewel dit op een schaal van 100 cellen verwaarloosbaar is).