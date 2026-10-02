# 🧠 Complexiteitsanalyse: DuplicateEncoder

*Bronbestand: [DuplicateEncoder.cs](../Solutions/DuplicateEncoder.cs)*

---

## 1. Overzicht & Samenvatting

De ingediende oplossing voor de "Duplicate Encoder" kata pakt het probleem in twee fasen aan:
1. **Frequentieanalyse**: Eerst wordt de invoerstring genormaliseerd naar hoofdletters (`ToUpperInvariant()`). Vervolgens wordt met behulp van LINQ (`ToList().ForEach`) over de karakters geïtereerd om een `Dictionary<char, int>` op te bouwen die telt hoe vaak elk karakter in de string voorkomt.
2. **Transformatie**: In de tweede fase wordt opnieuw over de string geïtereerd (via `Select`). Aan de hand van het frequentie-object wordt elk karakter vervangen door een `'('` (als het karakter uniek is, frequentie == 1) of een `')'` (als het karakter meer dan eens voorkomt). Het resultaat wordt samengevoegd tot een nieuwe string via `string.Concat`.

## 2. Tijdscomplexiteit (Time Complexity)

De totale tijdscomplexiteit is **$\mathcal{O}(n)$**, waarbij $n$ de lengte van de invoerstring (`word`) is.

**Onderbouwing:**
* **Normalisatie**: `ToUpperInvariant()` doorloopt de string één keer: $\mathcal{O}(n)$.
* **Eerste iteratie (Frequentieopbouw)**: `.ToList()` converteert de string naar een lijst ($\mathcal{O}(n)$) en `ForEach` voert een dictionary-lookup en insert uit. Het opzoeken en toevoegen in een `Dictionary<char, int>` kost gemiddeld $\mathcal{O}(1)$ tijd per karakter. Voor $n$ karakters is dit $\mathcal{O}(n)$.
* **Tweede iteratie (Transformatie)**: Opnieuw wordt de string omgezet naar een lijst ($\mathcal{O}(n)$) en wordt voor elk karakter een dictionary-lookup gedaan ($\mathcal{O}(1)$). Dit resulteert in $\mathcal{O}(n)$.
* **Samenvoegen**: `string.Concat` doorloopt de resulterende collectie van karakters om de string te bouwen: $\mathcal{O}(n)$.

Optelsom: $\mathcal{O}(n) + \mathcal{O}(n) + \mathcal{O}(n) + \mathcal{O}(n) = \mathcal{O}(n)$.

## 3. Ruimtecomplexiteit (Space Complexity)

De ruimtecomplexiteit is **$\mathcal{O}(n)$**, waarbij $n$ de lengte van de invoerstring is.

**Onderbouwing:**
* **`word` string**: De gemodificeerde string van lengte $n$ bevindt zich in het geheugen: $\mathcal{O}(n)$.
* **`Dictionary<char, int>` (`occurences`)**: In het worst-case scenario zijn alle karakters in de string uniek. De dictionary bevat dan $n$ elementen. In het best-case scenario (alle karakters zijn identiek) bevat de dictionary 1 element. De geheugenomvang schaalt lineair met het aantal unieke karakters, wat begrensd is door $n$ ($\mathcal{O}(n)$).
* **LINQ allocaties**: Het aanroepen van `.ToList()` creëert tijdelijke `List<char>` objecten in het geheugen, en `Select` genereert extra enumerators/objecten, wat bijdraagt aan de Garbage Collection (GC) druk.

## 4. Optimalisatie & Code Quality

Hoewel de code functioneel correct is en een goede $\mathcal{O}(n)$ tijdscomplexiteit heeft, zijn er op het gebied van geheugenallocatie en C#-idiomen verschillende verbeterpunten:

### Knelpunten & Geheugenverbruik (Allocations)
1. **Overtollige `.ToList()` aanroepen**: 
   * `word.ToList()` wordt tweemaal aangeroepen. Een string implementeert reeds `IEnumerable<char>`, dus het expliciet converteren naar een `List<char>` is overbodig en veroorzaakt onnodige heap-allocaties.
   * C# 12 / moderne .NET versies staan toe om direct te itereren over een string zonder deze naar een lijst te converteren.
2. **Functionaliteit van Dictionary**: 
   * De methode `TryAdd` of het controleren via `ContainsKey` is vaak duidelijker, hoewel `GetValueOrDefault` een schone C#-constructie is.

### Leesbaarheid & Moderne C# Tips
1. **Gebruik van `Span<T>` of directe `for`-loops**: 
   Voor maximale performance (vooral bij grotere strings) kun je itereren over een string met een `for`-loop of `ReadOnlySpan<char>` om *zero allocations* te bereiken.
2. **Refactoring naar een efficiëntere implementatie**:

```csharp
internal static class DuplicateEncoder
{
    public static string DuplicateEncode(string word)
    {
        // 1. Normaliseer direct
        string upperWord = word.ToUpperInvariant();
        
        // 2. Bouw de frequentietabel (gebruik Dictionary.EnsureCapacity indien gewenst)
        var occurrences = new Dictionary<char, int>(upperWord.Length);
        foreach (char c in upperWord)
        {
            occurrences[c] = occurrences.GetValueOrDefault(c) + 1;
        }

        // 3. Bouw het resultaat efficiënt met Span of StringBuilder (of string.Create in .NET)
        // Hier gebruiken we een char array + string constructor om extra LINQ overhead te vermijden.
        char[] result = new char[upperWord.Length];
        for (int i = 0; i < upperWord.Length; i++)
        {
            result[i] = occurrences[upperWord[i]] == 1 ? '(' : ')';
        }

        return new string(result);
    }
}
```

### Belangrijkste winst van de refactoring:
* Geen overbodige `.ToList()` allocaties meer.
* Directe iteratie over de string (`foreach` / `for`).
* Constructie van de uiteindelijke string in één enkele gealloceerde `char[]` buffer, wat de belasting op de Garbage Collector aanzienlijk vermindert.