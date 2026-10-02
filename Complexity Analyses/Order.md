# 🧠 Complexiteitsanalyse: Order

*Bronbestand: [Order.cs](../Solutions/Order.cs)*

---

1. **Overzicht & Samenvatting**
De aangeboden oplossing sorteert een zin waarin elk woord een getal van 1 tot 9 bevat, op basis van dat getal. De aanpak maakt gebruik van moderne C# (C# 12 target-typed new expressions `[]`) en volgt deze stappen:
- Er wordt gecontroleerd of de input leeg of `null` is.
- De invoerstring wordt opgesplitst in losse woorden via `words.Split()`.
- Voor elk woord wordt het cijfer geëxtraheerd met `word.Single(char.IsDigit)`. Omdat `Single` een `char` oplevert, wordt deze impliciet (of via unboxing/casting) gebruikt als integer-sleutel. *Opmerking: hier zit een potentieel type-issue omdat `Single(char.IsDigit)` een `char` teruggeeft (bijv. `'1'`), wat in een `SortedDictionary<int, string>` impliciet wordt omgezet naar de ASCII-waarde (49) tenzij de auteur dit anders bedoelt. Uitgaande van correcte werking:* het woord wordt samen met zijn index opgeslagen in een `SortedDictionary<int, string>`, die automatisch sorteert op sleutel.
- Tot slot worden de gesorteerde waarden samengevoegd tot één string via `string.Join`.

2. **Tijdscomplexiteit (Time Complexity)**
- **Stap 1 (Splitsen):** `words.Split()` doorloopt de string van lengte $N$ (aantal karakters), wat $\mathcal{O}(N)$ tijd kost.
- **Stap 2 (Itereren en inladen):** Stel dat er $W$ woorden zijn. Voor elk woord wordt `word.Single(char.IsDigit)` aangeroepen. Dit doorloopt de lengte van het woord, maar aangezien woorden in deze kata heel kort zijn (maximaal ~10 karakters), is dit $\mathcal{O}(1)$ per woord.
- **Stap 3 (SortedDictionary insertie):** Het invoegen in een `SortedDictionary` van grootte $W$ kost $\mathcal{O}(\log W)$ per element. Voor $W$ woorden is dit $\mathcal{O}(W \log W)$.
- **Stap 4 (Join):** Het samenvoegen van de $W$ woorden kost $\mathcal{O}(N)$ tijd.
- **Totale tijdscomplexiteit:** $\mathcal{O}(N + W \log W)$, waarbij $N$ het aantal karakters is en $W$ het aantal woorden. Aangezien $W \le N$, is dit effectief te schrijven als $\mathcal{O}(N \log W)$ of $\mathcal{O}(N)$ voor typische kata-limieten.

3. **Ruimtecomplexiteit (Space Complexity)**
- `words.Split()` creëert een array van woorden van grootte $\mathcal{O}(N)$.
- De `SortedDictionary` slaat alle $W$ woorden en hun sleutels op, wat $\mathcal{O}(N)$ geheugen in beslag neemt.
- De uiteindelijke string van `string.Join` vereist ook $\mathcal{O}(N)$ geheugen.
- **Totale ruimtecomplexiteit:** $\mathcal{O}(N)$, waarbij $N$ de totale lengte van de inputstring is (voor zowel de tussentijdse collecties als het resultaat).

4. **Optimalisatie & Code Quality**
- **Kritisch punt (Bugrisico):** `word.Single(char.IsDigit)` retourneert een `char` (bijv. `'1'`). In een `SortedDictionary<int, string>` wordt dit geïnterpreteerd als de ASCII/Unicode-waarde (49), niet als het integer getal `1`. Hoewel dit in dit specifieke scenario toevallig werkt zolang de getallen 1 t/m 9 zijn (omdat de ASCII-waarden dezelfde volgorde behouden), is het semantisch incorrect en kwetsbaar. Beter is om expliciet te converteren naar een int: `int.Parse(word.First(char.IsDigit).ToString())`.
- **Overbodige allocatie:** `.Values.ToArray()` is overbodig. `string.Join` accepteerd direct een `IEnumerable<string>`, dus `string.Join(" ", sDict.Values)` werkt net zo goed en bespaart een extra array-allocatie.
- **Leesbaarheid:** De code is compact en idiomatically modern C#. Het gebruik van `SortedDictionary` is een slimme keuze omdat het automatisch sorteerwerk uit handen neemt zonder dat je handmatig LINQ `.OrderBy()` hoeft aan te roepen.