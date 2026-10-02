// https://www.codewars.com/kata/52597aa56021e91c93000cb0
[TestFixture]
internal sealed class MoveZeroesTests
{
    internal static readonly int[] Arr = [1, 2, 0, 1, 0, 1, 0, 3, 0, 1];

    [Test]
    [Order(1)]
    public void Test()
    {
      int[] expected = [1, 2, 1, 1, 3, 1, 0, 0, 0, 0];
      Assert.That(MoveZeroes.Solve(Arr), Is.EqualTo(expected));
    }
}
