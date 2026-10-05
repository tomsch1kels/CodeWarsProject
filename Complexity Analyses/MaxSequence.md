# 🧠 Complexiteitsanalyse: MaxSequence

*Bronbestand: [MaxSequence.cs](../Solutions/MaxSequence.cs)*

---

1. **Complexiteit**
   * **Tijdcomplexiteit:** $\mathcal{O}(n^3)$ door de drie geneste lussen.
   * **Ruimtecomplexiteit:** $\mathcal{O}(1)$ aangezien er geen extra geheugen wordt gealloceerd.

2. **Efficiëntst?**
   * **Nee**, de huidige implementatie is niet optimaal voor dit probleem.

3. **Optimalisatiemogelijkheid**
   * Het probleem betreft het Maximum Subarray Problem. Dit kan optimaal worden opgelost in $\mathcal{O}(n)$ tijd met het **Kadane's Algorithm**. Door in één enkele iteratie door de array te lopen en steeds de maximale som van de huidige subarray bij te houden (en te resetten als deze onder nul duikt), vervalt de noodzaak voor geneste lussen volledig.