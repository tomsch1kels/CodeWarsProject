# 🧠 Complexiteitsanalyse: Order

*Bronbestand: [Order.cs](../Solutions/Order.cs)*

---

1. **Complexiteit**: 
   - **Tijd**: $O(N \cdot M \log K)$ waar $N$ het aantal woorden is, $M$ de gemiddelde lengte van een woord, en $K$ het aantal unieke woorden (vanwege het gebruik van `SortedDictionary`).
   - **Ruimte**: $O(N)$ voor het opslaan van de woorden in de `SortedDictionary` en de resulterende array.

2. **Efficiëntst?**: 
   - **Nee**. Hoewel $O(N \log N)$ acceptabel is, kan het theoretisch in **$O(N)$** tijd.

3. **Optimalisatiemogelijkheid**: 
   - De huidige `SortedDictionary` gebruikt een binaire zoekboom met overhead. Dit kan efficiënter door de woorden direct in een vaste array van grootte $N$ te plaatsen op basis van het gevonden cijfer (index $1$ t/m $9$). Dit vermijdt de $log K$ overhead van de boomstructuur en brengt de tijdscomplexiteit naar een strikte $O(N)$ zonder sorteren.