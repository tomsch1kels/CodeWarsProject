# 🧠 Complexiteitsanalyse: RowSumOddNumbers

*Bronbestand: [RowSumOddNumbers.cs](../Solutions/RowSumOddNumbers.cs)*

---

### 1. Complexiteit
* **Tijdcomplexiteit:** $\mathcal{O}(1)$ - De berekening maakt gebruik van een directe wiskundige formule die in constante tijd wordt uitgevoerd, onafhankelijk van de invoer $n$.
* **Ruimtecomplexiteit (Space):** $\mathcal{O}(1)$ - Er wordt geen extra geheugen gealloceerd; de operatie werkt volledig in-place.

### 2. Optimalisatiemogelijkheid
De huidige oplossing is **optimaal** en kan nauwelijks efficiënter. 

Hoewel `Math.Pow(n, 3)` correct werkt, retourneert deze methode een `double`. Dit vereist een `long`-cast en kan op microscopisch niveau trager zijn dan directe vermenigvuldiging. Voor absolute perfectie zou je dit kunnen herschrijven naar:

```csharp
public static long Solve(long n) => n * n * n;
``` 

Dit vermijdt drijvende-komma-berekeningen (floating-point operations) volledig, hoewel de JIT-compiler dit in de praktijk vaak al optimaliseert.