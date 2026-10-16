# 🧠 Complexiteitsanalyse: InsertNth

*Bronbestand: [InsertNth.cs](../Solutions/InsertNth.cs)*

---

1. **Complexiteit**: 
   - Tijd: $\mathcal{O}(n)$ (waarbij $n$ de index is waar ingevoegd moet worden).
   - Ruimte: $\mathcal{O}(1)$ (constante extra geheugenruimte).

2. **Efficiëntst?**: 
   - Ja, de tijdscomplexiteit van $\mathcal{O}(n)$ is optimaal voor een gekoppelde lijst (linked list) omdat je sequentieel door de knopen moet navigeren tot de gewenste index.

3. **Optimalisatiemogelijkheid**: 
   - De huidige oplossing is qua Big O al optimaal en maakt reeds gebruik van moderne C#-features (`ArgumentOutOfRangeException.ThrowIfNegative`). Kleine micro-optimalisaties (zoals het verwijderen van de `InvalidOperationException`-check als de logica garandeert dat `current` niet null is tijdens de loop) verbeteren de Big O niet, maar kunnen de overhead fractioneel verlagen. Het toevoegen van een `data`-eigenschap (die in dit specifieke Codewars-kata vaak wel verwacht wordt voor de nodingen) is functioneel belangrijker dan verdere prestatie-optimalisatie.