# 🧠 Complexiteitsanalyse: FirstNonRepeatingLetter

*Bronbestand: [FirstNonRepeatingLetter.cs](../Solutions/FirstNonRepeatingLetter.cs)*

---

1. **Complexiteit**: 
   - Tijd: $\mathcal{O}(n^2)$ in het slechtste geval (door herhaalde string slicing en `.Contains()` aanroepen binnen een lus).
   - Ruimte: $\mathcal{O}(n)$ (door het genereren van substrings en kopieën bij het converteren naar lower/upper case).

2. **Efficiëntst?**: 
   Nee.

3. **Optimalisatiemogelijkheid**: 
   De huidige oplossing kan worden geoptimaliseerd naar $\mathcal{O}(n)$ tijd en $\mathcal{O}(n)$ ruimte door gebruik te maken van een `Dictionary<char, int>` (of een frequentietabel) om eerst case-insensitive de voorkomens van alle karakters te tellen. Vervolgens itereer je een tweede maal over de string om het eerste karakter te vinden met een telling van 1. Hierdoor vermijd je dure nested substrings en herhaalde zoekopdrachten.