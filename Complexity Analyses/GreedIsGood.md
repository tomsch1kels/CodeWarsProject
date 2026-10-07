# 🧠 Complexiteitsanalyse: GreedIsGood

*Bronbestand: [GreedIsGood.cs](../Solutions/GreedIsGood.cs)*

---

1. **Complexiteit**: 
   - Tijd: $\mathcal{O}(N)$ (waarbij $N$ het aantal dobbelstenen is, in de praktijk constant $\mathcal{O}(1)$ aangezien $N = 5$ bij deze kata).
   - Ruimte: $\mathcal{O}(1)$ (de array van vaste grootte van 7 elementen).

2. **Efficiëntst?**: 
   - Ja. De tijdscomplexiteit is optimaal omdat elk element minimaal één keer gelezen moet worden om te bepalen welke getallen er zijn.

3. **Optimalisatiemogelijkheid**: 
   - Qua Big O-complexiteit kan het niet efficiënter. Micro-optimalisaties (zoals het vermijden van array-allocatie door C# `stackalloc` of vaste variabelen te gebruiken) zijn voor deze specifieke kata niet nodig, aangezien de huidige implementatie al uiterst snel en allocatie-bewust is.