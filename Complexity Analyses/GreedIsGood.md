# 🧠 Complexiteitsanalyse: GreedIsGood

*Bronbestand: [GreedIsGood.cs](../Solutions/GreedIsGood.cs)*

---

### 1. Complexiteit
* **Tijdcomplexiteit:** $\mathcal{O}(1)$ — De input array heeft altijd een vaste lengte van 5 dobbelstenen, waardoor de uitvoeringstijd constant blijft.
* **Ruimtecomplexiteit:** $\mathcal{O}(1)$ — Er wordt geen extra geheugen gealloceerd dat schaalt met de input.

### 2. Optimalisatiemogelijkheid
De huidige placeholder-implementatie retourneert altijd `0`. Om het kata correct op te lossen is optimalisatie niet direct nodig vanwege de vaste, kleine dataset van 5 elementen. De meest efficiënte aanpak is het tellen van de frequenties van elk get डैश (bijv. via een lookup-array van grootte 7 of LINQ `GroupBy`) en direct de puntentabel toepassen in $\mathcal{O}(1)$ tijd.