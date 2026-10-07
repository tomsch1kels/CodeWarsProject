# 🧠 Complexiteitsanalyse: MaxSequence

*Bronbestand: [MaxSequence.cs](../Solutions/MaxSequence.cs)*

---

1. **Complexiteit**: 
   - Tijd: $\mathcal{O}(n^3)$
   - Ruimte: $\mathcal{O}(1)$

2. **Efficiëntst?**: 
   Nee.

3. **Optimalisatiemogelijkheid**: 
   De huidige oplossing berekent subarrays opnieuw door drie geneste lussen te gebruiken. Dit kan optimaal worden opgelost in $\mathcal{O}(n)$ tijd en $\mathcal{O}(1)$ ruimte met behulp van **Kadane's Algoritme**, door tijdens een enkele iteratie door de array steeds de maximum som van de subarray tot het huidige punt bij te houden.