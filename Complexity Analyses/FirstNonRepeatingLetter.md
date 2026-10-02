# 🧠 Complexiteitsanalyse: FirstNonRepeatingLetter

*Bronbestand: [FirstNonRepeatingLetter.cs](../Solutions/FirstNonRepeatingLetter.cs)*

---

1. **Complexiteit**:
   - **Tijdcomplexiteit**: $O(n^2)$ in het slechtste geval (waarbij $n$ de lengte van de string is), omdat voor elk karakter de resterende subStrings opnieuw worden doorzocht.
   - **Ruimtecomplexiteit**: $O(n)$ vanwege het alloceren van subStrings (ranges) en het converteren naar lower/upper case.

2. **Optimalisatiemogelijkheid**:
   De huidige oplossing kan aanzienlijk efficiënter door een frequentietabel (bijv. een `Dictionary<char, int>` of een array voor ASCII) te gebruiken. Door de string tweemaal te doorlopen—eenmalig om alle karakters te tellen (case-insensitive) en een tweede keer om het eerste karakter met frequentie 1 te vinden—wordt de tijdcomplexiteit gereduceerd tot **$O(n)$** en de ruimtecomplexiteit tot **$O(1)$** (of $O(k$ met $k$ als alfabetgrootte). Dit voorkomt dure substring-allocaties in een loop.