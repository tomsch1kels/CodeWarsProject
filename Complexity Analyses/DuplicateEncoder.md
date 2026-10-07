# 🧠 Complexiteitsanalyse: DuplicateEncoder

*Bronbestand: [DuplicateEncoder.cs](../Solutions/DuplicateEncoder.cs)*

---

### 1. Complexiteit
* **Tijdcomplexiteit**: $\mathcal{O}(N)$ waarbij $N$ de lengte is van de invoerstring (meerdere passes over de string/collectie).
* **Ruimtecomplexiteit**: $\mathcal{O}(U)$ waarbij $U$ het aantal unieke karakters is in de string (voor de `Dictionary`).

### 2. Efficiëntst?
**Nee**. Hoewel de tijdscomplexiteit $\mathcal{O}(N)$ optimaal is, kan de performance aanzienlijk verbeteren door LINQ-overhead en dubbele enumeraties te elimineren.

### 3. Optimalisatiemogelijkheid
De huidige oplossing converteert de string meermaals naar lijsten via `.ToList()` en enumereert deze herhaaldelijk. Dit kan efficiënter door:
1. **Linq vermijden**: Een `Dictionary` vullen via een traditionele `foreach`-lus over de string.
2. **Geheugentoewijzing verlagen**: Een `Span<char>` of `StringBuilder` gebruiken voor de resultaatstring in plaats van `string.Concat` met LINQ `.Select()`.