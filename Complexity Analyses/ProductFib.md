# 🧠 Complexiteitsanalyse: ProductFib

*Bronbestand: [ProductFib.cs](../Solutions/ProductFib.cs)*

---

1. **Complexiteit**: 
   - Tijdcomplexiteit: $\mathcal{O}(\log(\text{prod}))$ (omdat Fibonacci-getallen exponentieel groeien).
   - Ruimtecomplexiteit: $\mathcal{O}(1)$.

2. **Efficiëntst?**: Ja. De tijdscomplexiteit is optimaal omdat elk opeenvolgend Fibonacci-getal gegenereerd moet worden om het product te vergelijken met de invoer.

3. **Optimalisatiemogelijkheid**: De algoritmische complexiteit kan niet verder omlaag. Wel kan de code micro-geoptimaliseerd worden door redundante vermenigvuldigingen te elimineren (`ulong product = a * b;`) om dubbele berekeningen binnen de `if`-voorwaarde te voorkomen.