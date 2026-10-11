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

// Nieuve static klasse naast PositionExtensions
internal static class FieldExtensions
{
    public static bool IsOutOfBounds(this Position position, int width, int height)
        => position.X < 0 || position.Y < 0
        || position.X >= width || position.Y >= height;

    public static PossibleValue GetValue(this Position position, int[,] field)
    {
        var width = field.GetLength(1);
        var height = field.GetLength(0);

        if (position.IsOutOfBounds(width, height))
        {
            return PossibleValue.OOB;
        }

        return field[position.Y, position.X] == 1 ? PossibleValue.ONE : PossibleValue.NIL;
    }

    public static bool IsVisited(this Position position, bool[,] visited)
        => visited[position.X, position.Y];

    public static void MarkAsVisited(this Position position, bool[,] visited)
        => visited[position.X, position.Y] = true;

    public static IEnumerable<Position> AllPositions(this int[,] field)
    {
        var height = field.GetLength(0);
        var width = field.GetLength(1);

        for (int y = 0; y < height; y++)
        {
            for (int x = 0; x < width; x++)
            {
                yield return new Position(x, y);
            }
        }
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

    private int Width => this.field.GetLength(1);

    private int Height => this.field.GetLength(0);

    internal static bool SequenceEqual(int[] a, int[] b) =>
        a?.SequenceEqual(b ?? Array.Empty<int>()) == true;

    internal Orthogonals GetOrthogonals(Position position)
    => new(
        position.GetNeighbour(Direction.UP).GetValue(this.field),
        position.GetNeighbour(Direction.RIGHT).GetValue(this.field),
        position.GetNeighbour(Direction.DOWN).GetValue(this.field),
        position.GetNeighbour(Direction.LEFT).GetValue(this.field));

    internal Diagonals GetDiagonals(Position position)
    => new(
        position.GetNeighbour(Direction.UP_RIGHT).GetValue(this.field),
        position.GetNeighbour(Direction.DOWN_RIGHT).GetValue(this.field),
        position.GetNeighbour(Direction.DOWN_LEFT).GetValue(this.field),
        position.GetNeighbour(Direction.UP_LEFT).GetValue(this.field));

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
        bool[,] visitedCells = new bool[this.Width, this.Height];
        List<Ship> ships = [];
        foreach (var position in this.field.AllPositions())
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

    private static bool IsValidSetOfShips(IReadOnlyList<Ship> ships)
    {
        int[] shipLengthsCount = new int[5];
        foreach (Ship ship in ships)
        {
            shipLengthsCount[ship.GetLength()]++;
        }

        int[] expected = [0, 4, 3, 2, 1];
        return SequenceEqual(shipLengthsCount, expected);
    }

    private ShipWithValidation FindShip(Position start, bool[,] visited)
    {
        var current = start;
        var direction = this.InWhatDirectionDoesShipContinue(start);

        while (current.GetNeighbour(direction).GetValue(this.field) == PossibleValue.ONE)
        {
            current = current.GetNeighbour(direction);
            current.MarkAsVisited(visited);

            if (this.ADiagonalContainsShipPart(current))
            {
                return new ShipWithValidation(null, FieldValidityAssessment.DiagonalTouchingShip);
            }
        }

        var ship = new Ship(start, current);
        return new ShipWithValidation(ship, null);
    }

    private bool TryProcessCell(Position position, bool[,] visited, List<Ship> ships, out FieldValidityAssessment? error)
    {
        error = null;

        if (position.IsVisited(visited))
        {
            return true;
        }

        position.MarkAsVisited(visited);

        if (position.GetValue(this.field) != PossibleValue.ONE)
        {
            return true;
        }

        if (this.TwoOrthogonalsContainShipPart(position))
        {
            error = FieldValidityAssessment.OrthogonalTouchingShip;
            return false;
        }

        if (this.ADiagonalContainsShipPart(position))
        {
            error = FieldValidityAssessment.DiagonalTouchingShip;
            return false;
        }

        if (this.DoesShipContinueFrom(position))
        {
            var result = this.FindShip(position, visited);

            if (result.ValidationError.HasValue)
            {
                error = result.ValidationError;
                return false;
            }

            if (result.Ship is not Ship ship)
            {
                throw new InvalidOperationException();
            }

            ships.Add(ship);
        }
        else
        {
            ships.Add(new Ship(position, position));
        }

        return true;
    }

    private Direction InWhatDirectionDoesShipContinue(Position position)
    => position.GetNeighbour(Direction.RIGHT).GetValue(this.field) == PossibleValue.ONE ?
        Direction.RIGHT :
        Direction.DOWN;

    private bool ADiagonalContainsShipPart(Position position) => this.GetDiagonals(position).UpRight == PossibleValue.ONE
        || this.GetDiagonals(position).DownRight == PossibleValue.ONE
        || this.GetDiagonals(position).DownLeft == PossibleValue.ONE
        || this.GetDiagonals(position).UpLeft == PossibleValue.ONE;

    private bool TwoOrthogonalsContainShipPart(Position position)
    {
        var orthogonals = this.GetOrthogonals(position);

        int count = 0;
        count += orthogonals.Up == PossibleValue.ONE ? 1 : 0;
        count += orthogonals.Right == PossibleValue.ONE ? 1 : 0;
        count += orthogonals.Down == PossibleValue.ONE ? 1 : 0;
        count += orthogonals.Left == PossibleValue.ONE ? 1 : 0;
        return count >= 2;
    }

    private bool DoesShipContinueFrom(Position position)
    {
        Orthogonals orthogonals = this.GetOrthogonals(position);

        return orthogonals.Right == PossibleValue.ONE
        || orthogonals.Down == PossibleValue.ONE;
    }

    private readonly record struct ShipWithValidation(
    Ship? Ship,
    FieldValidityAssessment? ValidationError);
}

internal sealed class GetShipsResult(FieldValidityAssessment assessment, List<Ship> ships)
{
    internal FieldValidityAssessment InvalidSetupReason { get; set; } = assessment;

    internal IReadOnlyList<Ship> Ships { get; } = ships;
}

internal sealed record Ship(Position Start, Position End);

internal sealed record Position(int X, int Y);

internal sealed record Orthogonals(PossibleValue Up, PossibleValue Right, PossibleValue Down, PossibleValue Left);

internal sealed record Diagonals(PossibleValue UpRight, PossibleValue DownRight, PossibleValue DownLeft, PossibleValue UpLeft);