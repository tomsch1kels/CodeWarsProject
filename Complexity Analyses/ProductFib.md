# 🧠 Complexiteitsanalyse: ProductFib

*Bronbestand: [ProductFib.cs](../Solutions/ProductFib.cs)*

---

1. **Complexiteit**: 
   - Tijdcomplexiteit: $\mathcal{O}(\log(\text{prod}))$ (omdat Fibonacci-getallen exponentieel groeien).
   - Ruimtecomplexiteit: $\mathcal{O}(1)$.

2. **Efficiëntst?**: Ja. 
   De huidige oplossing heeft de optimale Big O tijdscomplexiteit ($\mathcal{O}(\log n)$ in verhouding tot de waarde van de invoer), aangezien we de reeks iteratief moeten genereren om het product te controleren.

3. **Optimalisatiemogelijkheid**: 
   De algoritmische complexiteit is al optimaal, maar de code kan micro-geoptimaliseerd worden. Het herhaaldelijk berekenen van `a * b` in de `if`-voorwaarde kan worden vermeden door het product één keer per iteratie op te slaan in een lokale variabele om redundante vermenigvuldigingen te elimineren.