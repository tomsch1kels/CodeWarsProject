# 🧠 Complexiteitsanalyse: MaxSequence

*Bronbestand: [MaxSequence.cs](../Solutions/MaxSequence.cs)*

---

# Code Analyse: MaxSequence.cs (Maximum Subarray Problem)

## 1. Overzicht & Samenvatting
Deze oplossing implementeert een brute-force algoritme om het klassieke "Maximum Subarray Problem" op te lossen (bekend van Kadane's algoritme kata's). 

De aanpak berekent expliciet de som van alle mogelijke subarrays in de array. Dit gebeurt door middel van drie geneste lussen:
1. De buitenste lus (`subsetLength`) bepaalt de lengte van de subarray (van 1 tot de lengte van de array).
2. De middelste lus (`startIndex`) bepaalt het startpunt van de subarray.
3. De binnenste lus (`currentIndex`) telt de elementen binnen de huidige subarray bij elkaar op.

Als de berekende som groter is dan de huidige `result`, wordt `result` bijgewerkt. Aan het begin is er een vroege controle of de array leeg is; in dat geval wordt direct `0` geretourneerd.

## 2. Tijdscomplexiteit (Time Complexity)
De tijdscomplexiteit van dit algoritme is **$\mathcal{O}(n^3)$** (kubische tijd), waarbij $n$ het aantal elementen in de array (`arr.Length`) is.

**Onderbouwing:**
* De buitenste lus draait $n$ keer.
* De middelste lus draait in het slechtste geval $n$ keer per iteratie van de buitenste lus.
* De binnenste lus telt elementen op en draait gemiddeld $\frac{n}{2}$ keer.
* Dit resulteert in een sommatie die wiskundig te benaderen is als $\sum_{L=1}^{n} (n - L + 1) \times L$, wat leidt tot een groeiorde van $\mathcal{O}(n^3)$. 
* Voor grote arrays ($n > 10.000$) zal dit algoritme extreem traag worden en waarschijnlijk tegen een *Time Out* aanlopen op platformen zoals Codewars.

## 3. Ruimtecomplexiteit (Space Complexity)
De ruimtecomplexiteit van dit algoritme is **$\mathcal{O}(1)$** (constante ruimte).

**Onderbouwing:**
* Het algoritme maakt geen gebruik van extra datastructuren (zoals lijsten, arrays of dictionaries) waarvan de grootte schaalt met de input $n$.
* Er wordt enkel een enkele integer (`result`, `localSum` en indexvariabelen) in het geheugen bijgehouden op de stack, ongeacht de grootte van de invoerarray.

## 4. Optimalisatie & Code Quality

### Knelpunten
* **Prestatie:** Het grootste knelpunt is de tijdscomplexiteit ($\mathcal{O}(n^3)$). Voor een 5-kyu kata is dit suboptimaal. Het probleem kan in lineaire tijd ($\mathcal{O}(n)$) worden opgelost met het *Kadane's Algoritme*.
* **Negatieve getallen:** Als de array alleen uit negatieve getallen bestaat, retourneert deze implementatie altijd `0`. Vaak is de eis bij dit probleem dat het kleinste negatieve getal (of het maximum van de lege set) wordt geretourneerd, al hangt dit af van de specifieke kata-specificatie. Kadane's algoritme kan hier flexibeler mee omgaan.

### Leesbaarheid en C#-conventies
* **Code Structuur:** De code is netjes geformatteerd, gebruikt duizend-en-een-nacht variabelennamen (`subsetLength`, `startIndex`, `currentIndex`) die de intentie goed duidelijk maken.
* **Modern C#:** Er kan gebruik worden gemaakt van vroege returns en expression-bodied members waar van toepassing, maar de leesbaarheid van de huidige control flow is an sich prima.
* **Geheugenlekken:** Er zijn geen geheugenlekken; alle gebruikte variabelen zijn value types (`int`) die op de stack leven en automatisch worden opgeruimd zodra de method scope eindigt. Er worden geen beheerde resources (managed resources) of unmanaged resources aangesproken.

### Aanbevolen Refactoring (Kadane's Algoritme - $\mathcal{O}(n)$)
Ter illustratie van een optimale oplossing, zou de code herschreven kunnen worden naar Kadane's algoritme:

```csharp
internal static class MaxSequence
{
    public static int Solve(int[] arr)
    {
        int maxSoFar = 0;
        int currentSum = 0;

        foreach (var item in arr)
        {
            currentSum = Math.Max(0, currentSum + item);
            maxSoFar = Math.Max(maxSoFar, currentSum);
        }

        return maxSoFar;
    }
}
```