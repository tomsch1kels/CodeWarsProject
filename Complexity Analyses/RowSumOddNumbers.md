# 🧠 Complexiteitsanalyse: RowSumOddNumbers

*Bronbestand: [RowSumOddNumbers.cs](../Solutions/RowSumOddNumbers.cs)*

---

1. **Complexiteit**
   * **Tijdcomplexiteit:** $\mathcal{O}(1)$
   * **Ruimtecomplexiteit:** $\mathcal{O}(1)$

2. **Efficientst?**
   * **Ja**, deze implementatie heeft de optimaal mogelijke Big O tijdscomplexiteit ($\mathcal{O}(1)$).

3. **Optimalisatiemogelijkheid**
   * De huidige oplossing maakt gebruik van `Math.Pow`, die `double` gebruikt en daardoor een conversie (`(long)`) vereist. Dit kan micro-geoptimaliseerd worden door pure vermenigvuldiging te gebruiken om afrondingsfouten en overhead te vermijden: `n * n * n`.