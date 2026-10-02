# 🧠 Complexiteitsanalyse: MaxSequence

*Bronbestand: [MaxSequence.cs](../Solutions/MaxSequence.cs)*

---

1. **Complexiteit**: 
   - Tijd: $\mathcal{O}(n^3)$
   - Ruimte: $\mathcal{O}(1)$

2. **Efficiëntst?**: 
   - Nee. De optimale tijdscomplexiteit voor dit probleem is $\mathcal{O}(n)$.

3. **Optimalisatiemogelijkheid**: 
   - De huidige implementatie berekent sommen van subarrays redundant opnieuw met drie geneste lussen. Dit kan worden opgelost met Kadane's algoritme, waarbij de reeks in één enkele iteratie ($\mathcal{O}(n)$ tijd) wordt doorlopen door telkens de maximum som tot het huidige punt bij te houden en te resetten indien deze negatief wordt.