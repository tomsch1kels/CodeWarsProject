# 🧠 Complexiteitsanalyse: MaxSequence

*Bronbestand: [MaxSequence.cs](../Solutions/MaxSequence.cs)*

---

1. **Complexiteit**: 
   - Tijdcomplexiteit: $\mathcal{O}(n^3)$ door de drie geneste lussen.
   - Ruimtecomplexiteit: $\mathcal{O}(1)$ aangezien er geen extra geheugen wordt gealloceerd.

2. **Efficiëntst?**: 
   - Nee.

3. **Optimalisatiemogelijkheid**: 
   - Het probleem (Maximum Subarray Sum) kan optimaal worden opgelost in $\mathcal{O}(n)$ tijd met het **Kadane's Algoritme**. Hierbij itereren we eenmalig door de array en houden we de huidige som bij, waarbij we deze resetten naar 0 (of de waarde zelf) als deze negatief wordt, en tegelijkertijd de maximale som bijhouden.