# 🧠 Complexiteitsanalyse: InsertNth

*Bronbestand: [InsertNth.cs](../Solutions/InsertNth.cs)*

---

# Analyse van `InsertNth.cs` (Codewars Kata)

## 1. Overzicht & Samenvatting
Deze C#-implementatie lost de klassieke gekoppelde lijst (linked list) insertie-kata op. De methode `InsertNth` voegt een nieuw `Node`-object in op een specifieke 0-gebaseerde index binnen een gekoppelde lijst. 

De gekozen aanpak werkt iteratief:
1. Er wordt gecontroleerd of de `head` null is; zo ja, dan wordt er direct een nieuwe `Node` geretourneerd (wat in de context van deze specifieke Codewars-kata kennelijk de verwachte fallback is).
2. De methode valideert dat de index niet negatief is via `ArgumentOutOfRangeException.ThrowIfNegative`.
3. Vervolgens wordt er door de lijst gelopen tot de gewenste index is bereikt, waarbij zowel de `current` als de `previous` node worden bijgehouden.
4. Tot slot wordt een nieuwe `Node` aangemaakt, correct gekoppeld tussen `previous` en `current` (of aan het begin van de lijst geplaatst als `previous` null is), en wordt de referentie naar het begin van de lijst geretourneerd.

## 2. Tijdscomplexiteit (Time Complexity)
* **Big O-notatie:** $\mathcal{O}(n)$
* **Onderbouwing:** In het slechtste geval (of bij een willekeurige geldige index $index$) moet de `for`-lus $index$ keer itereren om de juiste positie in de gekoppelde lijst te vinden. Omdat het aantal iteraties lineair schaalt met de waarde van de index (waar $n$ de lengte van de lijst of de doelenindex voorstelt), is de tijdscomplexiteit lineair: $\mathcal{O}(n)$. De operaties binnen de lus (pointer-verschuivingen) kosten $\mathcal{O}(1)$ per iteratie.

## 3. Ruimtecomplexiteit (Space Complexity)
* **Big O-notatie:** $\mathcal{O}(1)$
* **Onderbouwing:** De algoritme gebruikt een vast aantal lokale variabelen (`current`, `previous`, `newNode`) ongeacht de lengte van de gekoppelde lijst of de grootte van de index. Er worden geen collecties of recursieve calls gebruikt die extra geheugen op de stack of heap consumeren (afgezien van het alloceren van exact één nieuwe node die wordt ingevoegd). Dit resulteert in een constante ruimtecomplexiteit van $\mathcal{O}(1)$.

## 4. Optimalisatie & Code Quality
* **Sterke punten:**
  * **Moderne C#-features:** Het gebruik van `ArgumentOutOfRangeException.ThrowIfNegative` is idiomatisch en efficiënt voor .NET 8+.
  * **Null-safety:** De code houdt rekening met null-waarden en gooit een duidelijke `InvalidOperationException` als de lijst onverwacht voortijdig end (hoewel dit bij een correcte index buiten de grenzen van de lijst zou vallen; in deze kata wordt echter vaak aangenomen dat de index geldig is of dat er automatisch wordt uitgebreid).
  * **Geheugenbeheer:** Geen geheugenlekken; .NET's Garbage Collector handelt het opruimen af, en er worden geen circulaire referenties geïntroduceerd.
* **Knelpunten & Verbeterpunten:**
  * **Index buiten bereik:** Als de opgegeven `index` groter is dan de lengte van de gekoppelde lijst, zal `current` op `null` uitkomen tijdens de loop. De expressie `previous = current ?? throw ...` gooit dan een `InvalidOperationException`. Afhankelijk van de eisen van de kata is een `ArgumentOutOfRangeException` vaak passender wanneer een index buiten de grenzen valt.
  * **C# 12 Primary Constructors:** De klasse maakt gebruik van een primary constructor (`internal sealed partial class Node()`), wat modern oogt, maar voor een gekoppelde lijst node is het raadzaam om ook een constructor te voorzien waarmee direct een waarde of een `next`-referentie kan worden meegeleverd om boilerplate te verminderen.