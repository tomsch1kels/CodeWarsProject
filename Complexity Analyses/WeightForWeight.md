# 🧠 Complexiteitsanalyse: WeightForWeight

*Bronbestand: [WeightForWeight.cs](../Solutions/WeightForWeight.cs)*

---

1. **Complexiteit**:
   * **Tijdcomplexiteit**: $\mathcal{O}(N \cdot L \log N)$, waarbij $N$ het aantal gewichten is en $L$ de maximale lengte van een gewicht (vanwege het parsen van cijfers en het alfabetisch sorteren van strings na de primaire numerieke sort).
   * **Ruimtecomplexiteit**: $\mathcal{O}(N \cdot L)$ voor het opslaan van de gesplitste strings en de tuple-lijst.

2. **Optimalisatiemogelijkheid**:
   De huidige oplossing kan efficiënter door overbodigeallocaties en conversies te elimineren. `.Split(' ')` i.c.m. `.ToList()` creëert veel objecten op de heap. Dit kan vermeden worden door `AsSpan()` en een `ReadOnlySpan<char>` te gebruiken voor het parsen van de cijfers (zonder `mass.ToList()`) en LINQ te vervangen door een in-place array sortering met een custom `IComparer<T>`, wat de geheugenallocatie reduceert tot $\mathcal{O}(1)$ extra overhead en de snelheid aanzienlijk vergroot.