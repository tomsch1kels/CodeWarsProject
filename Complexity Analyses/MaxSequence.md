# 🧠 Complexiteitsanalyse: MaxSequence

*Bronbestand: [MaxSequence.cs](../Solutions/MaxSequence.cs)*

---

1. **Complexiteit**: 
   - Tijd: $\mathcal{O}(n^3)$
   - Ruimte: $\mathcal{O}(1)$

2. **Efficiëntst?**: 
   Nee, de huidige oplossing heeft een kubische tijdscomplexiteit, terwijl dit probleem optimaal opgelost kan worden in lineaire tijd.

3. **Optimalisatiemogelijkheid**: 
   De oplossing kan aanzienlijk efficiënter door gebruik te maken van **Kadane's Algorithm**. Door door de array te itereren en voor elk element de maximale som van de subarray die op dat punt eindigt bij te houden, wordt de tijdscomplexiteit verlaagd naar $\mathcal{O}(n)$.