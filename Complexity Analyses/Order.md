# 🧠 Complexiteitsanalyse: Order

*Bronbestand: [Order.cs](../Solutions/Order.cs)*

---

1. **Complexiteit**: 
   - **Tijd**: $\mathcal{O}(N \cdot M \log K)$ waar $N$ het aantal woorden is, $M$ de gemiddelde woordlengte (voor `char.IsDigit` en `Single`) en $K$ het aantal unieke woorden (voor de `SortedDictionary`). Omdat $K \le N$, is dit effectief $\mathcal{O}(N \cdot M \log N)$.
   - **Ruimte**: $\mathcal{O}(N)$ voor de opslag in de `SortedDictionary` en het splitsen van de string.

2. **Efficiëntst?**: 
   - **Nee**. Hoewel $\mathcal{O}(N \log N)$ acceptabel is, kan het in $\mathcal{O}(N \cdot M)$ tijd doordat sorteren niet nodig is als de posities direct in een array worden geplaatst.

3. **Optimalisatiemogelijkheid**: 
   De `SortedDictionary` (die een rode-zwartboom gebruikt met $\log K$ overhead per invoeging) kan worden vervangen door een vaste array of een `string[]` op basis van de index (1 t/m 9 volgens de kata-specificatie). Hierdoor sla je de overhead van het boom-algoritme over en bereik je lineaire tijdscomplexiteit ($\mathcal{O}(N \cdot M)$). Daarnaast is `.Single(char.IsDigit)` relatief traag en kan dit worden vereenvoudigd met een snelle karakterzoektocht of LINQ `First(char.IsDigit) - '1'`.