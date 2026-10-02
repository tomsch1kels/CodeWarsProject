# 🧠 Complexiteitsanalyse: DuplicateEncoder

*Bronbestand: [DuplicateEncoder.cs](../Solutions/DuplicateEncoder.cs)*

---

1. **Complexiteit**:
   - **Tijdcomplexiteit**: $\mathcal{O}(N)$ - Het woord wordt driemaal doorlopen (eenmalig voor `ToUpperInvariant`, eenmalig voor de frequentietelling via LINQ/.NET methoden, en eenmalig voor de transformatie naar het uiteindelijke resultaat), waarbij $N$ de lengte van het woord is.
   - **Ruimtecomplexiteit**: $\mathcal{O}(N)$ - De `Dictionary` slaat maximaal $N$ unieke karakters op, en de diverse LINQ-operatoren alloceren extra geheugen voor tussentijdse collecties.

2. **Optimalisatiemogelijkheid**:
   De huidige oplossing kan efficiënter door het overmatig gebruik van LINQ (`ToList()`, `ForEach`, `Select`) en het muteren van strings/collecties te vermijden. Dit kan worden opgelost door direct een `Span<char>` of `StringBuilder` te gebruiken in combinatie met een `Dictionary<char, int>` (of een vaste array van 256 integers als de tekenset beperkt is tot ASCII). Hierdoor wordt onnodige heap-allocatie voorkomen en kan de transformatie in één geheugenallocatie voor de return-string worden voltooid.