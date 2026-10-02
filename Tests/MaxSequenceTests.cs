// https://www.codewars.com/kata/54521e9ec8e60bc4de000d6c
[TestFixture]
internal sealed class MaxSequenceTests
{
    [Test]
    [Order(1)]
    public void Test0() => Assert.That(MaxSequence.Solve(Array.Empty<int>()), Is.EqualTo(0));

    [Test]
    [Order(2)]
    public void Test1() => Assert.That(MaxSequence.Solve([-2, 1, -3, 4, -1, 2, 1, -5, 4]), Is.EqualTo(6));
}