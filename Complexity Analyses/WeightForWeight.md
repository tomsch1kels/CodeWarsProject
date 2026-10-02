# 🧠 Complexiteitsanalyse: WeightForWeight

*Bronbestand: [WeightForWeight.cs](../Solutions/WeightForWeight.cs)*

---

1. **Complexiteit**: 
   - Tijd: $O(N \cdot M \log N)$ waarbij $N$ het aantal gewichten is en $M$ de maximale lengte van een getal (vanwege string-conversies, sommatie en lexicografische sortering).
   - Ruimte: $O(N \cdot M)$ voor het opslaan van de tuples en de gesplitste strings in lijsten.

2. **Efficiëntst?**: 
   Nee. Hoewel de tijdscomplexiteit qua $N$ optimaal is voor vergelijkingssortering ($O(N \log N)$), bevat de huidige implementatie veel overbodige geheugenallocaties en redundante berekeningen.

3. **Optimalisatiemogelijkheid**: 
   De code kan efficiënter door het gebruik van LINQ te verminderen om allocaties te voorkomen. 
   - Vervang `strng.Split(' ')` door een span-gebaseerde paring of `StringTokenizer`.
   - Bereken de gewichtssom direct via een `for`-loop over de karakters van de string (zonder `.ToList()` en `.Sum()`).
   - Sorteer een array van structs i.p.v. tuples om 'boxing' en overhead te vermijden, of gebruik een custom `IComparer<string>` die het cijfergewicht on-the-fly berekent en vergelijkt (waardoor de opslag van het berekende gewicht overbodig wordt).