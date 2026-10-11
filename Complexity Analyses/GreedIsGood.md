# 🧠 Complexiteitsanalyse: GreedIsGood

*Bronbestand: [GreedIsGood.cs](../Solutions/GreedIsGood.cs)*

---

1. **Complexiteit**: 
   - Tijd: $\mathcal{O}(N)$ (waarbij $N$ het aantal dobbelstenen is, in de praktijk constant $\mathcal{O}(1)$ aangezien $N = 5$).
   - Ruimte: $\mathcal{O}(1)$ (vaste array van grootte 7).

2. **Efficiëntst?**: 
   - Ja. De asymptotische tijds- en ruimtecomplexiteit is optimaal.

3. **Optimalisatiemogelijkheid**: 
   - De huidige implementatie is qua Big O al optimaal. Kleine micro-optimalisaties (zoals het vermplenigvuldigen van array-allocaties door een vaste array of stackalloc te gebruiken) zijn op deze schaal ($N=5$) echter overbodig en verminderen slechts de leesbaarheid. De code is reeds uitstekend en idiomatisch.