# 🧠 Complexiteitsanalyse: InsertNth

*Bronbestand: [InsertNth.cs](../Solutions/InsertNth.cs)*

---

### 1. Complexiteit
* **Tijdcomplexiteit**: $O(n)$, waarbij $n$ de index is waar het nieuwe element wordt ingevoegd, omdat de lijst tot aan de opgegeven index moet worden doorlopen.
* **Ruimtecomplexiteit**: $O(1)$, aangezien er slechts een constante hoeveelheid extra geheugen wordt gebruikt voor lokale variabelen en het nieuwe knooppunt.

### 2. Efficiëntst?
* **Ja**, de implementatie heeft de optimale Big O tijdscomplexiteit ($O(n)$) en ruimtecomplexiteit ($O(1)$) die fundamenteel mogelijk is voor een enkelschakelende lijst (linked list) op basis van een index.

### 3. Optimalisatiemogelijkheid
De code is qua Big O optimaal, maar kan verder worden gestroomlijnd. De `if (head == null)` check is overbodig omdat `head` als `Node` (een non-nullable reference type in moderne C#-contexten, mits nullable context correct staat) nooit `null` kan zijn, tenzij expliciet toegestaan. Daarnaast kan de iteratieve `for`-lus worden vervangen door een iets compacter patroon, hoewel de huidige leesbaarheid uitstekend is. Er is geen fundamentele algoritme-wisseling nodig.