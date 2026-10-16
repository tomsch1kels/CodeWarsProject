# 🧠 Complexiteitsanalyse: Unlock

*Bronbestand: [Unlock.cs](../CodeWarsProject/Solutions/Unlock.cs)*

---

### 1. Complexiteit
* **Tijdcomplexiteit**: $O(B^L \cdot L)$, waarbij $B$ de maximale vertakkingsfactor is (gemiddeld $\approx 5$) en $L$ de lengte van het patroon (`numberOfNodesToVisit`). In de worst-case ($\text{lengte } 9$) is dit beperkt door het totale aantal mogelijke geldige unlock-patronen (ongeveer $3.89 \times 10^5$ operaties).
* **Ruimtecomplexiteit**: $O(L)$ voor de recursieve callstack en de `visitedNodes`-lijst, plus een constante factor voor de graaf-representatie ($O(N)$ waarbij $N = 9$).

### 2. Efficiëntst?
**Nee**. Hoewel de asymptotische tijdcomplexiteit voor dit specifieke begrensde probleem ($3 \times 3$ grid) snel genoeg is om te slagen op Codewars, herhaalt de huidige recursie identieke deelproblemen niet. Met *Memoization* (of dynamisch programmeren i.c.m. bitmasks) kan het aantal recursieve aanroepen drastisch worden verlaagd, omdat de volgorde van bezochte knopen vaak niet uitmaakt, enkel de verzameling reeds bezochte knopen en de huidige eindknoop.

### 3. Optimalisatiemogelijkheid
De huidige implementatie gebruikt een `List<int>` voor `visitedNodes`, wat overhead veroorzaakt bij het toevoegen, verwijderen en `Contains`-zoekopdrachten. 
Dit kan aanzienlijk efficiënter door:
1. **Bitwise Operations**: Vervang `List<int> visited` door een integer bitmask (`int visitedMask`). Dit maakt het bijhouden en controleren van bezochte knopen $O(1)$ en allocatievrij.
2. **Memoization**: Cache resultaten op basis van `(int currentNode, int visitedMask, int remainingLength)` om dubbele berekeningen in symmetrische of reeds doorzochte takken te elimineren.