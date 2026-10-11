# 🧠 Complexiteitsanalyse: Order

*Bronbestand: [Order.cs](../Solutions/Order.cs)*

---

### 1. Complexiteit
* **Tijdcomplexiteit:** $\mathcal{O}(N \cdot M \log N)$ — waarbij $N$ het aantal woorden is en $M$ de gemiddelde lengte van een woord. De $\log N$ komt door het invoegen in de `SortedDictionary`, en het zoeken naar het cijfer via `word.Single(char.IsDigit)` kost $\mathcal{O}(M)$ per woord.
* **Ruimtecomplexiteit:** $\mathcal{O}(N \cdot M)$ — voor het opslaan van de woorden in de `SortedDictionary` en het resultaat van `Split()`.

### 2. Efficiëntst?
* **Nee**, hoewel de tijdscomplexiteit voor een vergelijkingsgebaseerde sorteermethode optimaal is ($\mathcal{O}(N \log N)$), kan het sneller in $\mathcal{O}(N)$ doordat de posities (1 t/m $N$) direct bekend zijn.

### 3. Optimalisatiemogelijkheid
De huidige `SortedDictionary` en LINQ-operaties (`Single(char.IsDigit)`) overhead introduceren. Dit kan efficiënter door een standaard array van vaste grootte te gebruiken. Omdat de posities genummerd zijn van 1 tot $N$, kun je direct op basis van het gevonden cijfer (minus 1) het woord op de juiste index in een array plaatsen. Dit verwijdert de $\log N$ sorteer-overhead en LINQ-allocaties, wat resulteert in een $\mathcal{O}(N)$ tijdscomplexiteit en minder geheugenallocatie.