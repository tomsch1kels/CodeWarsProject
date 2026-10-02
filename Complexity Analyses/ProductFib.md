# 🧠 Complexiteitsanalyse: ProductFib

*Bronbestand: [ProductFib.cs](../Solutions/ProductFib.cs)*

---

1. **Complexiteit**: 
   - Tijdcomplexiteit: $\mathcal{O}(\log(\text{prod}))$ (omdat de Fibonacci-getallen exponentieel groeien).
   - Ruimtecomplexiteit: $\mathcal{O}(1)$.

2. **Efficiëntst?**: 
   - Ja. Een lineaire of sub-lineaire doorloop van de Fibonacci-reeks is theoretisch het optimaalst voor dit probleem, aangezien de reeks opeenvolgend gegenereerd moet worden om het product te controleren.

3. **Optimalisatiemogelijkheid**: 
   - De huidige implementatie is qua Big O al optimaal en zeer efficiënt. Een kleine micro-optimalisatie is het hergebruiken van de berekende vermenigvuldiging (`ulong product = a * b;`) zodat deze niet dubbel wordt berekend in de `if`-voorwaarde. Verder is er geen fundamentele versnelling mogelijk zonder geavanceerde wiskundige benaderingen (zoals Binet's formule), die bij `ulong` echter leiden tot afrondingsfouten.