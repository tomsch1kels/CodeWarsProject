# 🧠 Complexiteitsanalyse: MaxSequence

*Bronbestand: [MaxSequence.cs](../Solutions/MaxSequence.cs)*

---

1. **Complexiteit**: 
   - Tijd: $\mathcal{O}(n^3)$
   - Ruimte: $\mathcal{O}(1)$

2. **Efficiëntst?**: 
   - Nee.

3. **Optimalisatiemogelijkheid**: 
   De huidige oplossing berekent overlappende deelverzamelingen steeds opnieuw. Dit kan optimaal worden opgelost in $\mathcal{O}(n)$ tijd met het **Kadane's Algoritme**. Hierbij itereren we slechts één keer door de array, waarbij we per stap de maximale som van de subarray tot dat punt bijhouden en eventueel resetten als deze onder nul duikt.