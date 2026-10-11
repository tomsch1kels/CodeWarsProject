# Battleship Field Validator

## Code Structure

```mermaid
## Code Structuur

```mermaid
classDiagram
    %% ENUMS
    class PossibleValue {
        <<enumeration>>
        OOB
        NIL
        ONE
    }
    
    class Direction {
        <<enumeration>>
        UP
        UP_RIGHT
        RIGHT
        DOWN_RIGHT
        DOWN
        DOWN_LEFT
        LEFT
        UP_LEFT
    }
    
    class FieldValidityAssessment {
        <<enumeration>>
        SetupIsValid
        OrthogonalTouchingShip
        DiagonalTouchingShip
    }
    
    %% VALUE TYPES / RECORDS
    class Position {
        +int X
        +int Y
        +Equals(Position?) bool
        +GetHashCode() int
    }
    
    class Ship {
        +Position Start
        +Position End
        +Equals(Ship?) bool
        +GetHashCode() int
        +GetLength() int
    }
    
    class Orthogonals {
        +PossibleValue Up
        +PossibleValue Right
        +PossibleValue Down
        +PossibleValue Left
        +Equals(Orthogonals?) bool
        +GetHashCode() int
    }
    
    class Diagonals {
        +PossibleValue UpRight
        +PossibleValue DownRight
        +PossibleValue DownLeft
        +PossibleValue UpLeft
        +Equals(Diagonals?) bool
        +GetHashCode() int
    }
    
    class GetShipsResult {
        +FieldValidityAssessment Assessment
        +IReadOnlyList~Ship~ Ships
        +IsValid bool
    }
    
    %% EXTENSION CLASSES (Static)
    class PositionExtensions {
        <<static>>
        +GetNeighbour(Position, Direction) Position
    }
    
    class ShipExtensions {
        <<static>>
        +GetLength(Ship) int
        +IsHorizontal(Ship) bool
        +IsVertical(Ship) bool
    }
    
    class FieldExtensions {
        <<static>>
        +IsOutOfBounds(Position, int, int) bool
        +GetValue(Position, int[,]) PossibleValue
        +IsVisited(Position, bool[,]) bool
        +MarkAsVisited(Position, bool[,]) void
        +AllPositions(int[,]) IEnumerable~Position~
    }
    
    class BattleshipField {
        <<static>>
        +ValidateBattlefield(int[,]) bool
    }
    
    %% CORE LOGIC
    class BattleshipFieldSolver {
        -int[,] field
        -int Width
        -int Height
        +BattleshipFieldSolver(int[,])
        +GetShips() GetShipsResult
        +Solve() bool
        #GetValue(Position) PossibleValue
        #GetOrthogonals(Position) Orthogonals
        #GetDiagonals(Position) Diagonals
        -TryProcessCell(Position, bool[,], List~Ship~, FieldValidityAssessment?) bool
        -FindShip(Position, bool[,]) ShipWithValidation
        -ValidatePositionNeighbors(Position) ValidationResult
        -TraverseFieldPositions() IEnumerable~Position~
        -DoesShipContinueFrom(Position) bool
        -InWhatDirectionDoesShipContinue(Position) Direction
        -IsVisited(Position, bool[,]) bool
        -MarkAsVisited(Position, bool[,]) void
    }
    
    %% HELPER STRUCTS
    class ShipWithValidation {
        <<record struct>>
        +Ship? Ship
        +FieldValidityAssessment? ValidationError
    }
    
    class ValidationResult {
        <<record struct>>
        +bool IsValid
        +FieldValidityAssessment? Violation
    }
    
    %% RELATIONSHIPS
    PositionExtensions --> Position
    ShipExtensions --> Ship
    FieldExtensions --> Position
    FieldExtensions --> "int[,]" BattleshipFieldSolver
    
    BattleshipField --> BattleshipFieldSolver
    BattleshipFieldSolver --> Position
    BattleshipFieldSolver --> Ship
    BattleshipFieldSolver --> Orthogonals
    BattleshipFieldSolver --> Diagonals
    BattleshipFieldSolver --> GetShipsResult
    BattleshipFieldSolver --> ShipWithValidation
    BattleshipFieldSolver --> ValidationResult
    
    GetShipsResult --> Ship
    Ship --> Position
    
    %% STYLING
    style BattleshipFieldSolver fill:#6d4aff,color:#fff
    style BattleshipField fill:#6d4aff,color:#fff
    style PositionExtensions fill:#f0f0f0
    style ShipExtensions fill:#f0f0f0
    style FieldExtensions fill:#f0f0f0
```