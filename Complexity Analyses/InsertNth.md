# 🧠 Complexiteitsanalyse: InsertNth

*Bronbestand: [InsertNth.cs](../Solutions/InsertNth.cs)*

---

1. **Complexiteit**:
   - **Tijdscomplexiteit**: $\mathcal{O}(n)$ (waarbij $n$ de index is waar ingevoegd moet worden).
   - **Ruimtecomplexiteit**: $\mathcal{O}(1)$ (er wordt slechts één nieuw `Node`-object toegewezen).

2. **Efficiëntst?**:
   - **Ja**, de implementatie heeft de optimale Big O tijdscomplexiteit. Om de $n$-de positie in een gekoppelde lijst (linked list) te bereiken, moet men nu eenmaal itereren tot die index, wat lineaire tijd vereist.

3. **Optimalisatiemogelijkheid**:
   - De huidige oplossing is algoritmisch optimaal. Qua C#-implementatie kan het iets idiomatischer en compacter door de `for`-lus te vervangen door een `while`-lus met een teller, of door `ArgumentOutOfRangeException.ThrowIfNegative` direct te gebruiken. Deoverhead van de huidige validaties en nul-controles is echter al minimaal.