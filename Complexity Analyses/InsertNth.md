# 🧠 Complexiteitsanalyse: InsertNth

*Bronbestand: [InsertNth.cs](../Solutions/InsertNth.cs)*

---

1. **Complexiteit**: 
   - Tijdcomplexiteit: $\mathcal{O}(n)$ (waarbij $n$ de index is waar ingevoegd moet worden).
   - Ruimtecomplexiteit: $\mathcal{O}(1)$ (er wordt exact één nieuwe node gealloceerd, ongeacht de grootte).

2. **Efficiëntst?**: 
   - Ja, de tijdscomplexiteit ($\mathcal{O}(n)$) is optimaal omdat een gekoppelde lijst (linked list) nu eenmaal sequentieel doorlopen moet worden tot de gewenste index.

3. **Optimalisatiemogelijkheid**: 
   - De huidige implementatie is algoritmisch optimaal. Qua codekwaliteit kan het iets compacter door de `previous` pointer te elimineren door direct op `current.next` te itereren, of door C# 12 primary constructors consistenter toe te passen. Dit levert echter geen verandering op in Big O-prestaties.