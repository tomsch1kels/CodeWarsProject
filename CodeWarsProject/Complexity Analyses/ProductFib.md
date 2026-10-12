# 🧠 Complexiteitsanalyse: ProductFib

*Bronbestand: [ProductFib.cs](../Solutions/ProductFib.cs)*

---

1. **Complexiteit**: 
   - Tijdcomplexiteit: $\mathcal{O}(\log(\text{prod}))$ in termen van de waarde van `prod` (aangezien Fibonacci-getallen exponentieel groeien).
   - Ruimtecomplexiteit: $\mathcal{O}(1)$.

2. **Efficiëntst?**: 
   - **Ja**, de tijdscomplexiteit is optimaal. Het iteratief genereren van opeenvolgende Fibonacci-getallen is noodzakelijk omdat we het exacte product en de grenswaarde moeten bepalen.

3. **Optimalisatiemogelijkheid**: 
   - De huidige implementatie berekent het product `a * b` tweemaal in de `if`-voorwaarde. Dit kan micro-geoptimaliseerd worden door het product één keer op te slaan in een lokale variabele om redundante vermenigvuldigingen te vermijden. Daarnaast kan `ulong` overflowrisico geven bij extreem grote inputs, al is dat inherent aan de limieten van het type binnen deze kata.