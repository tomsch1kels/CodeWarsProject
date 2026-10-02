# 🧠 Complexiteitsanalyse: InsertNth

*Bronbestand: [InsertNth.cs](../Solutions/InsertNth.cs)*

---

### 1. Complexiteit
* **Tijdskomplexiteit**: $\mathcal{O}(n)$, waarbij $n$ de index is waar de node wordt ingevoegd. In het slechtste geval moet de lijst tot index $𝑛$ worden doorlopen.
* **Ruimtecomplexiteit**: $\mathcal{O}(1)$. Er wordt constant extra geheugen allocated voor de nieuwe node en enkele pointers, ongeacht de lengte van de lijst.

### 2. Optimalisatiemogelijkheid
De huidige implementatie is qua Big O al optimaal voor een gekoppelde lijst ($\mathcal{O}(n)$ tijd, $\mathcal{O}(1)$ ruimte). Wel kan de code iets robuuster en idiomaticser geschreven worden:
* **Null-afhandeling**: De `head == null` check aan het begin is redundant als de constructor geen null-waarden toestaat, maar in C# kan een record of struct soms handiger zijn. 
* **Expressiviteit**: De loop kan iets compacter door direct op null te controleren in plaats van een `InvalidOperationException` te werpen, aangezien een "index out of range" beter past bij de semantiek van deze methode (bijv. door `ArgumentOutOfRangeException` te gooien als `current` null wordt tijdens het itereren).