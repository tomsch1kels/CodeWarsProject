[TestFixture]
internal sealed class GreedIsGoodTests
{
    [Test]
    public static void ShouldBeWorthless()
     => Assert.That(GreedIsGood.Solve([2, 3, 4, 6, 2]), Is.EqualTo(0));

    // [Test]
    // public static void ShouldValueTriplets()
    //  => Assert.That(GreedIsGood.Solve([4, 4, 4, 3, 3]), Is.EqualTo(400));

    // [Test]
    // public static void ShouldValueMixedSets()
    //  => Assert.That(GreedIsGood.Solve([2, 4, 4, 5, 4]), Is.EqualTo(450));
}