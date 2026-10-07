# 🧠 Complexiteitsanalyse: GreedIsGood

*Bronbestand: [GreedIsGood.cs](../Solutions/GreedIsGood.cs)*

---

1. **Complexiteit**: 
   - Tijd: $\mathcal{O}(N)$ (waarbij $N$ het aantal stenen is, vast op $N = 5$).
   - Ruimte: $\mathcal{O}(1)$ (de arraygrootte is constant).

2. **Efficiëntst?**: 
   - Ja, de tijdscomplexiteit is optimaal omdat elk element minimaal één keer gelezen moet worden om het te tellen.

3. **Optimalisatiemogelijkheid**: 
   - Qua Big O is het optimaal. Micro-optimalisaties (zoals het vervangen van de array door `Span<T>` of losse variabelen om heap/stack-overhead te minimaliseren) zijn voor deze vaste invoergrootte ($5$ dobbelstenen) niet zinvol, aangezien de huidige code al zeer snel en geheugenefficiënt is.