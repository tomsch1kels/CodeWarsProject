# 🧠 Complexiteitsanalyse: WeightForWeight

*Bronbestand: [WeightForWeight.cs](../Solutions/WeightForWeight.cs)*

---

1. **Overzicht & Samenvatting**
De aangeboden oplossing voor de "Weight for weight" kata gebruikt een object-georiënteerde en functionele benadering via LINQ. De logica splitst de invoerstring op spaties om individuele gewichten (als `string` massa's) te extraheren. Vervolgens berekent een lokale helperfunctie `CalcWeightFromMass` de som van de cijfers van elke massa. Deze som (het "gewicht") en de oorspronkelijke string worden opgeslagen in een tuple. Ten slotte worden de tuples gesorteerd op basis van het berekende gewicht en, in het geval van gelijke gewichten, lexicografisch op basis van de oorspronkelijke string (`StringComparer.Ordinal`), waarna ze weer worden samengevoegd tot één spatie-gescheiden string.

2. **Tijdscomplexiteit (Time Complexity)**
De tijdscomplexiteit is **$\mathcal{O}(N \cdot L \log N)$**, waarbij $N$ het aantal getallen (massa's) in de string is en $L$ de maximale lengte van een getal (aantal cijfers).
* **Splitsen:** Het splitsen van de string kost $\mathcal{O}(S)$, waarbij $S$ de totale lengte van de invoerstring is.
* **Gewicht berekenen:** Voor elk van de $N$ getallen worden de cijfers opgeteld. Dit kost $\mathcal{O}(L)$ per getal, en dus $\mathcal{O}(N \cdot L)$ in totaal.
* **Sorteren:** Het sorteren van $N$ elementen kost $\mathcal{O}(N \log N$ comparaties). Echter, de comparator vergelijkt twee strings lexicografisch als de gewichten gelijk zijn, wat in het worst-case scenario $\mathcal{O}(L)$ per vergelijking kost. Dit brengt de sorteercomplexiteit op $\mathcal{O}(N \cdot L \log N)$.
* De totale complexiteit wordt gedomineerd door de sorteerstap: **$\mathcal{O}(N \cdot L \log N)$**.

3. **Ruimtecomplexiteit (Space Complexity)**
De ruimtecomplexiteit is **$\mathcal{O}(S)$**, waarbij $S$ de totale lengte van de invoerstring is.
* De methode `strng.Split(' ')` creëert een array van strings die proportioneel is aan de invoer.
* De `tupleList` slaat $N$ tuples op, die elk verwijzen naar de oorspronkelijke stringsegmenten en een `double` waarde bevatten.
* De uiteindelige `sortedMasses` en `string.Join` alloceren extra geheugen voor de resultaten.
* Hierdoor is de geheugencomplexiteit lineair ten opzichte van de grootte van de input.

4. **Optimalisatie & Code Quality**
Hoewel de code goed leesbaar en modern is (gebruik van C# 12 target-typed new expressions `[]`), zijn er enkele knelpunten en optimalisatiemogelijkheden:
* **Prestatieknelpunt (`CalcWeightFromMass`):** 
  * `mass.ToList()` allocatied onnodig een `List<char>` voor elke massa. Dit kan direct worden opgelost met LINQ (`mass.Sum(char.GetNumericValue)`) of nog beter, een traditionele `for`-loop om LINQ-overhead en enumerator-allocaties te vermijden.
  * Het gebruik van `double` voor de som van cijfers is overbodig; cijfers optellen resulteert altijd in een geheel getal, dus `int` of `long` is passender en sneller.
* **Redundante checks:** 
  * De vroegereturn-check `if (!strng.Contains(' '))` is overbodig. Als de string geen spaties bevat, zal `Split(' ')` een array met één element retourneren, en de logica zal nog steeds correct functioneren zonder deze extra `Contains`-aanroep.
* **Geheugenallocatie:** 
  * Door te vermijden dat `mass.ToList()` en `string.Split(...).ToList()` worden aangeroepen, kan het aantal heap-allocaties aanzienlijk worden verminderd. Dit is vooral voordelig bij grotere datasets in high-performance omgevingen.