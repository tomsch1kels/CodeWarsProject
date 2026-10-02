# 🧠 Complexiteitsanalyse: GreedIsGood

*Bronbestand: [GreedIsGood.cs](../Solutions/GreedIsGood.cs)*

---

1. **Complexiteit**: 
   - **Tijd**: $O(1)$ (omdat de array altijd uit exact 5 elementen bestaat).
   - **Ruimte**: $O(1)$ (geen extra geheugentoewijzing nodig).

2. **Optimalisatiemogelijkheid**: 
   De huidige stub retourneert altijd `0`. Om het probleem te oplossen kan een frequentie-array of hashtable (grootte 1 t/m 6) worden gebruikt om het aantal ogen te tellen in $O(1)$ tijd, waarna de score volgens de kata-regels in een vaste serie `if`-statements of een `switch`-expressie wordt berekend. Verdere optimalisatie is niet nodig gezien de vaste invoergrootte.