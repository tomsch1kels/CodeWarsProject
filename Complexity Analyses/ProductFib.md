# 🧠 Complexiteitsanalyse: ProductFib

*Bronbestand: [ProductFib.cs](../Solutions/ProductFib.cs)*

---

1. **Complexiteit**: 
   - Tijdcomplexiteit: $\mathcal{O}(\log(\text{prod}))$ (omdat Fibonacci-getallen exponentieel groeien).
   - Ruimtecomplexiteit: $\mathcal{O}(1)$.

2. **Efficiëntst?**: 
   Ja. De tijdscomplexiteit is optimaal omdat we de Fibonacci-reeks iteratief moeten doorlopen tot we het product bereiken of overschrijden.

3. **Optimalisatiemogelijkheid**: 
   De huidige implementatie is al optimaal qua Big O en gebruikt geen overbodige geheugenallocaties. Een kleine micro-optimalisatie is het hergebruiken van de vermenigvuldiging `a * b` om dubbele berekeningen in de `if`-voorwaarde te voorkomen, al zal de JIT-compiler dit waarschijnlijk al optimaliseren.