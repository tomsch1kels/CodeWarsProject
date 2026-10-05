# 🧠 Complexiteitsanalyse: DuplicateEncoder

*Bronbestand: [DuplicateEncoder.cs](../Solutions/DuplicateEncoder.cs)*

---

1. **Complexiteit**: 
   - Tijd: $\mathcal{O}(n)$
   - Ruimte: $\mathcal{O}(n)$
   *(waarbij $n$ de lengte van de string is)*

2. **Efficiëntst?**: 
   Ja. $\mathcal{O}(n)$ is de optimale tijdscomplexiteit omdat elk karakter minstens één keer gelezen moet worden om te bepalen of het uniek is.

3. **Optimalisatiemogelijkheid**: 
   De huidige implementatie kan worden versneld en geoptimaliseerd voor minder geheugengebruik (allocaties) door overbodige LINQ-operatoren (`.ToList()`, `.ForEach()`, `.Select()`) te vermijden. Dit kan met een `Span<char>` of een eenvoudige `for`-lus i.c.m. een `Span<char>` of `StringBuilder`, en door vooraf te tellen in een vaste array (aangenomen dat de invoer binnen de ASCII/Unicode-set valt) in plaats van een `Dictionary<char, int>`.