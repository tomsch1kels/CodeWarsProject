using NUnit.Framework;
[TestFixture]
public class SolutionTest
{
  [Test]
  [TestCase("", "")]
  [TestCase("90", "90")]
  [TestCase("103 123 4444 99 2000", "103 123 4444 99 2000")]
  public void Test1(string input, string expected)
  {
    Assert.That(Kata.orderWeight(input), Is.EqualTo(expected));
  }
}