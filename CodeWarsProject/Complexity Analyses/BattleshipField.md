# 🧠 Complexiteitsanalyse: BattleshipField

*Bronbestand: [BattleshipField.cs](../Solutions/BattleshipField.cs)*

---

1. **Complexiteit**
   - **Tijdscomplexiteit**: $\mathcal{O}(N \times M)$ (waarbij $N$ de breedte en $M$ de hoogte van het veld is), omdat elke cel maximaal een constante aantal keren wordt bezocht en gecontroleerd.
   - **Ruimtecomplexiteit**: $\mathcal{O}(N \times M)$ voor het `visited`-matrix en het opslaan van de gevonden schepen.

2. **Efficiëntst?**
   - Ja. De tijdscomplexiteit van $\mathcal{O}(N \times M)$ is optimaal, aangezien elke cel in het speelveld minimaal één keer gelezen moet worden om te controleren of deze deel uitmaakt van een schip.

3. **Optimalisatiemogelijkheid**
   - Hoewel de asymptotische tijdscomplexiteit optimaal is, kan de *micro-optimalisatie* verbeterd worden. De huidige implementatie maakt intensief gebruik van LINQ (`SequenceEqual`), records, tuples en extensiemethoden (`GetNeighbour`, `GetValue`) die in hot loops extra objecttoewizingen (allocations) en method call overhead veroorzaken. Dit kan worden gereduceerd door direct op de 2D-array te itereren met primitieve datatypes, LINQ te vermijden bij frequent aangeroepen validaties, en `Direction`-switches te vervangen door platte arrays met offset-coördinaten om geheugenallocaties en garbage collection druk te minimaliseren.