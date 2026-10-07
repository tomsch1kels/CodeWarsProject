# 🧠 Complexiteitsanalyse: HumanTimeFormat

*Bronbestand: [HumanTimeFormat.cs](../Solutions/HumanTimeFormat.cs)*

---

1. **Complexiteit**: 
   - **Tijdcomplexiteit**: $\mathcal{O}(1)$ (omdat de invoer een eindig bereik heeft en de berekeningen een constant aantal operaties vereisen).
   - **Ruimtecomplexiteit**: $\mathcal{O}(1)$ (er wordt een vaste, kleine hoeveelheid geheugen alocatie gebruikt voor de lijst van sub-strings).

2. **Efficiëntst?**: 
   - **Ja**, de implementatie heeft de optimale Big O tijdscomplexiteit ($\mathcal{O}(1)$) die voor dit probleem mogelijk is.

3. **Optimalisatiemogelijkheid**: 
   - De huidige oplossing is al optimaal qua asymptotische complexiteit. Qua *micro-optimalisatie* zou men het geheugenverbruik (garbage collection druk) kunnen verminderen door geen `List<string>` en LINQ-methoden (`Where`, `TakeLast`, `Append`) te gebruiken, maar in plaats daarvan een `Span<char>` of `ValueStringBuilder` te gebruiken om de string direct op te bouwen. Gezien de schaal van het probleem is dit echter niet nodig voor de leesbaarheid.