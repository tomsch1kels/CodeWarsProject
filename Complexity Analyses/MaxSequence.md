# 🧠 Complexiteitsanalyse: MaxSequence

*Bronbestand: [MaxSequence.cs](../Solutions/MaxSequence.cs)*

---

### 1. Complexiteit
* **Tijdcomplexiteit**: $\mathcal{O}(n^3)$ door de drie geneste lussen die alle mogelijke deelverzamelingen genereren en sommeren.
* **Ruimtecomplexiteit**: $\mathcal{O}(1)$ omdat er geen extra geheugen wordt gealloceerd buiten een enkele variabelen.

### 2. Optimalisatiemogelijkheid
Ja, dit kan aanzienlijk efficiënter. Het betreft het klassieke *"Maximum Subarray Problem"*, dat optimaal opgelost kan worden met **Kadane's Algorithm**. 

Door over de array te itereren en voor elk element de maximale som tot dat punt bij te houden (waarbij negatieve lopende sommen worden gereset naar nul), reduceer je de tijdcomplexiteit naar $\mathcal{O}(n)$ en blijft de ruimtecomplexiteit $\mathcal{O}(1)$.