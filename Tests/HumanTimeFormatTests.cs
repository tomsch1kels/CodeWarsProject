[TestFixture]
internal sealed class HumanTimeFormatTests
{
    [Test]
    [TestCase(0, "now")]
    [TestCase(1, "1 second")]
    [TestCase(2, "2 seconds")]
    [TestCase(62, "1 minute and 2 seconds")]
    [TestCase(120, "2 minutes")]
    [TestCase(3662, "1 hour, 1 minute and 2 seconds")]
    [TestCase(15731080, "182 days, 1 hour, 44 minutes and 40 seconds")]
    [TestCase(132030240, "4 years, 68 days, 3 hours and 4 minutes")]
    [TestCase(205851834, "6 years, 192 days, 13 hours, 3 minutes and 54 seconds")]
    [TestCase(253374061, "8 years, 12 days, 13 hours, 41 minutes and 1 second")]
    [TestCase(242062374, "7 years, 246 days, 15 hours, 32 minutes and 54 seconds")]
    [TestCase(101956166, "3 years, 85 days, 1 hour, 9 minutes and 26 seconds")]
    [TestCase(33243586, "1 year, 19 days, 18 hours, 19 minutes and 46 seconds")]
    public void Tests(int numberOfSeconds, string expected)
     => Assert.That(HumanTimeFormat.FormatDuration(numberOfSeconds), Is.EqualTo(expected));
}