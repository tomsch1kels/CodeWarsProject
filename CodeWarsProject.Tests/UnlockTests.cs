namespace CodeWarsProject.Tests;

using System.Collections.ObjectModel;
using CodeWarsProject.Solutions;

[TestFixture]
public sealed class UnlockTests
{
    [Test]
    public void TestUnlockNode()
    {
        UnlockNode node = new([], []);

        UnlockNode n2 = new([1], []);
        using (Assert.EnterMultipleScope())
        {
            Assert.That(n2.GetDirectlyReachableNodes([]), Is.EqualTo([1]));
            Assert.That(n2.GetIndirectlyReachableNodes([]), Is.EqualTo(new Collection<int>()));
            Assert.That(n2.GetDirectlyReachableNodes([1]), Is.EqualTo(new Collection<int>()));
            Assert.That(n2.GetDirectlyReachableNodes([]), Is.EqualTo([1]));
        }
    }

    [Test]
    public void TestUnlockNode_IndirectlyReachableNodes()
    {
        UnlockNode n3 = new([], [(3, 2)]);
        using (Assert.EnterMultipleScope())
        {
            Assert.That(n3.GetDirectlyReachableNodes([]), Is.EqualTo(new Collection<int>()));
            Assert.That(n3.GetIndirectlyReachableNodes([]), Is.EqualTo(new Collection<int>()));
            Assert.That(n3.GetIndirectlyReachableNodes([2]), Is.EqualTo([3]));
            Assert.That(n3.GetDirectlyReachableNodes([]), Is.EqualTo(new Collection<int>()));
        }
    }

    [Test]
    public void TestMap()
    {
        Map map = Map.CreateSimpleMap();

        using (Assert.EnterMultipleScope())
        {
            Assert.That(map.GetNode(1).GetDirectlyReachableNodes([]), Is.EqualTo([2]));
            Assert.That(map.GetNode(1).GetIndirectlyReachableNodes([2]), Is.EqualTo([3]));
            Assert.That(map.GetNode(1).GetReachableNodes([]), Is.EqualTo([2]));
            Assert.That(map.GetNode(1).GetReachableNodes([2]), Is.EqualTo([3]));

            Assert.That(map.GetReachableNodes(1, []), Is.EqualTo([2]));
            Assert.That(map.GetReachableNodes(1, [2]), Is.EqualTo([3]));
            Assert.That(map.GetReachableNodes(2, [2]), Is.EqualTo([1, 3]));
            Assert.That(map.GetReachableNodes(3, [2]), Is.EqualTo([1]));
        }
    }

    [Test]
    [TestCase(1, 0, 0)]
    [TestCase(1, 1, 1)]
    [TestCase(1, 2, 1)]
    [TestCase(1, 3, 1)]
    [TestCase(1, 4, 0)]
    public void TestSolve(int startingNode, int numberOfNodesToVisit, int expectedNumberOfRoutes)
    => Assert.That(
        new UnlockSolver(Map.CreateSimpleMap()).Solve(startingNode, numberOfNodesToVisit),
        Is.EqualTo(expectedNumberOfRoutes));

    [Test]

    // 1 2 3
    // 4 5
    [TestCase(2, 2, 4)]
    [TestCase(1, 3, 9)]
    [TestCase(1, 6, 0)]
    [TestCase(1, 5, 18)]
    // Deze lijst had ik berekend dat er was:
    // 12345
    // 12354
    // 12435
    // 12453
    // 14235
    // 14253
    // 14325
    // 14352
    // 15234
    // 15243
    // 15324
    // 15342
    public void TestSolve4(int startingNode, int numberOfNodesToVisit, int expectedNumberOfRoutes)
    => Assert.That(
        new UnlockSolver(Map.CreateSimple5Map()).Solve(startingNode, numberOfNodesToVisit),
        Is.EqualTo(expectedNumberOfRoutes));

    [Test]
    public void TestCompleteMap()
    {
        Map map = Map.CreateMap();
        Assert.That(
        map,
        Is.Not.Null);
    }

    [Test]
    public void TestCharFromLetter()
    {
        using (Assert.EnterMultipleScope())
        {
            Assert.That(Kata.GetIntFromLetter('A'), Is.EqualTo(1));
            Assert.That(Kata.GetIntFromLetter('I'), Is.EqualTo(9));
        }
    }
}