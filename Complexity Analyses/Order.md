# 🧠 Complexiteitsanalyse: Order

*Bronbestand: [Order.cs](../Solutions/Order.cs)*

---

1. **Complexiteit**
   - **Tijdscomplexiteit**: $\mathcal{O}(N \cdot M \log K)$ waar $N$ het aantal woorden is, $M$ de gemiddelde woordlengte en $K$ het aantal unieke woorden (vanwege het gebruik van een `SortedDictionary`).
   - **Ruimtecomplexiteit**: $\mathcal{O}(N \cdot M)$ voor het opslaan van de woorden in de dictionary en de resulterende array.

2. **Efficientst?**
   - **Nee**. Hoewel de optimale tijdscomplexiteit voor sorteerproblemen op $\mathcal{O}(N)$ ligt (omdat de posities $1$ t/m $N$ bekend en begrensd zijn), voegt `SortedDictionary` een $\log K$-factor toe door te sorteren in een binaire zoekboom.

3. **Optimalisatiemogelijkheid**
   - Omdat de sleutels opeenvolgende gehele getallen zijn van $1$ tot $N$, is sorteren via een `SortedDictionary` overbodig. 
   - Een efficiëntere aanpak is het parsen van de woorden naar een array van vaste grootte (`string[] result = new string[words.Length]`), waarbij elk woord direct op index `cijfer - 1` wordt geplaatst. Dit verlaagt de tijdscomplexiteit naar de optimale $\mathcal{O}(N \cdot M)$ en vermindert geheugenallocatie.