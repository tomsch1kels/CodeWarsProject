# 🧠 Complexiteitsanalyse: DuplicateEncoder

*Bronbestand: [DuplicateEncoder.cs](../Solutions/DuplicateEncoder.cs)*

---

1. **Complexiteit**: 
   - Tijd: $\mathcal{O}(n)$ waar $n$ de lengte van de invoerstring is (meerdere iteraties, maar lineair).
   - Ruimte: $\mathcal{O}(k)$ waar $k$ het aantal unieke karakters is (voor de frequentietabel).

2. **Optimalisatiemogelijkheid**: 
   De code kan efficiënter en idiomatischer door onnodige LINQ-allocaties (`.ToList()`) te vermijden en direct te itereren over de string. Daarnaast is een `Dictionary` te zwaar voor ASCII/Unicode-karakters; een vaste `int[256]` lookup-tabel of een `Span<T>` gebaseerde aanpak vermindert geheugenallocaties en verbetert de cache-lokaliteit aanzienlijk.