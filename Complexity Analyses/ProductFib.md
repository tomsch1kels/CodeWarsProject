# 🧠 Complexiteitsanalyse: ProductFib

*Bronbestand: [ProductFib.cs](../Solutions/ProductFib.cs)*

---

1. **Complexiteit**:
   - Tijdcomplexiteit: $O(\log \text{prod})$ in termen van het aantal iteraties, aangezien Fibonacci-getallen exponentieel groeien, maar $O(\sqrt{\text{prod}})$ in verhouding tot de waarde van `prod`.
   - Ruimtecomplexiteit: $O(1)$ (constante ruimte).

2. **Efficiëntst?**: Ja. Het is onmogelijk om een betere asymptotische tijdscomplexiteit te bereiken voor dit specifieke probleem, omdat we de reeks sequensmatig moeten genereren tot het product is bereikt of overschreden.

3. **Optimalisatiemogelijkheid**: De huidige implementatie berekent het product `a * b` tweemaal per iteratie (één keer in de `if`-voorwaarde en één keer in de ternaire operator). Dit kan licht geoptimaliseerd worden door het product eenmalig per iteratie in een lokale variabele op te slaan, wat overbodige vermenigvuldigingen voorkomt.