# 🧠 Complexiteitsanalyse: Order

*Bronbestand: [Order.cs](../Solutions/Order.cs)*

---

### 1. Complexiteit
* **Tijdcomplexiteit:** $\mathcal{O}(N \cdot M \log N)$, waarbij $N$ het aantal woorden is en $M$ de gemiddelde lengte van een woord. De $\log N$-factor komt door het invoegen in de `SortedDictionary`, en het zoeken naar het cijfer via `word.Single(char.IsDigit)` kost $\mathcal{O}(M)$ per woord.
* **Ruimtecomplexiteit:** $\mathcal{O}(N \cdot M)$ voor het opslaan van de woorden in de `SortedDictionary` en het resultaat van `string.Split()`.

### 2. Optimalisatiemogelijkheid
Ja, dit kan efficiënter. De huidige oplossing gebruikt een `SortedDictionary` wat overhead genereert door boomstructuren en boksen van integers. Omdat de cijfers altijd van 1 tot $N$ lopen, is een vaste `string[]` of `Span<string>` op basis van indexering $\mathcal{O}(N \cdot M)$ in tijd (lineair) en vermijdt het allocaties. 

Een LINQ-alternatief zonder `SortedDictionary`:
```csharp
return string.Join(" ", words.Split()
    .OrderBy(w => w.First(char.IsDigit)));
```
Hoewel `OrderBy` nog steeds $\mathcal{O}(N \log N)$ kost, is het vaak sneller door betere cache-lokaliteit en minder overhead dan `SortedDictionary`.