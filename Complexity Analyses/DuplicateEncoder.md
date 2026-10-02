# 🧠 Complexiteitsanalyse: DuplicateEncoder

*Bronbestand: [DuplicateEncoder.cs](../Solutions/DuplicateEncoder.cs)*

---

1. **Complexiteit**: 
   - Tijd: $\mathcal{O}(n)$
   - Ruimte: $\mathcal{O}(n)$

2. **Efficiëntst?**: 
   - Ja, de tijdscomplexiteit is optimaal ($\mathcal{O}(n)$) omdat elke karakter minstens één keer gelezen moet worden.

3. **Optimalisatiemogelijkheid**: 
   - De huidige implementatie maakt onnodige allocaties door herhaaldelijk `.ToList()` aan te roepen en LINQ te gebruiken. Dit kan geoptimaliseerd worden door LINQ te vermijden, een `Span<char>` of `StringBuilder` te gebruiken, en de frequentietabel vooraf te dimensioneren (bijv. een vaste `int[255]` array aangezien het om ASCII/Unicode karakters gaat in plaats van een `Dictionary`).