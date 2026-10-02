# 🧠 Complexiteitsanalyse: InsertNth

*Bronbestand: [InsertNth.cs](../Solutions/InsertNth.cs)*

---

1. **Complexiteit**: 
   - Tijdcomplexiteit: $O(n)$ in de worst-case, waarbij $n$ de index is (omdat we tot de $n$-de positie moeten itereren).
   - Ruimtecomplexiteit: $O(1)$ (er wordt constant extra geheugen gebruikt voor de nieuwe node en enkele pointers).

2. **Efficiëntst?**: 
   - Ja, de tijdscomplexiteit $O(n)$ is optimaal voor een gelinkte lijst, omdat we de elementen fysiek moeten doorlopen om bij de juiste index te komen.

3. **Optimalisatiemogelijkheid**: 
   - De huidige oplossing is qua algoritme al optimaal. Wel kan de code iets vereenvoudigd worden door `ArgumentOutOfRangeException` direct aan het begin te gebruiken en de null-controles te stroomlijnen. Een recursieve benadering is mogelijk, maar minder efficiënt qua geheugen ($O(n)$ stackruimte) dan deze iteratieve aanpak.