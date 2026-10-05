# 🧠 Complexiteitsanalyse: ProductFib

*Bronbestand: [ProductFib.cs](../Solutions/ProductFib.cs)*

---

1. **Complexiteit**: 
   - Tijd: $\mathcal{O}(\sqrt{\text{prod}})$ (vanwege de exponentiële groei van de Fibonacci-reeks).
   - Ruimte: $\mathcal{O}(1)$.

2. **Efficiëntst?**: 
   - Ja. Dit is de optimale Big O tijdscomplexiteit voor dit probleem, aangezien we de reeks iteratief moeten genereren om het product te vinden.

3. **Optimalisatiemogelijkheid**: 
   - De huidige implementatie berekent `a * b` twee keer per iteratie in de `if`-voorwaarde. Dit kan worden geoptimaliseerd door het product één enkele keer per iteratie in een lokale variabele op te slaan, wat overbodige vermenigvuldigingen voorkomt. Verder is de code qua datastructuur al optimaal.