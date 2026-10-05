# 🧠 Complexiteitsanalyse: GreedIsGood

*Bronbestand: [GreedIsGood.cs](../Solutions/GreedIsGood.cs)*

---

1. **Complexiteit**: 
   - Tijdslimiet: $\mathcal{O}(N)$ (waarbij $N$ het aantal stenen is, in dit geval vast op $N = 5$).
   - Ruimtecomplexiteit: $\mathcal{O}(1)$ (de arraygrootte is constant).

2. **Efficiëntst?**: 
   - Ja, de asymptotische tijdscomplexiteit is optimaal omdat elk element minstens één keer gelezen moet worden om te bepalen welke getallen er zijn.

3. **Optimalisatiemogelijkheid**: 
   - Hoewel de Big O-complexiteit optimaal is, kan de *micro-optimalisatie* in C# nog strakker. Omdat het om een vaste hoeveelheid van exact 5 dobbelstenen gaat, kan het declareren van een array op de heap (zelfs met target-typed `[0, ...]`) overhead veroorzaken door geheventoewijzing. Dit kan volledig worden vermeden door een vaste set variabelen (`c1` t/m `c6`) of een `stackalloc` int-array van grootte 7 te gebruiken, eventueel gecombineerd met een `switch expression` voor de scoreberekening om de leesbaarheid en JIT-inline performance te vergroten.