# 🧠 Complexiteitsanalyse: MoveZeroes

*Bronbestand: [MoveZeroes.cs](../Solutions/MoveZeroes.cs)*

---

1. **Overzicht & Samenvatting**
De aangeboden C#-oplossing maakt gebruik van LINQ om de array te sorteren op basis van een booleaanse conditie: `i == 0`. Omdat `false` (0) in C# sorteertechnisch vóór `true` (1) komt, worden alle elementen die niet gelijk zijn aan nul naar voren geplaatst, en alle nullen naar achteren. De expressie `[.. arr.OrderBy(...)]` maakt gebruik van C# 12 collection expressions om het gesorteerde resultaat direct terug te converteren naar een nieuw `int[]`.

2. **Tijdscomplexiteit (Time Complexity)**
* **Big O-notatie:** $\mathcal{O}(n \log n)$
* **Onderbouwing:** De `OrderBy`-methode van LINQ gebruikt onder water een sorting algorithm (meestal IntroSort in moderne .NET versies) dat gemiddeld en in het slechtste geval $\mathcal{O}(n \log n)$ vergelijkingen vereist voor $n$ elementen. Dit is minder efficiënt dan een lineaire $\mathcal{O}(n)$ benadering (zoals een Two-Pointer of Single-Pass algoritme), omdat een volledige sorteeroperatie meer vergelijkingen en overhead met zich meebrengt dan strikt noodzakelijk is voor dit specifiek probleem.

3. **Ruimtecomplexiteit (Space Complexity)**
* **Big O-notatie:** $\mathcal{O}(n)$
* **Onderbouwing:** De operatie creëert een nieuwe array om de resultaten in op te slaan (`[.. ...]` operator). Daarnaast alloceert de LINQ-methode `OrderBy` interne datastructuren om de volgorde te bepalen voordat de nieuwe array wordt gevuld. Dit resulteert in een lineaire geheugencomplexiteit ten opzichte van de invoergrootte $n$.

4. **Optimalisatie & Code Quality**
* **Leesbaarheid:** De code is extreem compact en toont geavanceerde kennis van moderne C#-syntaxis (C# 12 collection expressions en expression-bodied members). Voor programmeurs die niet bekend zijn met LINQ-sorteergedrag op booleanen (`false` komt voor `true`), kan de intentie echter minder direct leesbaar zijn.
* **Prestatieknelpunten:** 
    * **Algoritmische complexiteit:** Door te sorteren is de tijdscomplexiteit $\mathcal{O}(n \log n)$ in plaats van het optimale $\mathcal{O}(n)$.
    * **Allocaties:** De LINQ-query en de conversie naar een nieuwe array genereren onnodige garbage collection (GC) druk in vergelijking met een in-place of direct geïndexeerde array-manipulatie.
* **Aanbeveling:** Voor maximale performance en idiomatische "Move Zeros" logica verdient een $\mathcal{O}(n)$ algoritme met een enkele iteratie en het invullen van een nieuwe array de voorkeur:
  ```csharp
  public static int[] Solve(int[] arr)
  {
      int[] result = new int[arr.Length];
      int index = 0;
      for (int i = 0; i < arr.Length; i++)
      {
          if (arr[i] != 0)
          {
              result[index++] = arr[i];
          }
      }
      // Resterende elementen zijn standaard 0 in een nieuwe int[]
      return result;
  }
  ```