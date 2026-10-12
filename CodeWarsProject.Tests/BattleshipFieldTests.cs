namespace CodeWarsProject.Tests;

using CodeWarsProject.Solutions;

[TestFixture]
public sealed class BattleshipFieldTests
{
    [Test]
    public void TestShipIsFound_Horizontal3()
    {
        List<Ship> expected = [new Ship(new Position(0, 0), new Position(2, 0))];
        int[,] input =
        {
            { 1, 1, 1 },
            { 0, 0, 0 },
        };
        Assert.That(new BattleshipFieldSolver(input).GetShips().Ships, Is.EqualTo(expected));
    }

    [Test]
    public void TestShipIsFound_Vertical2()
    {
        List<Ship> expected = [new Ship(new Position(0, 0), new Position(0, 1))];
        int[,] input =
        {
            { 1, 0, 0 },
            { 1, 0, 0 },
        };
        Assert.That(new BattleshipFieldSolver(input).GetShips().Ships, Is.EqualTo(expected));
    }

    [Test]
    public void TestShipIsFound_1()
    {
        List<Ship> expected = [new Ship(new Position(1, 2), new Position(1, 2))];
        int[,] input =
        {
            { 0, 0 },
            { 0, 0 },
            { 0, 1 },
        };
        Assert.That(new BattleshipFieldSolver(input).GetShips().Ships, Is.EqualTo(expected));
    }

    [Test]
    public void TestMultipleShipsAreFound()
    {
        List<Ship> expected = [
            new Ship(new Position(0, 0), new Position(1, 0)),
            new Ship(new Position(1, 2), new Position(1, 2))
            ];
        int[,] input =
        {
            { 1, 1 },
            { 0, 0 },
            { 0, 1 },
        };
        Assert.That(new BattleshipFieldSolver(input).GetShips().Ships, Is.EqualTo(expected));
    }

    [Test]
    public void TestInvalidSetupIsFound_Diagonal()
    {
        FieldValidityAssessment expected = FieldValidityAssessment.DiagonalTouchingShip;
        int[,] input =
        {
            { 1, 0 },
            { 0, 1 },
        };
        Assert.That(new BattleshipFieldSolver(input).GetShips().InvalidSetupReason, Is.EqualTo(expected));
    }

    [Test]
    public void TestInvalidSetupIsFound_Diagonal2()
    {
        FieldValidityAssessment expected = FieldValidityAssessment.DiagonalTouchingShip;
        int[,] input =
        {
            { 1, 1, 0 },
            { 0, 0, 1 },
        };
        Assert.That(new BattleshipFieldSolver(input).GetShips().InvalidSetupReason, Is.EqualTo(expected));
    }

    [Test]
    public void TestInvalidSetupIsFound_Orthogonal()
    {
        FieldValidityAssessment expected = FieldValidityAssessment.OrthogonalTouchingShip;
        int[,] input =
        {
            { 1, 1 },
            { 1, 0 },
        };
        Assert.That(new BattleshipFieldSolver(input).GetShips().InvalidSetupReason, Is.EqualTo(expected));
    }

    [Test]
    public void TestInvalidSetupIsFound_OrthogonalButDiagonalWarning()
    {
        FieldValidityAssessment expected = FieldValidityAssessment.DiagonalTouchingShip;
        int[,] input =
        {
            { 1, 1 },
            { 0, 1 },
        };
        Assert.That(new BattleshipFieldSolver(input).GetShips().InvalidSetupReason, Is.EqualTo(expected));
    }

    [Test]
    public void TestGetOrthogonals()
    {
        Orthogonals expected = new(
            PossibleValue.Nil,
            PossibleValue.One,
            PossibleValue.Nil,
            PossibleValue.One);
        int[,] input =
        {
            { 1, 0, 1 },
            { 1, 1, 1 },
            { 1, 0, 0 },
        };
        Position position = new(1, 1);
        Assert.That(new BattleshipFieldSolver(input).GetOrthogonals(position), Is.EqualTo(expected));
    }

    [Test]
    public void TestGetOrthogonals2()
    {
        Orthogonals expected = new(
            PossibleValue.One,
            PossibleValue.Nil,
            PossibleValue.OutOfBounds,
            PossibleValue.OutOfBounds);
        int[,] input =
        {
            { 1, 0, 1 },
            { 1, 1, 1 },
            { 1, 0, 0 },
        };
        Position position = new(0, 2);
        Assert.That(new BattleshipFieldSolver(input).GetOrthogonals(position), Is.EqualTo(expected));
    }

    [Test]
    public void TestMapCoordinates_NilValues()
    {
        int[,] input =
        {
            { 0, 0 },
            { 1, 0 },
        };
        var solver = new BattleshipFieldSolver(input);

        using (Assert.EnterMultipleScope())
        {
            Assert.That(new Position(0, 0).GetValue(input), Is.EqualTo(PossibleValue.Nil));
            Assert.That(new Position(0, 1).GetValue(input), Is.EqualTo(PossibleValue.One));
            Assert.That(new Position(1, 0).GetValue(input), Is.EqualTo(PossibleValue.Nil));
            Assert.That(new Position(1, 1).GetValue(input), Is.EqualTo(PossibleValue.Nil));
        }
    }

    [Test]
    [TestCase(-1, 0, PossibleValue.OutOfBounds)]
    [TestCase(0, 2, PossibleValue.OutOfBounds)]
    [TestCase(2, 0, PossibleValue.OutOfBounds)]
    [TestCase(0, -1, PossibleValue.OutOfBounds)]
    public void TestMapCoordinates_OutOfBounds(int x, int y, PossibleValue expected)
    {
        int[,] input =
        {
            { 0, 0 },
            { 1, 0 },
        };
        var solver = new BattleshipFieldSolver(input);

        Assert.That(new Position(x, y).GetValue(input), Is.EqualTo(expected));
    }

    [Test]
    public void TestCase()
    {
        int[,] field = new int[10, 10]
        {
            { 1, 0, 0, 0, 0, 1, 1, 0, 0, 0 },
            { 1, 0, 1, 0, 0, 0, 0, 0, 1, 0 },
            { 1, 0, 1, 0, 1, 1, 1, 0, 1, 0 },
            { 1, 0, 0, 0, 0, 0, 0, 0, 0, 0 },
            { 0, 0, 0, 0, 0, 0, 0, 0, 1, 0 },
            { 0, 0, 0, 0, 1, 1, 1, 0, 0, 0 },
            { 0, 0, 0, 0, 0, 0, 0, 0, 1, 0 },
            { 0, 0, 0, 1, 0, 0, 0, 0, 0, 0 },
            { 0, 0, 0, 0, 0, 0, 0, 1, 0, 0 },
            { 0, 0, 0, 0, 0, 0, 0, 0, 0, 0 },
        };
        Assert.That(BattleshipField.ValidateBattlefield(field), Is.True);
    }

    [Test]
    public void ArrayEqualsTest()
    {
        Assert.That(BattleshipFieldSolver.SequenceEqual([1, 2], [1, 2]), Is.True);
        Assert.That(BattleshipFieldSolver.SequenceEqual([1, 2], [1, 1]), Is.False);
        Assert.That(BattleshipFieldSolver.SequenceEqual([1, 2], [1]), Is.False);
    }

    // [Test]
    // [TestCase(0, "now")]
    // [TestCase(1, "1 second")]
    // public void Tests(int numberOfSeconds, string expected)
    //  => Assert.That(HumanTimeFormat.FormatDuration(numberOfSeconds), Is.EqualTo(expected));
}
