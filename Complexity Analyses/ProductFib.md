# 🧠 Complexiteitsanalyse: ProductFib

*Bronbestand: [ProductFib.cs](../Solutions/ProductFib.cs)*

---

1. **Complexiteit**:
   - **Tijdcomplexiteit**: $O(\log \text{prod})$ in termen van de waarde van de invoer (aangezien de Fibonacci-getallen exponentieel groeien).
   - **Ruimtecomplexiteit**: $O(1)$ (er wordt een constante hoeveelheid geheugen gebruikt).

2. **Optimalisatiemogelijkheid**:
   De huidige oplossing is al optimaal voor dit probleem wat betreft tijd- en ruimtecomplexiteit ($O(\log n)$ iteraties en $O(1)$ geheugen). Een mogelijke micro-optimalisatie is het hergebruiken van de vermenigvuldiging `a * b` om dubbele berekeningen te voorkomen, al zal dit de Big O-complexiteit niet verlagen.