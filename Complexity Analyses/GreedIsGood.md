# 🧠 Complexiteitsanalyse: GreedIsGood

*Bronbestand: [GreedIsGood.cs](../Solutions/GreedIsGood.cs)*

---

1. **Complexiteit**
   - **Tijdscomplexiteit**: $\mathcal{O}(N)$ (waarbij $N$ het aantal dobbelstenen is, in de praktijk $\mathcal{O}(1)$ omdat de invoer altijd uit 5 dobbelstenen bestaat).
   - **Ruimtecomplexiteit**: $\mathcal{O}(1)$ (de array van vaste grootte van 7 elementen gebruikt constante extra ruimte).

2. **Efficiëntst?**
   - **Ja**, deze implementatie bereikt de theoretisch optimaal mogelijke tijdscomplexiteit ($\mathcal{O}(N)$), aangezien elke dobbelsteen minstens één keer gelezen moet worden om het totaal te bepalen.

3. **Optimalisatiemogelijkheid**
   - Algoritmisch gezien is het niet mogelijk om de Big O-complexiteit te verbeteren. Wel kan micro-optimalisatie worden toegepast door in plaats van een array een `Span<int>` op de stack te alloceren (`Span<int> ocurrences = stackalloc int[7];`) of een vaste tuple/variabelen-telling te gebruiken. Dit vermijdt heap-allocatie van de array, al is het effect op deze kleine schaal te verwaarlozen.