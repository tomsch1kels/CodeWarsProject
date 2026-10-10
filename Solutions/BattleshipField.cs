// https://www.codewars.com/kata/52bb6539a4cf1b12d90005b7
// 3 kyu

internal enum PossibleValue
{
    /// <summary>
    /// Out of bounds.
    /// </summary>
    OOB,

    /// <summary>
    /// Zero, water.
    /// </summary>
    NIL,

    /// <summary>
    /// One, a ship.
    /// </summary>
    ONE,
}

internal enum Direction
{
    UP,
    UP_RIGHT,
    RIGHT,
    DOWN_RIGHT,
    DOWN,
    DOWN_LEFT,
    LEFT,
    UP_LEFT,
}

internal enum FieldValidityAssessment
{
    SetupIsValid,
    DiagonalTouchingShip,
    OrthogonalTouchingShip,
}

internal static class ShipExtensions
{
    public static int GetLength(this Ship ship) =>
    1 + Math.Max(
        Math.Abs(ship.Start.X - ship.End.X),
        Math.Abs(ship.Start.Y - ship.End.Y));
}

internal static class PositionExtensions
{
    public static Position GetNeighbour(this Position position, Direction direction)
    {
        var (dx, dy) = direction switch
        {
            Direction.UP => (0, -1),
            Direction.RIGHT => (1, 0),
            Direction.DOWN => (0, 1),
            Direction.LEFT => (-1, 0),
            Direction.UP_RIGHT => (1, -1),
            Direction.DOWN_RIGHT => (1, 1),
            Direction.DOWN_LEFT => (-1, 1),
            Direction.UP_LEFT => (-1, -1),
            _ => throw new ArgumentOutOfRangeException(nameof(direction)),
        };

        return new(position.X + dx, position.Y + dy);
    }
}

internal static class BattleshipField
{
    public static bool ValidateBattlefield(int[,] field)
    => new BattleshipFieldSolver(field).Solve();
}

internal sealed class BattleshipFieldSolver
{
    private readonly int[,] field;

    public BattleshipFieldSolver(int[,] field)
    {
        this.field = field;
    }

    internal static bool SequenceEqual(int[] a, int[] b) =>
        a?.SequenceEqual(b ?? Array.Empty<int>()) == true;

    internal Orthogonals GetOrthogonals(Position position)
    => new(
        this.GetValue(position.GetNeighbour(Direction.UP)),
        this.GetValue(position.GetNeighbour(Direction.RIGHT)),
        this.GetValue(position.GetNeighbour(Direction.DOWN)),
        this.GetValue(position.GetNeighbour(Direction.LEFT)));

    internal Diagonals GetDiagonals(Position position)
    => new(
        this.GetValue(position.GetNeighbour(Direction.UP_RIGHT)),
        this.GetValue(position.GetNeighbour(Direction.DOWN_RIGHT)),
        this.GetValue(position.GetNeighbour(Direction.DOWN_LEFT)),
        this.GetValue(position.GetNeighbour(Direction.UP_LEFT)));

    internal GetShipsResult GetShips()
    {
        // PSUEDO CODE
        // walk over all parts of field
        // if a ship part is found
        // look in all directions to find if ship continues
        // if ship continues
        //  look for more ship parts
        //  return ship
        // else
        //  return ship
        bool[,] visitedCells = new bool[this.GetFieldWidth(), this.GetFieldHeight()];
        List<Ship> ships = [];
        foreach (var position in this.TraverseFieldPositions())
        {
            if (!this.TryProcessCell(position, visitedCells, ships, out var error))
            {
                if (error is not FieldValidityAssessment)
                {
                    throw new InvalidOperationException();
                }

                return new(error.Value, []);
            }
        }

        return new(FieldValidityAssessment.SetupIsValid, ships);

        // foreach (Position position in this.TraverseFieldPositions())
        // {
        //     if (IsVisited(position, visitedCells))
        //     {
        //         continue;
        //     }

        //     MarkAsVisited(position, visitedCells);

        //     if (this.GetValue(position) == PossibleValue.ONE)
        //     {
        //         if (TwoOrthogonalsContainShipPart(position))
        //         {
        //             return new(FieldValidityAssessment.OrthogonalTouchingShip, []);
        //         }

        //         if (ADiagonalContainsShipPart(position))
        //         {
        //             return new(FieldValidityAssessment.DiagonalTouchingShip, []);
        //         }

        //         if (this.DoesShipContinueFrom(position))
        //         {
        //             visitedCells[position.X, position.Y] = true;
        //             Position startPosition = position;
        //             Position currentPosition = new(position.X, position.Y);
        //             Direction directionInWhichShipContinues = this.InWhatDirectionDoesShipContinue(position);
        //             while (this.GetValue(currentPosition.GetNeighbour(directionInWhichShipContinues)) == PossibleValue.ONE)
        //             {
        //                 currentPosition = currentPosition.GetNeighbour(directionInWhichShipContinues);
        //                 visitedCells[currentPosition.X, currentPosition.Y] = true;

        //                 if (ADiagonalContainsShipPart(currentPosition))
        //                 {
        //                     return new(FieldValidityAssessment.DiagonalTouchingShip, []);
        //                 }
        //             }

        //             ships.Add(new(startPosition, currentPosition));
        //         }
        //         else
        //         {
        //             ships.Add(new Ship(position, position));
        //         }
        //     }
        // }

        // return new(FieldValidityAssessment.SetupIsValid, ships);

        bool ADiagonalContainsShipPart(Position position) => this.GetDiagonals(position).UpRight == PossibleValue.ONE
            || this.GetDiagonals(position).DownRight == PossibleValue.ONE
            || this.GetDiagonals(position).DownLeft == PossibleValue.ONE
            || this.GetDiagonals(position).UpRight == PossibleValue.ONE;

        bool TwoOrthogonalsContainShipPart(Position position)
        {
            var orthogonals = this.GetOrthogonals(position);

            int count = 0;
            count += orthogonals.Up == PossibleValue.ONE ? 1 : 0;
            count += orthogonals.Right == PossibleValue.ONE ? 1 : 0;
            count += orthogonals.Down == PossibleValue.ONE ? 1 : 0;
            count += orthogonals.Left == PossibleValue.ONE ? 1 : 0;
            return count >= 2;
        }
    }

    internal PossibleValue GetValue(Position position)
    {
        if (PositionIsOutOfBounds())
        {
            return PossibleValue.OOB;
        }

        return this.field[position.Y, position.X] == 1 ? PossibleValue.ONE : PossibleValue.NIL;

        bool PositionIsOutOfBounds()
            => position.X < 0
            || position.Y < 0
            || position.X >= this.field.GetLength(1)
            || position.Y >= this.field.GetLength(0);
    }

    internal bool Solve()
    {
        GetShipsResult shipsResult = this.GetShips();

        if (shipsResult.InvalidSetupReason != FieldValidityAssessment.SetupIsValid)
        {
            return false;
        }

        return IsValidSetOfShips(shipsResult.Ships);
    }

    private static bool IsValidSetOfShips(List<Ship> ships)
    {
        int[] shipLengthsCount = new int[5];
        foreach (Ship ship in ships)
        {
            shipLengthsCount[ship.GetLength()]++;
        }

        int[] expected = [0, 4, 3, 2, 1];
        return SequenceEqual(shipLengthsCount, expected);
    }

    private static bool IsVisited(Position position, bool[,] visited)
    => visited[position.X, position.Y];

    private static void MarkAsVisited(Position position, bool[,] visited)
    => visited[position.X, position.Y] = true;

    private bool TryProcessCell(Position position, bool[,] visited, List<Ship> ships, out FieldValidityAssessment? error)
    {
        error = null;

        if (IsVisited(position, visited))
        {
            return true;
        }

        MarkAsVisited(position, visited);

        if (this.GetValue(position) != PossibleValue.ONE)
        {
            return true;
        }

        if (TwoOrthogonalsContainShipPart(position))
        {
            error = FieldValidityAssessment.OrthogonalTouchingShip;
            return false;
        }

        if (ADiagonalContainsShipPart(position))
        {
            error = FieldValidityAssessment.DiagonalTouchingShip;
            return false;
        }

        if (this.DoesShipContinueFrom(position))
        {
            visited[position.X, position.Y] = true;
            Position startPosition = position;
            Position currentPosition = new(position.X, position.Y);
            Direction directionInWhichShipContinues = this.InWhatDirectionDoesShipContinue(position);
            while (this.GetValue(currentPosition.GetNeighbour(directionInWhichShipContinues)) == PossibleValue.ONE)
            {
                currentPosition = currentPosition.GetNeighbour(directionInWhichShipContinues);
                visited[currentPosition.X, currentPosition.Y] = true;

                if (ADiagonalContainsShipPart(currentPosition))
                {
                    error = FieldValidityAssessment.DiagonalTouchingShip;
                    return false;
                }
            }

            ships.Add(new(startPosition, currentPosition));
        }
        else
        {
            ships.Add(new Ship(position, position));
        }

        return true;

        bool ADiagonalContainsShipPart(Position position) => this.GetDiagonals(position).UpRight == PossibleValue.ONE
            || this.GetDiagonals(position).DownRight == PossibleValue.ONE
            || this.GetDiagonals(position).DownLeft == PossibleValue.ONE
            || this.GetDiagonals(position).UpRight == PossibleValue.ONE;

        bool TwoOrthogonalsContainShipPart(Position position)
        {
            var orthogonals = this.GetOrthogonals(position);

            int count = 0;
            count += orthogonals.Up == PossibleValue.ONE ? 1 : 0;
            count += orthogonals.Right == PossibleValue.ONE ? 1 : 0;
            count += orthogonals.Down == PossibleValue.ONE ? 1 : 0;
            count += orthogonals.Left == PossibleValue.ONE ? 1 : 0;
            return count >= 2;
        }
    }

    private IEnumerable<Position> TraverseFieldPositions()
    {
        foreach (var y in Enumerable.Range(0, this.GetFieldHeight()))
        {
            foreach (var x in Enumerable.Range(0, this.GetFieldWidth()))
            {
                yield return new Position(x, y);
            }
        }
    }

    private int GetFieldWidth() => this.field.GetLength(1);

    private int GetFieldHeight() => this.field.GetLength(0);

    private Direction InWhatDirectionDoesShipContinue(Position position)
    => this.GetValue(position.GetNeighbour(Direction.RIGHT)) == PossibleValue.ONE ?
        Direction.RIGHT :
        Direction.DOWN;

    private bool DoesShipContinueFrom(Position position)
    {
        Orthogonals orthogonals = this.GetOrthogonals(position);

        return orthogonals.Right == PossibleValue.ONE
        || orthogonals.Down == PossibleValue.ONE;
    }
}

internal sealed class GetShipsResult(FieldValidityAssessment invalidSetupReason, List<Ship> ships)
{
    internal FieldValidityAssessment InvalidSetupReason { get; set; } = invalidSetupReason;

    internal List<Ship> Ships { get; set; } = ships;
}

internal sealed record Ship(Position Start, Position End);

internal sealed record Position(int X, int Y);

internal sealed record Orthogonals(PossibleValue Up, PossibleValue Right, PossibleValue Down, PossibleValue Left);

internal sealed record Diagonals(PossibleValue UpRight, PossibleValue DownRight, PossibleValue DownLeft, PossibleValue UpLeft);