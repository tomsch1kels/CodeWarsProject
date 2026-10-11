# 🧠 Complexiteitsanalyse: MaxSequence

*Bronbestand: [MaxSequence.cs](../Solutions/MaxSequence.cs)*

---

1. **Complexiteit**: 
   - Tijdcomplexiteit: $\mathcal{O}(n^3)$ door de drie geneste lussen.
   - Ruimtecomplexiteit: $\mathcal{O}(1)$ aangezien er geen extra geheugen wordt gealloceerd.

2. **Efficiëntst?**: 
   - Nee.

3. **Optimalisatiemogelijkheid**: 
   - De huidige oplossing herberekent sommen van deelverzamelingen herhaaldelijk. Dit kan optimaal worden opgelost in $\mathcal{O}(n)$ tijd en $\mathcal{O}(1)$ ruimte met het **Kadane's Algoritme**. Hierbij houdt je tijdens één enkele iteratie over de array steeds de maximum som tot het huidige element bij (`currentSum = Math.max(item, currentSum + item)`).