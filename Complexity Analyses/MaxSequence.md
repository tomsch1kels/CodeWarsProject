# 🧠 Complexiteitsanalyse: MaxSequence

*Bronbestand: [MaxSequence.cs](../Solutions/MaxSequence.cs)*

---

1. **Complexiteit**: 
   - Tijd: $\mathcal{O}(n^3)$
   - Ruimte: $\mathcal{O}(1)$

2. **Efficiëntst?**: 
   Nee, de huidige implementatie is niet optimaal.

3. **Optimalisatiemogelijkheid**: 
   De oplossing kan worden geoptimaliseerd naar een $\mathcal{O}(n)$ tijdscomplexiteit met behulp van **Kadane's Algoritme**. Hierbij wordt de array in één enkele pass doorlopen door op elk punt de maximale som van de subarray tot dan toe bij te houden.