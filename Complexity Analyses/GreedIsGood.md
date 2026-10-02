# 🧠 Complexiteitsanalyse: GreedIsGood

*Bronbestand: [GreedIsGood.cs](../Solutions/GreedIsGood.cs)*

---

1. **Complexiteit**: 
   - Tijdslimiet/Tijdcomplexiteit: $O(1)$ (omdat de inputlengte altijd vast is op 5 dobbelstenen).
   - Ruimtecomplexiteit: $O(1)$.

2. **Efficiëntst?**: 
   - **Nee**, hoewel de huidige placeholder $O(1)$ is, levert het geen correct resultaat op. Een correcte implementatie vereist het tellen van de frequenties van de dobbelstenen.

3. **Optimalisatiemogelijkheid**: 
   - De meest efficiënte aanpak is het gebruiken van een vaste lookup-tabel of een array van grootte 7 om de frequentie van elk getal (1 t/m 6) te tellen in een enkele iteratie ($O(N)$ waarbij $N=5$, dus effectief $O(1)$). Vervolgens kan de score direct worden berekend op basis van de spelregels (bijv. `count[1] / 3` voor drievouden en `count[1] % 3` voor overige enzen).