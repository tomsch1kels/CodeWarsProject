// https://www.codewars.com/kata/5541f58a944b85ce6d00006a
[TestFixture]
internal sealed class ProductFibTests
{
    [Test]
    public void Test1()
    {
        ulong[] r = [55, 89, 1];
        Assert.That(ProductFib.Solve(4895), Is.EqualTo(r));
    }
}