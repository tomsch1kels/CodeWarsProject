# 🧠 Complexiteitsanalyse: MaxSequence

*Bronbestand: [MaxSequence.cs](../Solutions/MaxSequence.cs)*

---

1. **Complexiteit**: 
   - Tijd: $\mathcal{O}(n^3)$
   - Ruimte: $\mathcal{O}(1)$

2. **Efficiëntst?**: 
   Nee, de huidige oplossing heeft een cubische tijdscomplexiteit terwijl het probleem lineair opgelost kan worden.

3. **Optimalisatiemogelijkheid**: 
   De oplossing kan worden geoptimaliseerd naar $\mathcal{O}(n)$ tijdscomplexiteit met behulp van **Kadane's Algoritme**. Hierbij wordt in één enkele iteratie door de array de maximum som bijgehouden door op elk punt te beslissen of het huidige element wordt toegevoegd aan de bestaande subarray of dat er een nieuwe subarray wordt gestart.