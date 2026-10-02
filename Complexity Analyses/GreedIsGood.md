# 🧠 Complexiteitsanalyse: GreedIsGood

*Bronbestand: [GreedIsGood.cs](../Solutions/GreedIsGood.cs)*

---

1. **Complexiteit**
   - Tijdcomplexiteit: $\mathcal{O}(1)$ (aangezien de array-grootte altijd vast is op 5 elementen).
   - Ruimtecomplexiteit: $\mathcal{O}(1)$ (geen extra geheugenallocatie nodig).

2. **Efficiëntst?**
   - **Nee**, hoewel de huidige placeholder $\mathcal{O}(1)$ is door de constante invoergrootte, is de werkelijke logica nog niet geïmplementeerd. Voor een optimale oplossing moet de invoer geteld en geëvalueerd worden.

3. **Optimalisatiemogelijkheid**
   - Tel de voorkomens van elk dobbelsteennummer (1 t/m 6), bijvoorbeeld met een `int[7]` array of een frequentietabel. Pas vervolgens de spelregels toe: drielingen leveren de basispunten op (111 = 1000, 666 = 600, etc.) en overgebleven enen (100 p.st.) en vijven (50 p.st.) tellen individueel mee. Dit kan in $\mathcal{O}(N)$ tijd (waarbij $N = 5$) en $\mathcal{O}(1)$ extra ruimte worden opgelost.