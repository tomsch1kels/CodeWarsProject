# 🧠 Complexiteitsanalyse: InsertNth

*Bronbestand: [InsertNth.cs](../Solutions/InsertNth.cs)*

---

1. **Tijdscomplexiteit (Time Complexity)**: 
$O(n)$

2. **Ruimtecomplexiteit (Space Complexity)**: 
$O(1)$

3. **Optimalisatie**: 
De huidige implementatie is qua complexiteit al optimaal ($O(n)$ tijd, $O(1)$ extra geheugen), aangezien een gekoppelde lijst (linked list) nu eenmaal sequentieel doorlopen moet worden om de $e$ index te bereiken. 

Wel kan de code iets efficiënter en leesbaarder worden gemaakt door:
* **Null-check en Index validatie direct aan het begin** te plaatsen, voordat er objecten worden aangemaakt.
* **`previous` en `current` logica te stroomlijnen**, bijvoorbeeld door de loop iets compacter te schrijven of gebruik te maken van een lokale referentie naar de `head`.
* **C# 12 primary constructor optimalisatie**: De `next` referentie kan direct optioneel via de constructor worden meegegeven in plaats van object initializers, wat onnodige toewijzingen voorkomt.