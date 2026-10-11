# 🧠 Complexiteitsanalyse: FirstNonRepeatingLetter

*Bronbestand: [FirstNonRepeatingLetter.cs](../Solutions/FirstNonRepeatingLetter.cs)*

---

### 1. Complexiteit
* **Tijdcomplexiteit**: $O(N^2)$ in het slechtste geval (waarbij $N$ de lengte van de string is), omdat voor elk karakter substring-operaties en `.Contains()` checks worden uitgevoerd over de resterende en eerdere delen van de string.
* **Ruimtecomplexiteit**: $O(N)$ vanwege het alloceren van substrings (slices zoals `s[..i]` en `s[(i + 1)..]`) en geheugen voor de lowercase/uppercase conversies.

### 2. Efficiëntst?
**Nee**. De huidige implementatie heeft een $O(N^2)$ tijdscomplexiteit, terwijl dit probleem in $O(N)$ tijd opgelost kan worden.

### 3. Optimalisatiemogelijkheid
De efficiëntie kan drastisch worden verbeterd naar $O(N)$ door een frequentietabel (bijv. een `Dictionary<char, int>` of een array voor ASCII) te gebruiken. 
1. **Pass 1**: Doorloop de string en tel de voorkomens van elk teken, waarbij je hoofdletterongevoeligheid afdwingt door alles naar lowercase (of uppercase) te normaliseren.
2. **Pass 2**: Doorloop de originele string nogmaals en retourneer het eerste teken waarvan de telling in de frequentietabel gelden is aan `1`. 

Hiermee vervang je de dure nested zoekopdrachten door $O(1)$ dictionary lookups.