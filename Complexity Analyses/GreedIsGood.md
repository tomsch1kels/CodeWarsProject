# 🧠 Complexiteitsanalyse: GreedIsGood

*Bronbestand: [GreedIsGood.cs](../Solutions/GreedIsGood.cs)*

---

1. **Complexiteit**: 
   - Tijdcomplexiteit: $\mathcal{O}(1)$ (omdat de inputlengte altijd vast is op 5 dobbelstenen).
   - Ruimtecomplexiteit: $\mathcal{O}(1)$.

2. **Efficiëntst?**: 
   - Nee. Hoewel de huidige placeholder $\mathcal{O}(1)$ is vanwege de vaste inputgrootte, berekent deze nog geen resultaat. Om de werkelijke logica te implementeren is een frequentietelling vereist.

3. **Optimalisatiemogelijkheid**: 
   - Tel de voorkomens van elk getal (1 t/m 6) met behulp van een vaste array van grootte 7 of `LINQ (GroupBy)`. 
   - Pas vervolgens de spelregels toe via een `switch`-expressie of array-lookups om de totaalscore in $\mathcal{O}(1)$ tijd en ruimte te berekenen zonder overbodige allocaties.