# 🧠 Complexiteitsanalyse: GreedIsGood

*Bronbestand: [GreedIsGood.cs](../Solutions/GreedIsGood.cs)*

---

1. **Overzicht & Samenvatting**
De huidige implementatie is een placeholder (stub) die enkel een lege array accepteert en altijd `0` retourneert. Om het "Greed is Good" kata op te lossen, moet de logica het aantal ogen van vijf dobbelstenen tellen en de score berekenen volgens specifieke spelregels (bijv. drie dezelfde dobbelstenen leveren extra punten op, en losse enen en vijven zijn ook punten waard). Een geschikte aanpak is het bijhouden van de frequentie van elk dobbelsteennummer (1 t/m 6), bijvoorbeeld via een array van lengte 7 of een `Dictionary`, en vervolgens de regels iteratief toe te passen.

2. **Tijdscomplexiteit (Time Complexity)**
* **Huidige code:** $\mathcal{O}(1)$, aangezien de methode direct `0` retourneert ongeacht de invoer.
* **Ideale implementatie:** $\mathcal{O}(n)$, waarbij $n$ het aantal dobbelstenen is (in dit kata altijd vast op 5). Omdat het aantal elementen constant is, is de tijdcomplexiteit in de praktijk $\mathcal{O}(1)$ (constante tijd). Het itereren over de vaste set van 5 dobbelstenen en het controleren van de 6 mogelijke waarden kost een verwaarloosbare, vaste hoeveelheid tijd.

3. **Ruimtecomplexiteit (Space Complexity)**
* **Huidige code:** $\mathcal{O}(1)$, er wordt geen extra geheugen gealloceerd.
* **Ideale implementatie:** $\mathcal{O}(1)$. Om de frequenties van de dobbelstenen bij te houden is slechts een vaste array van 7 integers (`int[7]`) benodigd. Dit geheugenverbruik schaalt niet mee met grotere datasets en blijft constant.

4. **Optimalisatie & Code Quality**
* **Invoer Validatie:** De huidige code negeert de invoer (`_ = dice;`). Een robuuste implementatie moet controleren of `dice` niet `null` is en exact uit 5 elementen bestaat.
* **Leesbaarheid:** Het gebruik van een vaste frequentie-array (bucket sort-achtig) heeft de voorkeur boven LINQ-queries (`GroupBy`, `Where`) vanwege betere prestaties en minder geheugenallocatie (geen boxing/unboxing of iterators).
* **Magic Numbers:** Het is aan te raden om de scorewaarden (bijv. 1000 voor drie enen, 100 voor een losse een) op te slaan in duidelijke constanten of een configuratiestructuur om de onderhoudbaarheid te vergroten.