# 🧠 Complexiteitsanalyse: Order

*Bronbestand: [Order.cs](../Solutions/Order.cs)*

---

1. **Complexiteit**
   - **Tijdscomplexiteit**: $\mathcal{O}(N \cdot M \log K)$, waarbij $N$ het aantal woorden is, $M$ de gemiddelde lengte van een woord, en $K$ het aantal unieke woorden (vanwege het gebruik van `SortedDictionary` en `char.IsDigit`).
   - **Ruimtecomplexiteit**: $\mathcal{O}(N \cdot M)$, voor het opslaan van de woorden in de `SortedDictionary` en het resultaat van `Split`.

2. **Efficiëntst?**
   - **Nee**. Hoewel $\mathcal{O}(N \log N)$ (of $\mathcal{O}(N)$ met een array) theoretisch mogelijk is, is de huidige implementatie sub-optimaal door de overhead van `SortedDictionary` en LINQ (`Single(char.IsDigit)`).

3. **Optimalisatiemogelijkheid**
   - De performance kan worden verbeterd door een vaste `string[]` of `Span<T>` te gebruiken in plaats van een `SortedDictionary`. Omdat de cijfers bekend en opeenvolgend zijn (1 t/m $N$), kun je de woorden direct op de juiste index in een array plaatsen op basis van het gevonden cijfer ($\mathcal{O}(N \cdot M)$ tijd). Daarnaast voorkomt het vermijden van LINQ (`Single`) extra overhead.