// https://www.codewars.com/kata/55fd2d567d94ac3bc9000064
[TestFixture]
internal sealed class RowSumOddNumbersTests
{
    [Test]
    public void Test()
    {
        Assert.That(RowSumOddNumbers.Solve(1), Is.EqualTo(1));
        Assert.That(RowSumOddNumbers.Solve(42), Is.EqualTo(74088));
    }
}
