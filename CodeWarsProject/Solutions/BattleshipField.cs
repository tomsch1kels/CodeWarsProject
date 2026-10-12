// https://www.codewars.com/kata/52bb6539a4cf1b12d90005b7
// 3 kyu
// Test new workflow 1713

namespace CodeWarsProject.Solutions;

using System.Collections.ObjectModel;

public enum PossibleValue
{
    /// <summary>
    /// Out of bounds.
    /// </summary>
    OutOfBounds,

    /// <summary>
    /// Zero, water.
    /// </summary>
    Nil,

    /// <summary>
    /// One, a ship.
    /// </summary>
    One,
}

public enum Direction
{
    Up,
    UpRight,
    Right,
    DownRight,
    Down,
    DownLeft,
    Left,
    UpLeft,
}

public enum FieldValidityAssessment
{
    SetupIsValid,
    DiagonalTouchingShip,
    OrthogonalTouchingShip,
}

public static class ShipExtensions
{
    public static int GetLength(this Ship ship)
    {
        ArgumentNullException.ThrowIfNull(ship);

        return 1 + Math.Max(
        Math.Abs(ship.Start.X - ship.End.X),
        Math.Abs(ship.Start.Y - ship.End.Y));
    }
}

public static class PositionExtensions
{
    public static Position GetNeighbour(this Position position, Direction direction)
    {
        ArgumentNullException.ThrowIfNull(position);

        var (dx, dy) = direction switch
        {
            Direction.Up => (0, -1),
            Direction.Right => (1, 0),
            Direction.Down => (0, 1),
            Direction.Left => (-1, 0),
            Direction.UpRight => (1, -1),
            Direction.DownRight => (1, 1),
            Direction.DownLeft => (-1, 1),
            Direction.UpLeft => (-1, -1),
            _ => throw new ArgumentOutOfRangeException(nameof(direction)),
        };

        return new(position.X + dx, position.Y + dy);
    }
}

// Nieuve static klasse naast PositionExtensions
public static class FieldExtensions
{
    public static bool IsOutOfBounds(this Position position, int width, int height)
    {
        ArgumentNullException.ThrowIfNull(position);
        return position.X < 0 || position.Y < 0
            || position.X >= width || position.Y >= height;
    }

    public static PossibleValue GetValue(this Position position, int[,] field)
    {
        ArgumentNullException.ThrowIfNull(field);

        var width = field.GetLength(1);
        var height = field.GetLength(0);

        if (position.IsOutOfBounds(width, height))
        {
            return PossibleValue.OutOfBounds;
        }

        return field[position.Y, position.X] == 1 ? PossibleValue.One : PossibleValue.Nil;
    }

    public static bool IsVisited(this Position position, bool[,] visited)
    {
        ArgumentNullException.ThrowIfNull(position);
        ArgumentNullException.ThrowIfNull(visited);
        return visited[position.X, position.Y];
    }

    public static void MarkAsVisited(this Position position, bool[,] visited)
    {
        ArgumentNullException.ThrowIfNull(position);
        ArgumentNullException.ThrowIfNull(visited);
        visited[position.X, position.Y] = true;
    }

    public static IEnumerable<Position> AllPositions(this int[,] field)
    {
        ArgumentNullException.ThrowIfNull(field);
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

public static class BattleshipField
{
    public static bool ValidateBattlefield(int[,] field)
    => new BattleshipFieldSolver(field).Solve();
}

public sealed class BattleshipFieldSolver(int[,] field)
{
    private readonly int[,] field = field;

    private int Width => this.field.GetLength(1);

    private int Height => this.field.GetLength(0);

    public static bool SequenceEqual(int[] a, int[] b) =>
        a.SequenceEqual(b) == true;

    public Orthogonals GetOrthogonals(Position position)
    => new(
        position.GetNeighbour(Direction.Up).GetValue(this.field),
        position.GetNeighbour(Direction.Right).GetValue(this.field),
        position.GetNeighbour(Direction.Down).GetValue(this.field),
        position.GetNeighbour(Direction.Left).GetValue(this.field));

    public Diagonals GetDiagonals(Position position)
    => new(
        position.GetNeighbour(Direction.UpRight).GetValue(this.field),
        position.GetNeighbour(Direction.DownRight).GetValue(this.field),
        position.GetNeighbour(Direction.DownLeft).GetValue(this.field),
        position.GetNeighbour(Direction.UpLeft).GetValue(this.field));

    public GetShipsResult GetShips()
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
        Collection<Ship> ships = [];
        foreach (var position in this.field.AllPositions())
        {
            if (!this.TryProcessCell(position, visitedCells, ships, out var error))
            {
                if (error is null)
                {
                    throw new InvalidOperationException();
                }

                return new(error.Value, []);
            }
        }

        return new(FieldValidityAssessment.SetupIsValid, ships);
    }

    public bool Solve()
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

        while (current.GetNeighbour(direction).GetValue(this.field) == PossibleValue.One)
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

    private bool TryProcessCell(Position position, bool[,] visited, Collection<Ship> ships, out FieldValidityAssessment? error)
    {
        error = null;

        if (position.IsVisited(visited))
        {
            return true;
        }

        position.MarkAsVisited(visited);

        if (position.GetValue(this.field) != PossibleValue.One)
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
    => position.GetNeighbour(Direction.Right).GetValue(this.field) == PossibleValue.One ?
        Direction.Right :
        Direction.Down;

    private bool ADiagonalContainsShipPart(Position position) => this.GetDiagonals(position).UpRight == PossibleValue.One
        || this.GetDiagonals(position).DownRight == PossibleValue.One
        || this.GetDiagonals(position).DownLeft == PossibleValue.One
        || this.GetDiagonals(position).UpLeft == PossibleValue.One;

    private bool TwoOrthogonalsContainShipPart(Position position)
    {
        var orthogonals = this.GetOrthogonals(position);

        int count = 0;
        count += orthogonals.Up == PossibleValue.One ? 1 : 0;
        count += orthogonals.Right == PossibleValue.One ? 1 : 0;
        count += orthogonals.Down == PossibleValue.One ? 1 : 0;
        count += orthogonals.Left == PossibleValue.One ? 1 : 0;
        return count >= 2;
    }

    private bool DoesShipContinueFrom(Position position)
    {
        Orthogonals orthogonals = this.GetOrthogonals(position);

        return orthogonals.Right == PossibleValue.One
        || orthogonals.Down == PossibleValue.One;
    }

    private readonly record struct ShipWithValidation(
    Ship? Ship,
    FieldValidityAssessment? ValidationError);
}

public sealed class GetShipsResult(FieldValidityAssessment assessment, Collection<Ship> ships)
{
    public FieldValidityAssessment InvalidSetupReason { get; set; } = assessment;

    public IReadOnlyList<Ship> Ships { get; } = ships;
}

public sealed record Ship(Position Start, Position End);

public sealed record Position(int X, int Y);

public sealed record Orthogonals(PossibleValue Up, PossibleValue Right, PossibleValue Down, PossibleValue Left);

public sealed record Diagonals(PossibleValue UpRight, PossibleValue DownRight, PossibleValue DownLeft, PossibleValue UpLeft);