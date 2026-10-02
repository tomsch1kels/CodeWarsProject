# 🧠 Complexiteitsanalyse: FirstNonRepeatingLetter

*Bronbestand: [FirstNonRepeatingLetter.cs](../Solutions/FirstNonRepeatingLetter.cs)*

---

### 1. Complexiteit
* **Tijdcomplexiteit:** $\mathcal{O}(n^2)$ in het slechtste geval (waarbij $n$ de lengte is van de string), omdat voor elk karakter de resterende subStrings worden doorzocht met `Contains`.
* **Ruimtecomplexiteit:** $\mathcal{O}(n)$ vanwege het alloceren van substrings (`s[..i]` en `s[(i + 1)..]`) en stringconversies bij elke iteratie.

### 2. Optimalisatiemogelijkheid
Ja, dit kan aanzienlijk efficiënter. De huidige aanpak herhaalt veel zoekacties. Door gebruik te maken van een `Dictionary<char, int>` (of een frequentietabel voor ASCII) kan de string in **$\mathcal{O}(n)$ tijd** en **$\mathcal{O}(n)$ ruimte** worden opgelost:
1. Loop eenmalig door de hoofdletterongevoelige string om de frequentie van elk karakter te tellen.
2. Loop een tweede keer door de *originele* string om het eerste karakter te vinden waarvan de frequentie gelijk is aan 1. 

Hierdoor vermijd je dure substring-operaties binnen een nested loop.