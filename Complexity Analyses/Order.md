# 🧠 Complexiteitsanalyse: Order

*Bronbestand: [Order.cs](../Solutions/Order.cs)*

---

### 1. Complexiteit
* **Tijdcomplexiteit**: $\mathcal{O}(N \cdot M \log K)$, waarbij $N$ het aantal woorden is, $M$ de gemiddelde lengte van een woord, en $K$ het aantal unieke woorden in de invoer. De $\log K$ factor komt door het gebruik van de `SortedDictionary`.
* **Ruimtecomplexiteit**: $\mathcal{O}(N)$, omdat er geheugen wordt gealloceerd voor de array van `words`, de `SortedDictionary` en de resulterende string.

### 2. Optimalisatiemogelijkheid
Ja, dit kan efficiënter door een `KeyValuePair<int, string>[]` of een simpele `string[]` te gebruiken in combinatie met LINQ `OrderBy` of `Array.Sort()`. 

De `SortedDictionary` voegt overhead toe vanwege de interne boomstructuur (`Red-Black tree`). Door direct te sorteren op het cijfer via LINQ (`words.Split().OrderBy(w => w.First(char.IsDigit))`), vermijd je de overhead van de dictionary en wordt de tijdcomplexiteit gereduceerd tot $\mathcal{O}(N \cdot M \log N)$, wat sneller en idiot-proof is voor deze use-case.