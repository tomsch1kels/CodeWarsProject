# 🧠 Complexiteitsanalyse: Order

*Bronbestand: [Order.cs](../Solutions/Order.cs)*

---

1. **Complexiteit**: 
   - **Tijd**: $\mathcal{O}(N \cdot M \log K)$ waar $N$ het aantal woorden is, $M$ de gemiddelde woordlengte en $K$ het aantal unieke woorden (vanwege de `SortedDictionary` en `char.IsDigit` per woord).
   - **Ruimte**: $\mathcal{O}(N)$ voor de opslag in de woordenboek en array.

2. **Efficiëntst?**: 
   - **Nee**. Hoewel $\mathcal{O}(N \log N)$ acceptabel is, kan het in $\mathcal{O}(N)$ tijd door een vaste array of een `Span<string>` te gebruiken op basis van de bekende index (1 t/m 9).

3. **Optimalisatiemogelijkheid**: 
   Vervang de `SortedDictionary` door een vaste array van grootte $N$ (`string[] result = new string[length]`). Omdat de cijfers altijd van 1 tot $N$ lopen, kun je het cijfer direct als array-index gebruiken (na aftrek van 1). Dit verwijdert de overhead van het sorteren en reduceert de tijdscomplexiteit naar strikt lineaire tijd $\mathcal{O}(N \cdot M)$.