# 🧠 Complexiteitsanalyse: RowSumOddNumbers

*Bronbestand: [RowSumOddNumbers.cs](../Solutions/RowSumOddNumbers.cs)*

---

1. **Complexiteit**: 
   - Tijdcomplexiteit: $\mathcal{O}(1)$
   - Ruimtecomplexiteit: $\mathcal{O}(1)$

2. **Efficiëntst?**: Ja. De oplossing maakt gebruik van een wiskundige eigenschap (de som van oneven getallen in rij $n$ is gelijk aan $n^3$) waardoor geen iteratie nodig is.

3. **Optimalisatiemogelijkheid**: De huidige oplossing is al optimaal qua Big O. Wel kan `Math.Pow` (dat `double` retourneert en een cast vereist) worden vervangen door een directe integer-vermenigvuldiging (`n * n * n`) om kleine afrondingsrisico's en overhead te vermijden, al is het effect op dit niveau verwaarloosbaar.