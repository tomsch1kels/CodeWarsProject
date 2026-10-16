# 🧠 Complexiteitsanalyse: Order

*Bronbestand: [Order.cs](../Solutions/Order.cs)*

---

### 1. Complexiteit
* **Tijdcomplexiteit**: $O(N \cdot M \log K)$ waar $N$ het aantal woorden is, $M$ de gemiddelde lengte van een woord, en $K$ het aantal unieke woorden (vanwege het gebruik van `SortedDictionary`).
* **Ruimtecomplexiteit**: $O(N \cdot M)$ voor het opslaan van de woorden in de `SortedDictionary` en het resultaat-array.

### 2. Efficiëntst?
Nee. Hoewel de tijdscomplexiteit $O(N \log N)$ benadert (wat theoretisch optimaal is voor algemeen sorteren), voegt `SortedDictionary` overhead toe door de binaire boomstructuur en zorgt `word.Single(char.IsDigit)` voor onnodige iteraties over elk karakter.

### 3. Optimalisatiemogelijkheid
De huidige oplossing kan efficiënter door gebruik te maken van een simpel array of een LINQ-query met `OrderBy`. Omdat de getallen altijd bekend en opeenvolgend zijn (van 1 tot $N$), is een `SortedDictionary` (die intern een gebalanceerde boom gebruikt) trager dan het direct plaatsen van elementen op index in een `string[]`. 

Een snellere en meer idiomatische aanpak:
```csharp
public static string Solve(string words)
{
    if (string.IsNullOrEmpty(words)) return string.Empty;

    return string.Join(" ", words.Split()
        .OrderBy(w => w.First(char.IsDigit)));
}
```
*Opmerking: Nog sneller kan door de woorden direct op basis van het cijfer in een vast array van grootte $N$ te plaatsen, wat $O(N \cdot M)$ tijd oplevert.*