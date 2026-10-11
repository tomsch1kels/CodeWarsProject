# 🧠 Complexiteitsanalyse: Order

*Bronbestand: [Order.cs](../Solutions/Order.cs)*

---

1. **Complexiteit**: 
   - Tijd: $\mathcal{O}(N \cdot M \cdot \log K)$ waar $N$ het aantal woorden is, $M$ de lengte van een woord (vanwege `Single(char.IsDigit)` en string manipulatie), en $K$ het aantal unieke woorden.
   - Ruimte: $\mathcal{O}(N)$ voor de opslag in de `SortedDictionary` en de resulterende string.

2. **Efficiëntst?**: 
   Nee. Hoewel de tijdscomplexiteit acceptabel is, voegt het gebruik van een `SortedDictionary` en LINQ (`Single`, `ToArray`) onnodige overhead toe door boxing (van `char` naar `int` via `sDict[word.Single(...)]`) en boomstructuur-allocaties.

3. **Optimalisatiemogelijkheid**: 
   Het kan efficiënter door een standaard `string[]` of `KeyValuePair<int, string>[]` te gebruiken in combinatie met `Array.Sort` of LINQ's `OrderBy`. Dit vermijdt de overhead van de `SortedDictionary`. Nog sneller is het parsen van het cijfer tijdens een enkele loop over de woorden en deze direct op de juiste index in een vaste array plaatsen (aangezien de posities 1 t/m $N$ bekend zijn).