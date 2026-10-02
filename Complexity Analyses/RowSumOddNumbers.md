# 🧠 Complexiteitsanalyse: RowSumOddNumbers

*Bronbestand: [RowSumOddNumbers.cs](../Solutions/RowSumOddNumbers.cs)*

---

# Analyse van RowSumOddNumbers (C#)

## 1. Overzicht & Samenvatting
De aangeboden oplossing maakt gebruik van een wiskundige eigenschap in plaats van een iteratieve benadering. In een driehoek van oneven getallen (waarbij rij 1 de som 1 heeft, rij 2 de som 3+5=8, rij 3 de som 7+9+11=27, etc.) is de som van de getallen in de $n$-de rij exact gelijk aan $n$ tot de macht 3 ($n^3$). 

De implementatie cast de invoer naar `long` en gebruikt `Math.Pow(n, 3)` om dit direct te berekenen. (Hoewel `Math.Pow` `double` retourneert, wordt dit expliciet gecast naar `long`).

## 2. Tijdscomplexiteit (Time Complexity)
* **Big O-notatie:** $\mathcal{O}(1)$ (Constante tijd)

**Onderbouwing:**
De berekening voert een enkele wiskundige machtsverheffing uit. Het aantal operaties is onafhankelijk van de grootte van invoerparameter `n`. Of `n` nu 1 is of $10^9$, de uitvoeringstijd blijft constant.

## 3. Ruimtecomplexiteit (Space Complexity)
* **Big O-notatie:** $\mathcal{O}(1)$ (Constante ruimte)

**Onderbouwing:**
Er worden geen datastructuren (zoals arrays, lijsten of woordenboeken) aangemaakt waarvan de grootte schaalt met de invoer. Er wordt enkel een primitive type (`long`) gebruikt in het geheugen, wat resulteert in een constant geheugenverbruik.

## 4. Optimalisatie & Code Quality
De code is uiterst concies en elegant vanwege de keuze voor de wiskundige shortcut in plaats van een brute-force simulatie ($\mathcal{O}(n^2)$). Toch zijn er vanuit architecturaal en performance-oogpunt twee kleine kanttekeningen te plaatsen bij de huidige implementatie:

1. **Gebruik van `Math.Pow`:** `Math.Pow(double, double)` werkt met drijvende-kommagetallen (`double`). Dit kan bij zeer grote getallen leiden tot afrondingsfouten (precision loss), hoewel dit voor typische Codewars-tests en `long`-waarden binnen de grenzen meestal goed gaat. 
2. **Performance en typecasting:** Omdat `Math.Pow` doubles gebruikt en er gecast moet worden naar `long`, is het efficiënter om een pure integer-vermenigvuldiging te gebruiken.

### Verbetervoorstel
Door vermenigvuldiging te gebruiken, vermijd je de overhead van `Math.Pow` en mogelijke afrondingsfouten met `double`:

```csharp
internal static class RowSumOddNumbers
{
    public static long Solve(long n) => n * n * n;
}
```

Dit behoudt de $\mathcal{O}(1)$ complexiteit, is leesbaarder, sneller en werkt volledig binnen het integer-domein.