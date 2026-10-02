[TestFixture]
internal sealed class FirstNonRepeatingLetterTests
{
    [Test]
    public void Test()
    {
        Assert.That(FirstNonRepeatingLetter.Solve("a"), Is.EqualTo("a"));
        Assert.That(FirstNonRepeatingLetter.Solve("stress"), Is.EqualTo("t"));
        Assert.That(FirstNonRepeatingLetter.Solve("moonmen"), Is.EqualTo("e"));
    }
}