# 🧠 Complexiteitsanalyse: GreedIsGood

*Bronbestand: [GreedIsGood.cs](../Solutions/GreedIsGood.cs)*

---

1. **Complexiteit**: 
   - Tijd: $\mathcal{O}(N)$ waarbij $N$ het aantal dobbelstenen is (in de praktijk $\mathcal{O}(1)$ aangezien $N = 5$ bij deze kata).
   - Ruimte: $\mathcal{O}(1)$ door de vaste array van grootte 7.

2. **Efficiëntst?**: Ja. Een lineaire doorgang is theoretisch het minimum dat nodig is om de frequenties te tellen.

3. **Optimalisatiemogelijkheid**: De huidige implementatie is qua Big O al optimaal en zeer efficiënt. Micro-optimalisaties (zoals het vermijden van array-allocatie door een `Span<int>` of losse variabelen te gebruiken) zijn voor deze specifieke input($N=5$) niet zinvol en zouden de leesbaarheid alleen maar verminderen.