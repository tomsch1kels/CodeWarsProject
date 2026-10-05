# 🧠 Complexiteitsanalyse: Order

*Bronbestand: [Order.cs](../Solutions/Order.cs)*

---

1. **Complexiteit**: 
   - Tijd: $O(N \cdot M \log K)$ waar $N$ het aantal woorden is, $M$ de gemiddelde woordlengte (voor `Single(char.IsDigit)` en `Split`), en $K$ het aantal unieke woorden (vanwege de `SortedDictionary`).
   - Ruimte: $O(N)$ voor de opslag in de `SortedDictionary` en de resulterende array.

2. **Efficiëntst?**: 
   Nee. Hoewel de tijdscomplexiteit $O(N \log N)$ benadert (wat optimaal is voor algemeen sorteren), kan het efficiënter door gebruik te maken van een vaste array in plaats van een `SortedDictionary`, aangezien de indices vooraf bekend zijn (1 t/m $N$).

3. **Optimalisatiemogelijkheid**: 
   Vervang de `SortedDictionary` door een standaard `string[]` ter grootte van het aantal woorden. Door over de woorden te itereren, het cijfer te extraheren en deze direct op index `(cijfer - 1)` in de array te plaatsen, elimineer je de overhead van de boomstructuur van de `SortedDictionary` en bereik je een ware $O(N \cdot M)$ tijdscomplexiteit.