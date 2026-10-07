# 🧠 Complexiteitsanalyse: FirstNonRepeatingLetter

*Bronbestand: [FirstNonRepeatingLetter.cs](../Solutions/FirstNonRepeatingLetter.cs)*

---

### 1. Complexiteit
* **Tijdcomplexiteit:** $\mathcal{O}(N^2)$ in het slechtste geval (waarbij $N$ de lengte van de string is), omdat voor elk karakter de resterende subStrings worden doorzocht met `Contains`.
* **Ruimtecomplexiteit:** $\mathcal{O}(N)$ vanwege het alloceren van substrings (`s[..i]` en `s[(i + 1)..\]`) en geheugen voor hoofd-/kleine letterconversies.

### 2. Efficiëntst?
Nee.

### 3. Optimalisatiemogelijkheid
De tijdscomplexiteit kan worden gereduceerd tot $\mathcal{O}(N)$ door gebruik te maken van een frequentietabel (bijvoorbeeld een `Dictionary<char, int>`). In de eerste pass tel je de voorkomens van elk karakter (rekening houdend met hoofd-/kleine letters maar met behoud van originele casing). In de tweede pass over de string return je het eerste karakter waarvan de telling gelijk is aan 1. Dit voorkomt dure herhaalde substring-zoekopdrachten.