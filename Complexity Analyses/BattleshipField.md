# 🧠 Complexiteitsanalyse: BattleshipField

*Bronbestand: [BattleshipField.cs](../Solutions/BattleshipField.cs)*

---

1. **Complexiteit**: 
   - **Tijdcomplexiteit**: $\mathcal{O}(N \times M)$ (waarbij $N$ en $M$ de dimensies van het speelveld zijn), omdat elke cel maximaal een constante aantal keren wordt bezocht en gecontroleerd op buren.
   - **Ruimtecomplexiteit**: $\mathcal{O}(N \times M)$ vanwege de `visited` boolean matrix en de opslag van gevonden schepen in een lijst.

2. **Efficiëntst?**: 
   - **Ja**, de asymptotische tijdscomplexiteit is optimaal ($\mathcal{O}(N \times M)$), aangezien elk veld en elke cel minstens één keer gelezen moet worden om een geldig antwoord te garanderen.

3. **Optimalisatiemogelijkheid**: 
   - Hoewel de Big O-complexiteit optimaal is, kan de *constante factor* en geheugenallocatie worden verbeterd. De huidige code maakt intensief gebruik van LINQ (`SequenceEqual`), extra objecten (`Position`, `Ship`, records voor `Orthogonals`/`Diagonals`) en toekenningslogica per cel. Dit kan worden geoptimaliseerd door:
     - Het vermijden van `record` allocaties voor orthogonale en diagonale checks door primitieve arrays of bitwise operaties te gebruiken.
     - Het in-place markeren/verwerken van schepen tijdens de iteratie, waardoor de `visited`-matrix of zelfs de gehele lijst van `Ship`-objecten kan worden vermeden; alleen het direct bijhouden en valideren van de tellingen per lengte is voldoende.