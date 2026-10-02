# 🧠 Complexiteitsanalyse: FirstNonRepeatingLetter

*Bronbestand: [FirstNonRepeatingLetter.cs](../Solutions/FirstNonRepeatingLetter.cs)*

---

1. **Complexiteit**: 
   - Tijd: $\mathcal{O}(n^2)$ in het slechtste geval (vanwege nested substrings en doorzoekingen in de `for`-lus voor elk karakter).
   - Ruimte: $\mathcal{O}(n)$ (vanwege het creëren van substring-allocaties via slicing `s[..i]` en `s[(i + 1)..]`).

2. **Efficientst?**: 
   Nee. De huidige oplossing heeft een quadratische tijdscomplexiteit ($\mathcal{O}(n^2)$) en maakt onnodige string-allocaties, terwijl dit in lineare tijd ($\mathcal{O}(n)$) opgelost kan worden.

3. **Optimalisatiemogelijkheid**: 
   Dit kan efficiënter door een frequentietabel (`Dictionary<char, int>` of een array voor ASCII) te gebruiken. Eén iteratie telt de frequenties van alle hoofd-/kleine letters (case-insensitive), en een tweede korte iteratie vindt het eerste karakter met frequentie 1. Dit verlaagt de tijdcomplexiteit naar $\mathcal{O}(n)$ en elimineert heap-allocaties voor substrings.