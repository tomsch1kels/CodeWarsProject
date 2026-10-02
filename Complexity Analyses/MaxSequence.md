# 🧠 Complexiteitsanalyse: MaxSequence

*Bronbestand: [MaxSequence.cs](../Solutions/MaxSequence.cs)*

---

### 1. Complexiteit
- **Tijdcomplexiteit:** $\mathcal{O}(n^3)$ door de drie geneste lussen.
- **Ruimtecomplexiteit:** $\mathcal{O}(1)$ aangezien er alleen constant extra geheugen wordt gebruikt.

### 2. Efficiëntst?
Nee.

### 3. Optimalisatiemogelijkheid
De huidige oplossing herberekent subgroepen onnodig vaak. Dit kan worden opgelost met het **Kadane's Algoritme**, waarmee het probleem in één enkele pass door de array kan worden opgelost. Dit verlaagt de tijdcomplexiteit naar $\mathcal{O}(n)$ met behoud van een $\mathcal{O}(1)$ ruimtecomplexiteit.