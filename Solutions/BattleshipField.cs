// https://www.codewars.com/kata/52bb6539a4cf1b12d90005b7
// 3 kyu

internal static class BattleshipField
{
#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional
    public static bool ValidateBattlefield(int[,] field)
#pragma warning restore CA1814 // Prefer jagged arrays over multidimensional
    => new BattleshipFieldSolver(field).Solve();
}

#pragma warning disable SA1402 // File may only contain a single type
internal class BattleshipFieldSolver
#pragma warning restore SA1402 // File may only contain a single type
{
#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional
    public BattleshipFieldSolver(int[,] field)
#pragma warning restore CA1814 // Prefer jagged arrays over multidimensional
    {
        this.Field = field;
    }

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional
    public int[,] Field { get; }
#pragma warning restore CA1814 // Prefer jagged arrays over multidimensional

    internal bool Solve() => throw new NotImplementedException();
}