[TestFixture]
internal sealed class SnailTests
{
    [Test]
    [Order(1)]
    public void SnailTest1()
    {
        int[][] array =
        [
            [1, 2, 3],
            [4, 5, 6],
            [7, 8, 9]
        ];
        var r = new[] { 1, 2, 3, 6, 9, 8, 7, 4, 5 };
        Test(array, r);
    }

    [Test]
    public void EmptyTest()
    {
        int[][] array =
        [[]];
        Test(array, Array.Empty<int>());
    }

    // private static string Int2dToString(int[][] a) => $"[{string.Join("\n", a.Select(row => $"[{string.Join(",", row)}]"))}]";
    private static void Test(int[][] array, int[] result) => Assert.That(Snail.Solve(array), Is.EqualTo(result));
}