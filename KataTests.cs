using NUnit.Framework;
[TestFixture]
public class SolutionTest
{
  [Test]
  [TestCase("", "")]
  [TestCase("90", "90")]
  [TestCase("90 10", "10 90")]
  [TestCase("103 123 4444 99 2000", "2000 103 123 4444 99")]
  [TestCase("2000 10003 1234000 44444444 9999 11 11 22 123",
   "11 11 2000 10003 22 123 1234000 44444444 9999")]
  public void Test1(string input, string expected)
  {
    Assert.That(Kata.orderWeight(input), Is.EqualTo(expected));
  }
}