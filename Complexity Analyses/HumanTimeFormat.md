# 🧠 Complexiteitsanalyse: HumanTimeFormat

*Bronbestand: [HumanTimeFormat.cs](../Solutions/HumanTimeFormat.cs)*

---

1. **Complexiteit**
   * **Tijdcomplexiteit:** $\mathcal{O}(1)$ — Het aantal tijdseenheden (jaren, dagen, etc.) is vast en groeit niet mee met de invoer.
   * **Ruimtecomplexiteit:** $\mathcal{O}(1)$ — Het aantal gealloceerde variabelen en de lijst met substrings heeft een constante maximale lengte van 5 elementen.

2. **Efficiëntst?**
   * **Ja**, deze implementatie heeft de optimaal mogelijke Big O tijdscomplexiteit ($\mathcal{O}(1)$) omdat het probleem wiskundig direct wordt opgelost zonder iteratieve lussen die schalen met de invoer.

3. **Optimalisatiemogelijkheid**
   * De huidige oplossing is qua Big O al optimaal. Kleine micro-optimalisaties (zoals het vermijden van LINQ-methoden zoals `Where`, `TakeLast` en `Append` ten gunste van traditionele arrays of `Span<T>`) kunnen de overhead van objectallocaties en garbage collection iets verminderen, maar dit heeft nauwelijks impact op de werkelijke uitvoeringstijd voor dit specifieke probleem.