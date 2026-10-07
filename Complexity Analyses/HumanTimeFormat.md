# 🧠 Complexiteitsanalyse: HumanTimeFormat

*Bronbestand: [HumanTimeFormat.cs](../Solutions/HumanTimeFormat.cs)*

---

1. **Complexiteit**: 
   - Tijdcomplexiteit: $\mathcal{O}(1)$ (omdat het aantal tijdseenheden en berekeningen constant is en niet groeit met de invoer).
   - Ruimtecomplexiteit: $\mathcal{O}(1)$ (omdat er maximaal 5 elementen in de lijst worden opgeslagen).

2. **Efficiëntst?**: 
   - Ja. De tijdscomplexiteit $\mathcal{O}(1)$ is optimaal omdat de uitvoeringstijd begrensd en constant is.

3. **Optimalisatiemogelijkheid**: 
   Hoewel de Big O-complexiteit optimaal is, kan de *micro-optimalisatie* worden verbeterd. De huidige code gebruikt closures en allocaties (zoals `List<string>`, `Where`, `TakeLast`, en `Append`), wat onnodige garbage collection druk oplevert. Dit kan volledig allocations-free worden geschreven door gebruik te maken van `Span<char>`, `ValueStringBuilder` of door direct een `string.Create` / stringinterpolatie te gebruiken met een vaste capaciteit. Voor deze specifieke kata is de prestatiewinst echter te verwaarlozen.