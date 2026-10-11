# 🧠 Complexiteitsanalyse: HumanTimeFormat

*Bronbestand: [HumanTimeFormat.cs](../Solutions/HumanTimeFormat.cs)*

---

1. **Complexiteit**: 
   - Tijdcomplexiteit: $\mathcal{O}(1)$ (de berekeningen en lijstoperaties hebben een constante maximale grootte omdat het aantal tijdseenheden begrensd is).
   - Ruimtecomplexiteit: $\mathcal{O}(1)$ (het aantal variabelen en de grootte van de `subStrings`-lijst is altijd maximaal 5).

2. **Efficiëntst?**: Ja. 
   De tijdscomplexiteit is $\mathcal{O}(1)$, wat theoretisch optimaal is omdat het aantal te verwerken tijdseenheden vaststaat en niet schaalt met de invoer.

3. **Optimalisatiemogelijkheid**: 
   Vanuit een Big O-perspectief is de code al optimaal. Wel kan de code iets efficiënter worden gemaakt in termen van geheugenallocatie en leesbaarheid. Dit kan door overbodige LINQ-methoden (`.Where()`, `.TakeLast()`, `.Append()`) te vermijden en in plaats daarvan te werken met een `Span<T>` of een vooraf toegewezen `StringBuilder` / array met vaste grootte voor het samenvoegen van de strings. Ook muteert `DetermineAmounts()` nu de state buiten de functie; het teruggeven van een tuple zou de code zuiverder (functional) maken zonder prestatieverlies.