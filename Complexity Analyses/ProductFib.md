# 🧠 Complexiteitsanalyse: ProductFib

*Bronbestand: [ProductFib.cs](../Solutions/ProductFib.cs)*

---

1. **Complexiteit**: 
   - Tijdcomplexiteit: $\mathcal{O}(\log(\text{prod}))$ (omdat de Fibonacci-getallen exponentieel groeien).
   - Ruimtecomplexiteit: $\mathcal{O}(1)$.

2. **Efficiëntst?**: 
   Ja. Dit is de optimale Big O tijdscomplexiteit voor dit probleem, omdat we de reeks sequentiell moeten doorlopen tot het product is bereikt of overschreden.

3. **Optimalisatiemogelijkheid**: 
   Algoritmisch kan het niet efficiënter qua Big O. Wel kan de code micro-geoptimaliseerd worden door herhaalde vermenigvuldiging te minimaliseren, of door over te stappen op Binet's formule om direct naar de juiste index te springen (hoewel dit precisieproblemen kan geven met `ulong`). De huidige implementatie is echter al uitstekend leesbaar en idiomatisch voor C#.