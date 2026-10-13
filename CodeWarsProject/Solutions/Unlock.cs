// https://www.codewars.com/kata/585894545a8a07255e0002f1
// 3 kyu
namespace CodeWarsProject.Solutions;

using System.Collections.ObjectModel;

public static class Unlock
{
}

public class UnlockNode(Collection<int> directlyReachableNodes, Collection<(int, int)> indirectlyReachableNodes)
{
    private readonly Collection<int> directlyReachableNodes = directlyReachableNodes;
    private readonly Collection<(int, int)> indirectlyReachableNodes = indirectlyReachableNodes;

    public Collection<int> GetDirectlyReachableNodes(Collection<int> visited)
    {
        _ = this.directlyReachableNodes;
        _ = this.indirectlyReachableNodes;
        _ = visited;
        throw new NotImplementedException();
    }

    public Collection<int> GetIndirectlyReachableNodes(Collection<int> visited) => throw new NotImplementedException();

    public Collection<int> GetReachableNodes(Collection<int> visited) => throw new NotImplementedException();
}