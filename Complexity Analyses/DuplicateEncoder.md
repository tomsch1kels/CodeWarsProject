# 🧠 Complexiteitsanalyse: DuplicateEncoder

*Bronbestand: [DuplicateEncoder.cs](../Solutions/DuplicateEncoder.cs)*

---

1. **Overzicht & Samenvatting**
De voorgestelde oplossing lost het "Duplicate Encoder" kata op door middel van een tweefasen-strategie. Eerst wordt de invoerstring genormaliseerd naar hoofdletters om hoofdletterongevoeligheid te garanderen. Vervolgens worden de frequenties van alle karakters geteld en opgeslagen in een `Dictionary<char, int>`. In de tweede fase wordt de string opnieuw doorlopen om elk karakter te mappen naar een '(' (als het karakter uniek is) of een ')' (als het karakter vaker dan eens voorkomt). De implementatie maakt gebruik van moderne C# features zoals target-typed new (`[]`) en LINQ.

2. **Tijdscomplexiteit (Time Complexity)**
De tijdscomplexiteit van dit algoritme is **$O(n)$**, waarbij $n$ de lengte is van de invoerstring `word`.
* **Onderbouwing:** 
  * Het converteren naar hoofdletters (`ToUpperInvariant`) kost $O(n)$ tijd.
  * Het omzetten naar een lijst en doorlopen via `ForEach` met een dictionary-lookup kost $O(n)$ gemiddeld, aangezien dictionary inserties en lookups in $O(1)$ gemiddelde tijd plaatsvinden.
  * Het opnieuw doorlopen van de string via LINQ (`Select` en `string.Concat`) kost eveneens $O(n)$ tijd.
  Omdat deze stappen sequentieel worden uitgevoerd (niet genest), blijft de totale tijdscomplexiteit lineair $O(n)$.

3. **Ruimtecomplexiteit (Space Complexity)**
De ruimtecomplexiteit van dit algoritme is **$O(n)$**, waarbij $n$ de lengte is van de invoerstring.
* **Onderbouwing:** 
  * `ToUpperInvariant` genereert een nieuwe string van grootte $O(n)$.
  * De `Dictionary<char, int>` slaat unieke karakters op. In het worst-case scenario (waarbij elk karakter uniek is) bevat de dictionary $n$ elementen, wat $O(n)$ geheugen kost.
  * De tussentijdse `List<char>` objecten (via `.ToList()`) alloceren extra geheugen van $O(n)$.
  * De uiteindelijke resultaatstring die wordt geretourneerd kost ook $O(n)$ geheugen.
  De totale gealloceerde hulpruimte schaalt lineair met de lengte van de invoer.

4. **Optimalisatie & Code Quality**
Hoewel de code functioneel correct en leesbaar is, zijn er vanuit het oogpunt van prestaties en geheugenallocatie enkele verbeterpunten:
* **Overbodige enumeraties:** Er wordt meerdere keren `.ToList()` aangeroepen (`word.ToList().ForEach(...)` en `word.ToList().Select(...)`). Een string implementeert `IEnumerable<char>`, dus `.ToList()` is overbodig. Dit vermeerdert het aantal onnodige heap-allocaties (garbage collection pressure).
* **Directe iteratie:** In plaats van LINQ en `List<char>` kan de performance aanzienlijk worden verbeterd door gebruik te maken van traditionele `foreach`-loops in combinatie met een `Span<char>` of `StringBuilder` voor het opbouwen van het resultaat. Dit voorkomt overhead van enumerators en LINQ-delegates.
* **Geheugenallocatie:** De methode `string.Concat` in combinatie met LINQ is redelijk efficiënt, maar een `StringBuilder` met een vooraf ingestelde capaciteit (`new StringBuilder(word.Length)`) is sneller en genereert minder garbage bij langere strings.

**Voorbeeld van een geoptimaliseerde versie:**
```csharp
internal static class DuplicateEncoder
{
    public static string DuplicateEncode(string word)
    {
        // Gebruik een Dictionary om frequenties te tellen zonder LINQ overhead
        var occurrences = new Dictionary<char, int>(word.Length);
        
        foreach (char c in word)
        {
            char upper = char.ToUpperInvariant(c);
            occurrences[upper] = 1 + occurrences.GetValueOrDefault(upper);
        }

        // Bouw het resultaat efficiënt op met een StringBuilder
        var sb = new System.Text.StringBuilder(word.Length);
        foreach (char c in word)
        {
            char upper = char.ToUpperInvariant(c);
            sb.Append(occurrences[upper] == 1 ? '(' : ')');
        }

        return sb.ToString();
    }
}
```