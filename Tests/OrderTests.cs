// https://www.codewars.com/kata/55c45be3b2079eccff00010f
[TestFixture]
internal sealed class OrderTests
{
    [Test]
    [Description("Sample Tests")]
    [Order(1)]
    public void SampleTest()
    {
        Assert.That(Order.Solve("is2 Thi1s T4est 3a"), Is.EqualTo("Thi1s is2 3a T4est"));
        Assert.That(Order.Solve("4of Fo1r pe6ople g3ood th5e the2"), Is.EqualTo("Fo1r the2 g3ood 4of th5e pe6ople"));
        Assert.That(Order.Solve(string.Empty), Is.EqualTo(string.Empty));
    }
}
