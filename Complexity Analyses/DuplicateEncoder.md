# 🧠 Complexiteitsanalyse: DuplicateEncoder

*Bronbestand: [DuplicateEncoder.cs](../Solutions/DuplicateEncoder.cs)*

---

### 1. Complexiteit
* **Tijdcomplexiteit:** $\mathcal{O}(n)$, waarbij $n$ de lengte van de string is (het doorlopen van de string en dictionary-lookups kosten lineaire tijd).
* **Ruimtecomplexiteit:** $\mathcal{O}(n)$ in het slechtste geval, omdat de dictionary alle unieke karakters van de string opslaat.

### 2. Efficiëntst?
**Ja**, de implementatie heeft de optimale Big O tijdscomplexiteit van $\mathcal{O}(n)$, omdat elk karakter minimaal gelezen moet worden om te bepalen of het uniek is.

### 3. Optimalisatiemogelijkheid
De huidige oplossing kan qua prestaties en geheugenverbruik geoptimaliseerd worden door LINQ-allocaties (`.ToList()`, `.Select()`) te vermijden en de string vooraf te scannen. Door een `Dictionary<char, int>` te vullen via een traditionele `foreach`-loop en het resultaat op te bouwen met een `Span<char>` of `StringBuilder`, vermijd je overhead van enumerators en objectallocaties op de heap.