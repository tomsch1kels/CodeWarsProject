# 🧠 Complexiteitsanalyse: InsertNth

*Bronbestand: [InsertNth.cs](../Solutions/InsertNth.cs)*

---

1. **Complexiteit**: 
   - Tijdcomplexiteit: $\mathcal{O}(n)$, waarbij $n$ de index is waar de nieuwe node moet worden ingevoegd.
   - Ruimtecomplexiteit: $\mathcal{O}(1)$ (constante extra ruimte).

2. **Efficiëntst?**: 
   - **Ja**, de tijdscomplexiteit van $\mathcal{O}(n)$ is optimaal voor een gekoppelde lijst (linked list), aangezien je de elementen tot de index nu eenmaal moet doorlopen.

3. **Optimalisatiemogelijkheid**: 
   - De huidige oplossing is qua Big O optimaal. Wel kan de code iets worden vereenvoudigd en versneld door de `previous` pointer weg te laten en direct op `current.next` te itereren. Daarnaast kan de `head == null` check vervallen als de `Node`klasse geen `null` toestaat (of door `ArgumentNullException` te gebruiken).