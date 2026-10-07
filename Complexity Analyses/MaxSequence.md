# 🧠 Complexiteitsanalyse: MaxSequence

*Bronbestand: [MaxSequence.cs](../Solutions/MaxSequence.cs)*

---

1. **Complexiteit**: 
   - Tijd: $\mathcal{O}(n^3)$
   - Ruimte: $\mathcal{O}(1)$

2. **Efficiëntst?**: 
   Nee.

3. **Optimalisatiemogelijkheid**: 
   De huidige oplossing berekent sommen van subarrays redundant opnieuw. Dit kan worden opgelost met het **Kadane's Algoritme**, waarmee het probleem in een enkele iteratie kan worden opgelost. Dit verlaagt de tijdscomplexiteit naar $\mathcal{O}(n)$ met behoud van een $\mathcal{O}(1)$ ruimtecomplexiteit.