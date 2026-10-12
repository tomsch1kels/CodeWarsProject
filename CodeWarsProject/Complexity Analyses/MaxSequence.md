# 🧠 Complexiteitsanalyse: MaxSequence

*Bronbestand: [MaxSequence.cs](../Solutions/MaxSequence.cs)*

---

1. **Complexiteit**: 
   - Tijdskomplexiteit: $\mathcal{O}(n^3)$ (door de drie geneste lussen).
   - Ruimtecomplexiteit: $\mathcal{O}(1)$ (er wordt geen extra geheugen gealloceerd).

2. **Efficiëntst?**: 
   - Nee.

3. **Optimalisatiemogelijkheid**: 
   De huidige oplossing herberekent sommen voor subarrays herhaaldelijk. Dit kan worden opgelost met **Kadane's Algorithm**, waarmee het probleem in een enkele iteratie kan worden opgelost. Hierdoor verbetert de tijdscomplexiteit van $\mathcal{O}(n^3)$ naar $\mathcal{O}(n)$, terwijl de ruimtecomplexiteit $\mathcal{O}(1)$ blijft. 

   *Voorbeeld:*
   ```csharp
   int maxSoFar = 0, currentSum = 0;
   foreach (int x in arr) {
       currentSum = Math.Max(0, currentSum + x);
       maxSoFar = Math.Max(maxSoFar, currentSum);
   }
   return maxSoFar;
   ```