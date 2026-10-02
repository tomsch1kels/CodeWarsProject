# 🧠 Complexiteitsanalyse: RowSumOddNumbers

*Bronbestand: [RowSumOddNumbers.cs](../Solutions/RowSumOddNumbers.cs)*

---

1. **Complexiteit**:
   - **Tijdcomplexeid**: $\mathcal{O}(1)$ (omdat de wiskundige machtsverheffing in constante tijd wordt uitgevoerd).
   - **Ruimtecomplexiteit**: $\mathcal{O}(1)$ (er worden geen extra datastructuren of variabelen gealloceerd).

2. **Optimalisatiemogelijkheid**:
   - De huidige oplossing is al optimaal qua complexiteit. Een micro-optimalisatie om `Math.Pow` (dat `double` gebruikt) te vermijden, is het direct vermenigvuldigen: `n * n * n`. Dit voorkomt mogelijke afrondingsfouten en is marginaal sneller.