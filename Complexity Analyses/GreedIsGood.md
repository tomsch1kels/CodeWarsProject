# 🧠 Complexiteitsanalyse: GreedIsGood

*Bronbestand: [GreedIsGood.cs](../Solutions/GreedIsGood.cs)*

---

1. **Complexiteit**: 
   - Tijdslimiet: $\mathcal{O}(1)$ (aangezien de array-grootte vast staat op 5 elementen).
   - Ruimtecomplexiteit: $\mathcal{O}(1)$.

2. **Efficiëntst?**: 
   - Nee. (Hoewel de huidige placeholder $\mathcal{O}(1)$ is, berekent deze nog geen score). Om het werkelijke probleem op te lossen, is de optimale tijdslimiet $\mathcal{O}(N)$ met $N$ als aantal dobbelstenen (of $\mathcal{O}(1)$ omdat $N=5$ vast is).

3. **Optimalisatiemogelijkheid**: 
   - Tel de frequentie van elk getal (1 t/m 6) met een array van grootte 6 of een `Dictionary`.
   - Bereken de score door eerst te controleren op drielingen (bijv. drie even getallen leveren $100 \times \text{waarde}$ op, en drie enen leveren $1000$ op) en tel daarna de resterende losse enen ($100$ p.st.) en vijven ($50$ p.st.) erbij op.