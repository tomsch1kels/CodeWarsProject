# 🧠 Complexiteitsanalyse: BattleshipField

*Bronbestand: [BattleshipField.cs](../Solutions/BattleshipField.cs)*

---

1. **Complexiteit**: 
   - **Tijdcomplexiteit**: $\mathcal{O}(N \cdot M)$, waarbij $N$ en $M$ de dimensies van het speelveld zijn. Elke cel wordt in de praktijk constant aantal keren bezocht en geëvalueerd.
   - **Ruimtecomplexiteit**: $\mathcal{O}(N \cdot M)$ vanwege het `visited`-matrix van booleans en het opslaan van de schepen in lijsten.

2. **Efficiëntst?**: Ja. De tijdscomplexiteit van $\mathcal{O}(N \cdot M)$ is asymptotisch optimaal omdat je elk veld minstens één keer moet bekijken om de geldigheid te garanderen.

3. **Optimalisatiemogelijkheid**: 
   De huidige oplossing is qua Big O optimaal, maar kan micro-optimalisaties ondergaan. Het `visited`-matrix gebruikt `[X, Y]` terwijl C#-arrays voor multidimensionale data sneller werken in `[Y, X]` (rij-eerst/row-major volgorde) vanwege betere cache-lokaliteit. Daarnaast kan het toewijzen van heap-allocaties (zoals records en LINQ-methoden) worden verminderd door iteratieve lussen en struct-gebaseerde coördinaten te gebruiken, wat de Garbage Collector belasting verlaagt.