# 🧠 Complexiteitsanalyse: FirstNonRepeatingLetter

*Bronbestand: [FirstNonRepeatingLetter.cs](../Solutions/FirstNonRepeatingLetter.cs)*

---

1. **Overzicht & Samenvatting**
De aangeboden oplossing lost het "First non-repeating character" kata op door iteratief door de string te lopen. Voor elk karakter wordt gecontroleerd of het zowel in het voorafgaande deel van de string (`s[..i]`) als in het resterende deel (`s[(i + 1)..]`) voorkomt. Hierbij wordt rekening gehouden met hoofdlettergevoeligheid door expliciet te controleren op zowel de lowercase als de uppercase variant van het betreffende karakter. Als een karakter nergens anders in de string voorkomt (ongeacht case), wordt dit karakter direct geretourneerd.

2. **Tijdscomplexiteit (Time Complexity)**
* **Worst-case tijdscomplexiteit:** $\mathcal{O}(n^2)$
* **Onderbouwing:** De buitenste `for`-loop itereert $n$ keer (waarbij $n$ de lengte is van de string `s`). Binnen deze loop worden sub-string operaties en zoekacties uitgevoerd (`s[..i].Contains` en `s[(i + 1)..].Contains`). Het creëren van een sub-string en het doorzoeken daarvan kost in de worst-case $\mathcal{O}(n)$ tijd per iteratie. Aangezien dit in het slechtste geval (geen uniek karakter) voor elk karakter in de string gebeurt, resulteert dit in een kwadratische tijdscomplexiteit $\mathcal{O}(n^2)$.

3. **Ruimtecomplexiteit (Space Complexity)**
* **Worst-case ruimtecomplexiteit:** $\mathcal{O}(n)$
* **Onderbouwing:** Bij elke iteratie worden sub-strings gegenereerd via range-syntaxis (`s[..i]` en `s[(i + 1)..]`). In C# alloceren sub-strings (in oudere versies) of span-gebaseerde operaties geheugen op de heap, hoewel moderne .NET versies optimalisaties toepassen. Bovendien creëren `s.ToLower()` en `s.ToUpper()` nieuwe string-allocaties van grootte $\mathcal{O}(n)$. De totale extra geheugenallocatie per iteratie en in totaal schaalt lineair met de lengte van de invoerstring, wat neerkomt op $\mathcal{O}(n)$.

4. **Optimalisatie & Code Quality**
* **Prestatieknelpunt:** Het herhaaldelijk aanroepen van `ToLower()`, `ToUpper()` en het slicen van sub-strings binnen een loop zorgt voor onnodige geheugenallocaties (garbage collection pressure) en een sub-optimale $\mathcal{O}(n^2)$ tijdscomplexiteit. Dit kan veel efficiënter in $\mathcal{O}(n)$ tijd en $\mathcal{O}(n)$ ruimte.
* **Geheugenlekken:** Er zijn geen traditionele geheugenlekken (managed code ruimt alles netjes op), maar de code is wel *memory-allocating heavy*.
* **Leesbaarheid en Architectuur:**
    * De lokale helperfuncties (`static bool ...`) binnen de methode zijn een modern C#-feature en zorgen voor inkapseling, maar maken de methode erg lang en complex om te volgen.
    * Het gebruik van `CultureInfo.CurrentCulture` bij stringvergelijkingen kan op servers met verschillende locales onvoorspelbaar gedrag vertonen; `StringComparison.OrdinalIgnoreCase` heeft vaak de voorkeur voor programmeerlogica.
* **Aanbevolen Refactoring:** 
  Een optimale aanpak maakt gebruik van een `Dictionary<char, int>` of een frequentie-array om eerst alle karaktertellingen (case-insensitive) in $\mathcal{O}(n)$ tijd op te slaan. Vervolgens itereer je een tweede keer over de string om het eerste karakter te vinden dat een telling van 1 heeft. Dit reduceert de tijdscomplexiteit naar $\mathcal{O}(n)$ en elimineert de dure substring-allocaties binnen de loop.