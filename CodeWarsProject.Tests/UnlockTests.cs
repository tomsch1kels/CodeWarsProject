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
        
        UnlockNode n2 = new([1],[]);
        using (Assert.EnterMultipleScope())
        {
            Assert.That(n2.GetDirectlyReachableNodes([]), Is.EqualTo([1]));
            Assert.That(n2.GetIndirectlyReachableNodes([]), Is.EqualTo(new Collection<int>()));
            Assert.That(n2.GetDirectlyReachableNodes([1]), Is.EqualTo(new Collection<int>()));
        }
    }

    [Test]
    public void TestUnlockNode_IndirectlyReachableNodes()
    {
        UnlockNode n3 = new([], [(3,2)]);
        using (Assert.EnterMultipleScope())
        {
            Assert.That(n3.GetDirectlyReachableNodes([]), Is.EqualTo(new Collection<int>()));
            Assert.That(n3.GetIndirectlyReachableNodes([]), Is.EqualTo(new Collection<int>()));
            Assert.That(n3.GetIndirectlyReachableNodes([2]), Is.EqualTo([3]));
        }

    }
}