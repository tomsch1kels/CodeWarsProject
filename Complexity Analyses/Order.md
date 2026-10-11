# 🧠 Complexiteitsanalyse: Order

*Bronbestand: [Order.cs](../Solutions/Order.cs)*

---

### 1. Complexiteit
* **Tijdcomplexiteit:** $\mathcal{O}(N \cdot M \log N)$ — waarbij $N$ het aantal woorden is en $M$ de gemiddelde lengte van een woord. Het opzoeken en invoegen in een `SortedDictionary` kost $\mathcal{O}(\log N)$ per woord, en `char.IsDigit` doorloopt het woord in $\mathcal{O}(M)$.
* **Ruimtecomplexiteit:** $\mathcal{O}(N \cdot M)$ — voor het opslaan van de woorden in de `SortedDictionary` en het resultaat-array.

### 2. Efficiëntst?
* **Nee**, de tijdscomplexiteit kan optimaler. Een `SortedDictionary` gebruikt een binaire zoekboom (RB-tree) met $\mathcal{O}(\log N)$ inserties. Dit kan in $\mathcal{O}(N)$ (lineaire tijd) door een simpel array te gebruiken, aangezien de posities vooraf bekend zijn (1 tot $N$).

### 3. Optimalisatiemogelijkheid
Vervang de `SortedDictionary<int, string>` door een vast array van grootte $N$ (`string[]`). Verdeel de woorden via `words.Split()`, bepaal het cijfer om de juiste index (`digit - '1'`) te vinden, en plaats het woord direct op die index in het array. Roep ten slotte `string.Join(" ", result)` aan. Dit verwijdert de overhead van de boomstructuur en zorgt voor een optimale $\mathcal{O}(N \cdot M)$ tijdscomplexiteit.