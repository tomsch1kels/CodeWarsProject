# 🧠 Complexiteitsanalyse: InsertNth

*Bronbestand: [InsertNth.cs](../Solutions/InsertNth.cs)*

---

### 1. Complexiteit
* **Tijdcomplexiteit:** $\mathcal{O}(n)$, waarbij $n$ de index is waar de node moet worden ingevoegd. In het slechtste geval moet de lijst tot index $ اکرم $ worden doorlopen.
* **Ruimtecomplexiteit:** $\mathcal{O}(1)$, aangezien er slechts één nieuwe node wordt gealloceerd en er een constant aantal pointers wordt gebruikt (geen extra datastructuren).

### 2. Efficiëntst?
**Ja**, de implementatie heeft de optimale Big O tijdscomplexiteit ($\mathcal{O}(n)$) en ruimtecomplexiteit ($\mathcal{O}(1)$) die theoretisch mogelijk is voor een gekoppelde lijst (linked list) op willekeurige indexen.

### 3. Optimalisatiemogelijkheid
De huidige oplossing is algoritmisch optimaal, maar de code kan worden gestroomlijnd en versneld door onnodige null-checks te vermijden. De `current ?? throw...` check binnen de lus is overbodig als de index buiten de geldige bereik van de lijst valt (in veel Codewars-katas wordt aangenomen dat de index geldig is of wordt een `ArgumentOutOfRangeException` verwacht). Daarnaast kan de code compacter door direct op de `head` te werken en de `previous`-pointer te elimineren door de lijst recursief of met een enkele pointer te benaderen.