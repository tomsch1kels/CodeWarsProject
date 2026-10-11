# 🧠 Complexiteitsanalyse: BattleshipField

*Bronbestand: [BattleshipField.cs](../Solutions/BattleshipField.cs)*

---

1. **Complexiteit**
   * **Tijdcomplexiteit:** $\mathcal{O}(N)$, waarbij $N$ het aantal cellen is in het speelveld (aangezien elke cel maximaal een constante aantal keren wordt bezocht en gecontroleerd).
   * **Ruimtecomplexiteit:** $\mathcal{O}(N)$ voor het bijhouden van de `visited`-status en het opslaan van de gevonden schepen in lijsten.

2. **Efficiëntst?**
   * **Ja**, de tijdscomplexiteit is $\mathcal{O}(N)$, wat optimaal is omdat elk element in de matrix minstens één keer gelezen moet worden om te controleren of er een schip staat.

3. **Optimalisatiemogelijkheid**
   * De huidige oplossing maakt gebruik van `bool[,] visited` waarbij de dimensies omgedraaid lijken te zijn ten opzichte van de array-indexering (`visited[position.X, position.Y]` vs `field[position.Y, position.X]`), wat cache-inefficiënties kan veroorzaken. Dit kan worden geoptimaliseerd door de dimensies van de `visited`-matrix exact gelijk te leggen aan het speelveld (`[height, width]`). Daarnaast kunnen objectallocaties (zoals records en LINQ-constructies) in de inner loops verder worden gereduceerd door primitieve datatypes te gebruiken, al heeft dit een verwaarloosbare impact op de Big O-complexiteit.