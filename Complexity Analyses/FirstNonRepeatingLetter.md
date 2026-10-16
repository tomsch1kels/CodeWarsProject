# 🧠 Complexiteitsanalyse: FirstNonRepeatingLetter

*Bronbestand: [FirstNonRepeatingLetter.cs](../Solutions/FirstNonRepeatingLetter.cs)*

---

### 1. Complexiteit
* **Tijdskomplexiteit**: $\mathcal{O}(n^2)$ in het slechtste geval (waarbij $n$ de lengte van de string is), omdat voor elk karakter de resterende subStrings worden doorzocht met `Contains`.
* **Ruimtekomplexiteit**: $\mathcal{O}(n)$ in het slechtste geval, vanwege het alloceren van substrings (`s[..i]` en `s[(i + 1)..]`).

### 2. Efficiëntst?
**Nee**.

### 3. Optimalisatiemogelijkheid
De huidige oplossing kan worden geoptimaliseerd naar een tijdscomplexiteit van $\mathcal{O}(n)$ en een ruimtekomplexiteit van $\mathcal{O}(1)$ (gezien een begrensde tekenset). Dit kan door gebruik te maken van een frequentietabel (bijv. een `Dictionary<char, int>` of een vaste array voor ASCII/Unicode) om eerst alle hoofd-/kleine letterfrequenties te tellen, ongeacht case. Vervolgens itereer je een tweede keer over de originele string om het eerste karakter te vinden waarvan de case-insensitive telling gelijk is aan 1. Dit voorkomt het herhaaldelijk doorzoeken van substrings.