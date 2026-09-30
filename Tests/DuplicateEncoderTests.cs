
[TestFixture]
internal sealed class KataTests
{
    [Test]
    public void BasicTests()
    {
        Assert.That(DuplicateEncoder.DuplicateEncode("din"), Is.EqualTo("((("));
        Assert.That(DuplicateEncoder.DuplicateEncode("recede"), Is.EqualTo("()()()"));
        Assert.That(DuplicateEncoder.DuplicateEncode("Success"), Is.EqualTo(")())())"), "should ignore case");
        Assert.That(DuplicateEncoder.DuplicateEncode("(( @"), Is.EqualTo("))(("));
    }
}