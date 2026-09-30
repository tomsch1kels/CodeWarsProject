// <copyright file="WeightForWeightTests.cs" company="PlaceholderCompany">
// Copyright (c) PlaceholderCompany. All rights reserved.
// </copyright>

[TestFixture]
internal sealed class WeightForWeightTests
{
    [Test]
    [TestCase("", "")]
    [TestCase("90", "90")]
    [TestCase("90 10", "10 90")]
    [TestCase("103 123 4444 99 2000", "2000 103 123 4444 99")]

    public void Test1(string input, string expected) 
    => Assert.That(WeightForWeight.Solve(input), Is.EqualTo(expected));
}