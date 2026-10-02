# 🧠 Complexiteitsanalyse: Order

*Bronbestand: [Order.cs](../Solutions/Order.cs)*

---

1. **Complexiteit**: 
   - Tijd: $\mathcal{O}(N \cdot M \log K)$ waar $N$ het aantal woorden is, $M$ de gemiddelde woordlengte en $K$ het aantal unieke woorden (vanwege de `SortedDictionary`).
   - Ruimte: $\mathcal{O}(N)$ voor de opslag in de woordenlijst en de resultaatstring.

2. **Efficiëntst?**: 
   Nee. Hoewel $\mathcal{O}(N \log N)$ theoretisch optimaal is voor vergelijkingsgebaseerd sorteren, kan het sorteren hier in $\mathcal{O}(N)$ doordat de posities (1 t/m $N$) direct als array-index kunnen dienen (Counting Sort).

3. **Optimalisatiemogelijkheid**: 
   Vervang de `SortedDictionary` door een vastberande `string[]` op basis van de lengte van de input. Door elk woord direct op de juiste index (cijfer - 1) in de array te plaatsen, elimineer je de overhead van de `SortedDictionary` en het logaritmisch sorteren. Dit brengt de tijdscomplexiteit naar de optimale $\mathcal{O}(N \cdot M)$ en vermindert gehecanoew.