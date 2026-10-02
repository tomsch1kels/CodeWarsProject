# 🧠 Complexiteitsanalyse: RowSumOddNumbers

*Bronbestand: [RowSumOddNumbers.cs](../Solutions/RowSumOddNumbers.cs)*

---

1. **Complexiteit**:
   - Tijdcomplexiteit: $\mathcal{O}(1)$
   - Ruimtecomplexiteit: $\mathcal{O}(1)$

2. **Efficiëntst?**:
   - Ja, dit is de meest optimale Big O tijdscomplexiteit die mogelijk is.

3. **Optimalisatiemogelijkheid**:
   - De huidige oplossing is al optimaal. Echter, in plaats van `Math.Pow(n, 3)` (wat `double` als input accepteert en een `double` retourneert) zou je puur vermenigvuldiging kunnen gebruiken om afrondingsfouten en overhead te voorkomen: `n * n * n`. Voor `long` is dit echter te verwaarlozen.