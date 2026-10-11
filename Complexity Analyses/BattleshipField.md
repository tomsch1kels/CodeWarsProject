# 🧠 Complexiteitsanalyse: BattleshipField

*Bronbestand: [BattleshipField.cs](../Solutions/BattleshipField.cs)*

---

1. **Complexiteit**: 
   - Tijd: $\mathcal{O}(N \times M)$ waarbij $N$ en $M$ de dimensies van het veld zijn (elke cel wordt maximaal een constante aantal keren bezocht).
   - Ruimte: $\mathcal{O}(N \times M)$ voor het `visited`-matrix en de opslag van de gevonden schepen.

2. **Efficiëntst?**: 
   - **Ja**, de tijdscomplexiteit van $\mathcal{O}(N \times M)$ is optimaal omdat elk element in het bord minimaal één keer gelezen moet worden om de geldigheid te garanderen.

3. **Optimalisatiemogelijkheid**: 
   - Hoewel de Big O-complexiteit optimaal is, kan de *constante factor* en het geheugenverbruik worden verbeterd door de `visited`-matrix weg te laten. Omdat schepen lineair worden afgegaan en ongeldige configuraties direct falen, kan het bijhouden van bezochte cellen worden overbodig gemaakt door gedetecteerde schepen direct op een kopie van het veld of in-place te markeren (bijv. waardes `1` naar `0` of `-1` veranderen), wat ook `List<Ship>` allocaties vermindert.