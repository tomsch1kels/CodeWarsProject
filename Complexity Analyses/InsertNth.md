# 🧠 Complexiteitsanalyse: InsertNth

*Bronbestand: [InsertNth.cs](../Solutions/InsertNth.cs)*

---

### 1. Complexiteit
* **Tijdcomplexiteit**: $\mathcal{O}(n)$, waarbij $n$ de index is waar het nieuwe knooppunt wordt ingevoegd. We doorlopen de lijst maximaal $n$ keer.
* **Ruimtecomplexiteit**: $\mathcal{O}(1)$, aangezien er constant extra geheugen wordt gealloceerd (één nieuw `Node`-object), ongeacht de lengte van de lijst of de index.

### 2. Efficiëntst?
* **Ja**. Voor een enkellinked list is $\mathcal{O}(n)$ de theoretisch optimale tijdscomplexiteit om een element op een willekeurige index te bereiken en in te voegen.

### 3. Optimalisatiemogelijkheid
De huidige implementatie is algoritmisch optimaal, maar kan qua leesbaarheid en robuustheid iets worden verbeterd. 
* De `if (head == null)` check is overbodig omdat `Node` een class is en de parameter `head` via de `for`-lus al veilig wordt afgehandeld. 
* Het expliciet gooien van een `InvalidOperationException` wanneer `current` null is tijdens de iteratie, kan worden vereenvoudigd door een `ArgumentOutOfRangeException` te gooien als de index groter is dan de lengte van de lijst. Dit sluit beter aan bij de C#-conventies voor ongeldige indices.