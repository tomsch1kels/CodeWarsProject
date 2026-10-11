# 🧠 Complexiteitsanalyse: GreedIsGood

*Bronbestand: [GreedIsGood.cs](../Solutions/GreedIsGood.cs)*

---

1. **Complexiteit**: 
   - Tijdcomplexiteit: $\mathcal{O}(n)$ (waarbij $n$ het aantal dobbelstenen is, in de praktijk een constante $\mathcal{O}(1)$ aangezien $n = 5$).
   - Ruimtecomplexiteit: $\mathcal{O}(1)$ (vaste array van grootte 7).

2. **Efficiëntst?**: 
   - Ja. Een tijdscomplexiteit van $\mathcal{O}(n)$ is optimaal omdat elk element minstens één keer gelezen moet worden om de frequenties te bepalen.

3. **Optimalisatiemogelijkheid**: 
   - De huidige implementatie is al optimaal qua asymptotische complexiteit en geheugenallocatie. Micro-optimalisaties (zoals het vermijden van array-allocatie door C# `stackalloc` of losse variabelen i.p.v. een array) zijn op deze schaal ($n=5$) verwaarloosbaar en zouden de leesbaarheid alleen maar verminderen.