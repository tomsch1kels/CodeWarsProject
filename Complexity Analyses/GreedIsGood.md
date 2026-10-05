# 🧠 Complexiteitsanalyse: GreedIsGood

*Bronbestand: [GreedIsGood.cs](../Solutions/GreedIsGood.cs)*

---

1. **Complexiteit**: 
   - Tijd: $\mathcal{O}(N)$ waarbij $N$ het aantal dobbelstenen is (in deze kata vast $N = 5$).
   - Ruimte: $\mathcal{O}(N)$ vanwege het aanmaken van nieuwe lijsten/arrays bij het verwijderen van de triplet.

2. **Efficiëntst?**: 
   - **Nee**, hoewel de tijdscomplexiteit $\mathcal{O}(1)$ is (vanwege een vaste invoer van 5 dobbelstenen), maakt de huidige implementatie onnodige allocaties door arrays te converteren naar `List<int>` en weer terug. Dit kan volledigallocatievrij.

3. **Optimalisatiemogelijkheid**: 
   De code kan sneller en geheugen-efficiënter door *geen* arrays te hernoemen of te manipuleren, maar simpelweg één keer de frequenties van alle dobbelstenen te tellen in een array van grootte 7. Vervolgens kun je per getal direct de score berekenen (`aantal / 3 * tripletScore + aantal % 3 * singleScore`). Dit reduceert de logica tot een enkele iteratie zonder geheugenallocaties.