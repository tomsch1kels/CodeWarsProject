# 🧠 Complexiteitsanalyse: ProductFib

*Bronbestand: [ProductFib.cs](../Solutions/ProductFib.cs)*

---

1. **Complexiteit**: 
   - Tijdcomplexiteit: $O(\sqrt{\text{prod}})$ (vanwege de exponentiële groei van de Fibonacci-reeks).
   - Ruimtecomplexiteit: $O(1)$.

2. **Efficiëntst?**: 
   - Ja. Dit is de optimale Big O tijdscomplexiteit voor dit probleem, omdat we de Fibonacci-getallen iteratief moeten genereren om het product te controleren.

3. **Optimalisatiemogelijkheid**: 
   - De huidige oplossing is al optimaal qua Big O en maakt gebruik van moderne C# collectie-expressies. Een kleine micro-optimalisatie is het hergebruiken van de berekende vermenigvuldiging (`ulong product = a * b;`) om dubbele berekeningen te voorkomen, hoewel moderne JIT-compilers dit vaak al optimaliseren.