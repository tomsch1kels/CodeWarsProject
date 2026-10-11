# 🧠 Complexiteitsanalyse: FirstNonRepeatingLetter

*Bronbestand: [FirstNonRepeatingLetter.cs](../Solutions/FirstNonRepeatingLetter.cs)*

---

1. **Complexiteit**:
   - **Tijdcomplexiteit**: $O(N^2)$ in het slechtste geval, omdat voor elk karakter substrings worden gekopieerd (`s[..i]` en `s[(i + 1)..]`) en doorzocht.
   - **Ruimtecomplexiteit**: $O(N)$ vanwege het alloceren van substrings en het converteren naar kleine/grote letters.

2. **Efficiëntst?**:
   - Nee.

3. **Optimalisatiemogelijkheid**:
   - De tijdscomplexiteit kan worden teruggebracht naar **$O(N)$** door een `Dictionary<char, int>` (of een frequentietabel voor ASCII/Unicode) te gebruiken om de teltotalen van hoofd- en kleine letters in één enkele iteratie over de string op te slaan. In een tweede, snelle iteratie kan dan het eerste karakter worden gevonden waarvan de hoofd-/kleine letter variant een frequentie van 1 heeft, zonder dure substring-allocaties.