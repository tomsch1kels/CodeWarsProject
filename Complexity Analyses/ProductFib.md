# 🧠 Complexiteitsanalyse: ProductFib

*Bronbestand: [ProductFib.cs](../Solutions/ProductFib.cs)*

---

1. **Complexiteit**: 
   - Tijdcomplexiteit: $\mathcal{O}(\log(\text{prod}))$ (omdat Fibonacci-getallen exponentieel groeien).
   - Ruimtecomplexiteit: $\mathcal{O}(1)$.

2. **Efficientst?**: 
   Ja. De tijdscomplexiteit is optimaal omdat we de Fibonacci-reeks moeten genereren en controleren tot we het product bereiken of overschrijden. Er is geen snellere algebraïsche O-notatie mogelijk zonder over te schakelen op benaderingsformules (zoals Binet's formule), wat in C# met `ulong` precisieproblemen kan veroorzaken.

3. **Optimalisatiemogelijkheid**: 
   De huidige implementatie is algoritmisch optimaal voor `ulong`-waarden. Kleine micro-optimalisaties (zoals het vermijden van dubbele vermenigvuldiging `a * b` in de `if`-voorwaarde) zijn mogelijk door het resultaat in een lokale variabele op te slaan, maar dit verandert de Big O-complexiteit niet.