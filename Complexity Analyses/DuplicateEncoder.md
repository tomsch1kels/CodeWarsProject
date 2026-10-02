# 🧠 Complexiteitsanalyse: DuplicateEncoder

*Bronbestand: [DuplicateEncoder.cs](../Solutions/DuplicateEncoder.cs)*

---

1. **Complexiteit**: 
   - Tijd: $\mathcal{O}(n)$
   - Ruimte: $\mathcal{O}(n)$

2. **Efficiëntst?**: 
   Ja. De tijdscomplexiteit van $\mathcal{O}(n)$ is optimaal omdat elk karakter minstens één keer gelezen moet worden om te bepalen of het uniek is.

3. **Optimalisatiemogelijkheid**: 
   De huidige code is functioneel correct en optimaal qua Big O, maar bevat onnodige prestatieverlies door LINQ-allocaties (`.ToList()`). Dit kan worden geoptimaliseerd door:
   - Een `ReadOnlySpan<char>` of simpelweg een `foreach`-lus te gebruiken i.p.v. `.ToList()`.
   - Een `Span<char>` te gebruiken voor het bouwen van het resultaat om heap-allocaties van de string-concatenatie te vermijden.