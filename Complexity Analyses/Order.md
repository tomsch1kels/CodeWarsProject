# 🧠 Complexiteitsanalyse: Order

*Bronbestand: [Order.cs](../Solutions/Order.cs)*

---

1. **Complexiteit**: 
   - Tijd: $\mathcal{O}(n \cdot m \log k)$, waarbij $n$ het aantal woorden is, $m$ de gemiddelde lengte van een woord, en $k$ het aantal unieke woorden (vanwege het zoeken naar het cijfer via `Single` en de interne balansering van de `SortedDictionary`).
   - Ruimte: $\mathcal{O}(n \cdot m)$ voor het opslaan van de woorden in de dictionary en de resulterende array.

2. **Efficiëntst?**: 
   Nee. De tijdscomplexiteit kan worden verbeterd naar $\mathcal{O}(n \cdot m)$ door gebruik te maken van een array of een LINQ `.OrderBy()` op basis van een vooraf berekende index, in plaats van een `SortedDictionary` met `O(log k)` invoegingen per woord. Daarnaast is `word.Single(char.IsDigit)` relatief traag en allocatie-onvriendelijk; het parsen van de char naar een integer (`c - '0'`) is sneller.

3. **Optimalisatiemogelijkheid**: 
   Vervang de `SortedDictionary` door een vaste array van grootte $n$ (gebaseerd op het aantal woorden na `Split()`). Loop door de woorden, vind het cijfer direct via `char.GetNumericValue` of door de karakters te itereren, en plaats het woord direct op de juiste index in de array. Voeg de array daarna samen met `string.Join`. Dit verwijdert de overhead van de boomstructuur van de `SortedDictionary` en LINQ-operaties.