# 🧠 Complexiteitsanalyse: BattleshipField

*Bronbestand: [BattleshipField.cs](../Solutions/BattleshipField.cs)*

---

1. **Complexiteit**: 
   - Tijd: $\mathcal{O}(N \times M)$ (waarbij $N$ en $M$ de dimensies van het veld zijn, omdat elke cel maximaal een constante aantal keren wordt bezocht).
   - Ruimte: $\mathcal{O}(N \times M)$ (voor het `visited`-matrix en het opslaan van de schepen).

2. **Efficiëntst?**: 
   Ja. Elke cel hoeft in theorie maar één keer geëvalueerd te worden om schepen te detecteren en te valideren, wat de theoretisch minimale tijdscomplexiteit van $\mathcal{O}(V)$ (aantal cellen) bereikt.

3. **Optimalisatiemogelijkheid**: 
   De huidige oplossing is asymptotisch optimaal. Kleine micro-optimalisaties die de allocatiedruk kunnen verlagen zijn:
   - Het vermijden van het dynamisch aanmaken van `Direction`- en `Position`-objecten in een tight loop.
   - Het vervangen van LINQ-constructies (zoals `SequenceEqual`) door simpele `for`-loops.
   - Het direct retourneren zodra een ongeldig aantal schepen wordt gedetecteerd in plaats van altijd alle schepen volledig uit te lezen.