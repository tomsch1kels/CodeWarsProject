# 🧠 Complexiteitsanalyse: ProductFib

*Bronbestand: [ProductFib.cs](../Solutions/ProductFib.cs)*

---

1. **Overzicht & Samenvatting**
De aangeboden oplossing voor de "Product consecutive fib numbers" kata maakt gebruik van een iteratieve benadering om de Fibonacci-reeks te genereren en tegelijkertijd het product van twee opeenvolgende getallen ($F_n$ en $F_{n+1}$) te vergelijken met de doelwaarde (`prod`). 
De methode start met de eerste twee getallen ($0$ en $1$) en berekent in een `while (true)` loop telkens het volgende getal in de reeks. Zodra het product van de huidige twee getallen groter is dan of gelijk is aan `prod`, stopt de loop. Vervolgens wordt een array geretourneerd met de twee Fibonacci-getallen en een boolean-indicator (gecast naar `ulong` als `1UL` of `0`) die aangeeft of het product exact gelijk is aan `prod`.

2. **Tijdscomplexiteit (Time Complexity)**
* **Notatie:** $\mathcal{O}(\log(\text{prod}))$ of nauwkeuriger: lineair ten opzichte van de index $n$ van het Fibonacci-getal waarbij het product $\ge \text{prod}$.
* **Onderbouwing:** De Fibonacci-reeks groeit exponentieel (benaderd door de Gulden Snede, $\phi^n$). Omdat de reeks exponentieel groeit, groeit de index $n$ logaritmisch ten opzichte van de waarde van `prod`. In de praktijk betekent dit dat het aantal iteraties zeer klein blijft, zelfs voor grote `ulong` waarden. Binnen de loop worden enkel O(1) basisoperaties uitgevoerd (vermenigvuldiging, vergelijking en optelling).

3. **Ruimtecomplexiteit (Space Complexity)**
* **Notatie:** $\mathcal{O}(1)$
* **Onderbouwing:** Er wordt een constante hoeveelheid geheugen gebruikt. Ongeacht de grootte van `prod` worden er slechts een paar lokale variabelen (`a`, `b`, `temp`) bijgehouden. Aan het einde wordt een vaste array van 3 elementen `[a, b, success]` gealloceerd, wat eveneens neerkomt op een constante geheugencomplexiteit.

4. **Optimalisatie & Code Quality**
* **Leesbaarheid:** De code is schoon, idiomatisch C# en maakt gebruik van moderne syntax (zoals collectie-expressies `[a, b, success]` en de `ulong` suffix `1UL`). De variabelenamen zijn helder en de intentie van de code is direct duidelijk.
* **Prestaties & Knelpunten:** 
    * Er is een kleine redundantie in de berekening: `a * b` wordt tweemaal geëvalueerd binnen dezelfde iteratie als de conditie waar is (eenmaal in de `if`-check en eenmaal in de ternaire operator voor `success`). Dit kan heel eenvoudig worden geoptimaliseerd door het product op te slaan in een lokale variabele om dubbele vermenigvuldigingen te voorkomen.
    * Omdat gebruik wordt gemaakt van `ulong` (unsigned 64-bit integer), is er een risico op overflow als `prod` extreem groot is en de daadwerkelijke Fibonacci-producten de maximale waarde van `ulong` overschrijden voordat de stopconditie wordt bereikt. De kata-specificaties vallen echter binnen de grenzen waar dit voor de juiste werking niet tot ongedefinieerd gedrag leidt, maar het is wel een architectonisch aandachtspunt bij `ulong`-berekeningen.
* **Verbetervoorstel:**
  ```csharp
  ulong product = a * b;
  if (product >= prod)
  {
      ulong success = (product == prod) ? 1UL : 0;
      return [a, b, success];
  }
  ```