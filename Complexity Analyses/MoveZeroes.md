# 🧠 Complexiteitsanalyse: MoveZeroes

*Bronbestand: [MoveZeroes.cs](../Solutions/MoveZeroes.cs)*

---

### 1. Complexiteit
* **Tijdcomplexiteit**: $\mathcal{O}(n \log n)$, veroorzaakt door het intern sorteren (`OrderBy`) van de array.
* **Ruimtecomplexiteit**: $\mathcal{O}(n)$, omdat LINQ en de collection expression (`[.. ...]`) een nieuwe array in het geheugen alloceren.

### 2. Optimalisatiemogelijkheid
Ja, dit kan efficiënter. De huidige oplossing gebruikt een vergelijkingssortering, wat niet nodig is voor een partitioneringstaak als deze. 

Door een **in-place** twee-pointer aanpak te gebruiken met een enkele iteratie (`$\mathcal{O}(n)$` tijd en `$\mathcal{O}(1)$` extra ruimte buiten het resultaat), kunnen alle non-zero elementen naar voren worden geschoven en de rest met nullen worden opgevuld:

```csharp
public static int[] Solve(int[] arr)
{
    int[] result = new int[arr.Length];
    int index = 0;
    
    foreach (var num in arr)
    {
        if (num != 0) result[index++] = num;
    }
    
    return result;
}
```