# 🧠 Complexiteitsanalyse: GreedIsGood

*Bronbestand: [GreedIsGood.cs](../Solutions/GreedIsGood.cs)*

---

1. **Complexiteit**: 
   - Tijdcomplexiteit: $\mathcal{O}(n)$ (waarbij $n$ het aantal dobbelstenen is, in de praktijk $\mathcal{O}(1)$ aangezien $n$ altijd vast 5 is bij deze kata).
   - Ruimtecomplexiteit: $\mathcal{O}(1)$ (het `ocurrences` array heeft een vaste grootte van 7).

2. **Efficiëntst?**: 
   - Ja. De implementatie bereikt de optimaal mogelijke Big O-tijdscomplexiteit ($\mathcal{O}(n)$), omdat elke dobbelsteen minimaal één keer gelezen moet worden om de waarde te bepalen.

3. **Optimalisatiemogelijkheid**: 
   - Hoewel de Big O-complexiteit optimaal is, kan micro-optimalisatie worden toegepast door geheugenallocatie van het array (`new int[]`) te vermijding via een `stackalloc int[7]` of vaste variabelen, en door haakjes en integer-delingen te vereenvoudigen. Voor de vaste invoer van 5 dobbelstenen is de huidige code echter al uitstekend leesbaar en snel genoeg.