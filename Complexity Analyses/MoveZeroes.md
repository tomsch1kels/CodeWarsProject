# 🧠 Complexiteitsanalyse: MoveZeroes

*Bronbestand: [MoveZeroes.cs](../Solutions/MoveZeroes.cs)*

---

1. **Complexiteit**: 
   - Tijd: $\mathcal{O}(n \log n)$ door het gebruik van LINQ `OrderBy`.
   - Ruimte: $\mathcal{O}(n)$ voor het creëren van de nieuwe array en de interne sorteerstructuren.

2. **Efficiëntst?**: 
   - **Nee**. Sorteren is overkill omdat we alleen de relatieve volgorde van niet-nul elementen hoeven te behouden en alle nullen naar achteren moeten verplaatsen.

3. **Optimalisatiemogelijkheid**: 
   Dit kan in $\mathcal{O}(n)$ tijd en $\mathcal{O}(n)$ ruimte met een enkelvoudige pass (Two-Pointer of een voorwaardelijke array-vulling):
   ```csharp
   public static int[] Solve(int[] arr)
   {
       int[] result = new int[arr.Length];
       int index = 0;
       foreach (int i in arr)
       {
           if (i != 0) result[index++] = i;
       }
       return result; // Resterende elementen zijn automatisch 0 in C#
   }
   ```