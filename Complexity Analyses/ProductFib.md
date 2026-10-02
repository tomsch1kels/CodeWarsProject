# 🧠 Complexiteitsanalyse: ProductFib

*Bronbestand: [ProductFib.cs](../Solutions/ProductFib.cs)*

---

1. **Complexiteit**: 
   - Tijd: $O(\sqrt{\text{prod}})$ (omdat de Fibonacci-getallen exponentieel groeien en het product lineair schaalt met het kwadraat van de index).
   - Ruimte: $O(1)$.

2. **Efficientst?**: 
   - Ja, de iteratieve benadering heeft de optimale Big O tijdscomplexiteit voor dit probleem, aangezien we sequentieel door de Fibonacci-reeks moeten itereren tot we het product vinden of overschrijden.

3. **Optimalisatiemogelijkheid**: 
   - De huidige oplossing is al optimaal qua algoritme en geheugengebruik. Kleine micro-optimalisaties (zoals het vermijden van dubbele vermenigvuldigingen `a * b` door het resultaat direct op te slaan in een variabele) hebben geen invloed op de Big O-complexiteit, maar kunnen marginaal schelen in CPU-cycli.