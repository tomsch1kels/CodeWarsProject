# 🧠 Complexiteitsanalyse: MaxSequence

*Bronbestand: [MaxSequence.cs](../Solutions/MaxSequence.cs)*

---

1. **Complexiteit**
   * Tijdsexponent: $O(n^3)$ (door drie geneste lussen die alle mogelijke subarrays en hun sommen berekenen).
   * Ruimtecomplexiteit: $O(1)$ (er wordt geen extra geheugen gebruikt dat schaalt met de invoer).

2. **Efficiëntst?**
   * **Nee**, deze implementatie heeft geen optimale tijdscomplexiteit.

3. **Optimalisatiemogelijkheid**
   * Het probleem betreft het vinden van het maximumsubarray-probleem (Maximum Subarray Sum). Dit kan optimaal worden opgelost in $O(n)$ tijd door gebruik te maken van **Kadane's Algorithm**. Hierbij itereren we eenmalig door de array en houden we de huidige som bij, waarbij we deze resetten naar 0 (of de huidige waarde) als deze negatief wordt, en tegelijkertijd het maximum bijhouden.