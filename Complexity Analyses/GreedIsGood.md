# 🧠 Complexiteitsanalyse: GreedIsGood

*Bronbestand: [GreedIsGood.cs](../Solutions/GreedIsGood.cs)*

---

### 1. Complexiteit
* **Tijdcomplexiteit:** $\mathcal{O}(1)$ (omdat de invoerarray `dice` altijd uit een vaste grootte van 5 elementen bestaat).
* **Ruimtecomplexiteit:** $\mathcal{O}(1)$.

### 2. Efficiëntst?
* **Ja**, de huidige theoretische tijdscomplexiteit is $\mathcal{O}(1)$, wat optimaal is.

### 3. Optimalisatiemogelijkheid
De huidige implementatie is echter een stub die altijd `0` retourneert en moet nog worden geïmplementeerd. Om het daadwerkelijk uit te voeren binnen $\mathcal{O}(1)$ kun je de dobbelstenen tellen (bijv. via een array van grootte 7 of `GroupBy`) en de regels van het spel toepassen met een `switch`-expressie of `if`-statements.