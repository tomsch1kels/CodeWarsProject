# 🧠 Complexiteitsanalyse: RowSumOddNumbers

*Bronbestand: [RowSumOddNumbers.cs](../Solutions/RowSumOddNumbers.cs)*

---

1. **Complexiteit**: 
   - Tijdcomplexiteit: $\mathcal{O}(1)$
   - Ruimtecomplexiteit: $\mathcal{O}(1)$

2. **Efficiëntst?**: Ja. De oplossing maakt gebruik van een wiskundige eigenschap (de som van oneven getallen in rij $n$ is gelijk aan $n^3$) waardoor er geen iteraties nodig zijn.

3. **Optimalisatiemogelijkheid**: De huidige oplossing is al optimaal qua Big O. Wel kan een kleine micro-optimalisatie worden toegepast door `Math.Pow` (die `double` gebruikt en daardoor afrondingsfouten of conversieoverhead kan geven) te vervangen door een directe vermenigvuldiging: `n * n * n`.