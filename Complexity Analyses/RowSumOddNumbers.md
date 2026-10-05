# 🧠 Complexiteitsanalyse: RowSumOddNumbers

*Bronbestand: [RowSumOddNumbers.cs](../Solutions/RowSumOddNumbers.cs)*

---

1. **Complexiteit**:
   - Tijdcomplexiteit: $\mathcal{O}(1)$
   - Ruimtecomplexiteit: $\mathcal{O}(1)$

2. **Efficiëntst?**:
   - Ja, dit is de meest optimale tijdscomplexiteit die mogelijk is.

3. **Optimalisatiemogelijkheid**:
   - De huidige oplossing maakt gebruik van `Math.Pow`, wat `double` als argumenten accepteert en retourneert, gevolgd door een `long`-cast. Dit kan micro-geoptimaliseerd worden door simpele vermenigvuldiging te gebruiken om afrondingsfouten en overhead te vermijden: `n * n * n`.