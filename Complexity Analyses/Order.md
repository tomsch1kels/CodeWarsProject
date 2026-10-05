# 🧠 Complexiteitsanalyse: Order

*Bronbestand: [Order.cs](../Solutions/Order.cs)*

---

### 1. Complexiteit
* **Tijdcomplexiteit:** $\mathcal{O}(N \cdot M \log N)$, waarbij $N$ het aantal woorden is en $M$ de gemiddelde lengte van een woord. Dit komt door het parsen van elk woord en het invoegen in de `SortedDictionary`.
* **Ruimtecomplexiteit:** $\mathcal{O}(N \cdot M)$, voor het opslaan van de woorden in de array en de `SortedDictionary`.

### 2. Efficiëntst?
Nee. Hoewel de tijdscomplexiteit acceptabel is, gebruikt de huidige oplossing een `SortedDictionary` wat overhead genereert door de binaire boomstructuur en boxing (door `char.IsDigit` te casten naar een `int`).

### 3. Optimalisatiemogelijkheid
Het kan efficiënter door een standaard array van vaste grootte te gebruiken in plaats van een `SortedDictionary`, aangezien de indices bekend zijn (1 tot $N$). Hierdoor vermijd je de $\mathcal{O}(\log N)$ overhead per element en kan het in $\mathcal{O}(N \cdot M)$ tijd worden opgelost:

```csharp
public static string Solve(string words)
{
    if (string.IsNullOrEmpty(words)) return string.Empty;

    string[] split = words.Split();
    string[] result = new string[split.Length];

    foreach (string word in split)
    {
        int index = word.First(char.IsDigit) - '1';
        result[index] = word;
    }

    return string.Join(" ", result);
}
```