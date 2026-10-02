# 🧠 Complexiteitsanalyse: MaxSequence

*Bronbestand: [MaxSequence.cs](../Solutions/MaxSequence.cs)*

---

1. **Complexiteit**: 
   - Tijd: $\mathcal{O}(n^3)$
   - Ruimte: $\mathcal{O}(1)$

2. **Efficiëntst?**: 
   Nee, de huidige implementatie heeft geen optimale tijdscomplexiteit.

3. **Optimalisatiemogelijkheid**: 
   Het probleem (Maximum Subarray Sum) kan optimaal worden opgelost in $\mathcal{O}(n)$ tijd door gebruik te maken van Kadane's Algoritme. Hierbij wordt de array in één enkele iteratie doorlopen, waarbij steeds de maximum som tot het huidige element wordt bijgehouden (`Math.Max(currentSum + x, x)`), waardoor overbodige geneste lussen voor deelverzamelingen overbodig zijn.