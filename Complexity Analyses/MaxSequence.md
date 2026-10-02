# 🧠 Complexiteitsanalyse: MaxSequence

*Bronbestand: [MaxSequence.cs](../Solutions/MaxSequence.cs)*

---

## 1. Complexiteit
* **Tijdskomplexiteit**: $\mathcal{O}(n^3)$ door de drie geneste lussen die alle mogelijke subarrays en hun sommen berekenen.
* **Ruimtecomplexiteit**: $\mathcal{O}(1)$ aangezien er alleen constante extra geheugenruimte wordt gebruikt voor variabelen.

## 2. Optimalisatiemogelijkheid
De huidige oplossing is te traag voor grote arrays. Dit kan aanzienlijk efficiënter door gebruik te maken van **Kadane's Algorithm** (Maximum Subarray Problem). Hierbij wordt de array in een enkele pass doorlopen, waarbij de maximale som tot het huidige element dynamisch wordt bijgehouden. Dit reduceert de tijdskomplexiteit naar $\mathcal{O}(n)$ en de ruimtecomplexiteit blijft $\mathcal{O}(1)$.