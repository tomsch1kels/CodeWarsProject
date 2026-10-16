// https://www.codewars.com/kata/585894545a8a07255e0002f1
// 3 kyu
// workflow trigger 13u54
namespace CodeWarsProject.Solutions;

public static class Kata
{
    public static int CountPatternsFrom(char firstDot, int length)
    => new UnlockSolver(Map.CreateMap()).Solve(GetIntFromLetter(firstDot), length);

    public static int GetIntFromLetter(char letter)
    => letter switch
    {
        'A' => 1,
        'B' => 2,
        'C' => 3,
        'D' => 4,
        'E' => 5,
        'F' => 6,
        'G' => 7,
        'H' => 8,
        'I' => 9,
        _ => throw new ArgumentException($"Onbekende letter: {letter}"),
    };
}

public class UnlockNode(List<int> directlyReachableNodes,
                        List<(int ReachableNode, int BlockerNode)> indirectlyReachableNodes)
{
    private readonly List<int> directlyReachableNodes = directlyReachableNodes;
    private readonly List<(int ReachableNode, int BlockerNode)> indirectlyReachableNodes = indirectlyReachableNodes;

    public List<int> GetDirectlyReachableNodes(List<int> visited)
    => [.. this.directlyReachableNodes.Where(i => !visited.Contains(i))];

    public List<int> GetIndirectlyReachableNodes(List<int> visited)
    => [.. this.indirectlyReachableNodes
            .Where(t => visited.Contains(t.BlockerNode))
            .Select(t => t.ReachableNode)
            .Where(i => !visited.Contains(i))];

    public List<int> GetReachableNodes(List<int> visited)
    => [.. this.GetDirectlyReachableNodes(visited), .. this.GetIndirectlyReachableNodes(visited)];
}

public class Map(Dictionary<int, UnlockNode> nodes)
{
    private readonly Dictionary<int, UnlockNode> nodes = nodes;

    public int NumberOfNodes => this.nodes.Count;

    public static Map CreateSimpleMap()
    {
        UnlockNode n1 = new([2], [(3, 2)]);
        UnlockNode n2 = new([1, 3], []);
        UnlockNode n3 = new([2], [(1, 2)]);
        Dictionary<int, UnlockNode> nodesDict = new()
        {
            { 1, n1 },
            { 2, n2 },
            { 3, n3 },
        };
        return new Map(nodesDict);
    }

    public static Map CreateSimple5Map()
    {
        UnlockNode n1 = new([2, 4, 5], [(3, 2)]);
        UnlockNode n2 = new([1, 3, 4, 5], []);
        UnlockNode n3 = new([2, 4, 5], [(1, 2)]);
        UnlockNode n4 = new([1, 2, 3, 5], []);
        UnlockNode n5 = new([1, 2, 3, 4], []);
        Dictionary<int, UnlockNode> nodesDict = new()
        {
            { 1, n1 },
            { 2, n2 },
            { 3, n3 },
            { 4, n4 },
            { 5, n5 },
        };
        return new Map(nodesDict);
    }

    public static Map CreateMap()
    {
        // 1 2 3
        // 4 5 6
        // 7 8 9
        UnlockNode n1 = new([2, 4, 5, 6, 8], [(3, 2), (7, 4), (9, 5)]);
        UnlockNode n2 = new([1, 3, 4, 5, 6, 7, 9], [(8, 5)]);
        UnlockNode n3 = new([2, 4, 5, 6, 8], [(1, 2), (7, 5), (9, 6)]);
        UnlockNode n4 = new([1, 2, 3, 5, 7, 8, 9], [(6, 5)]);
        UnlockNode n5 = new([1, 2, 3, 4, 6, 7, 8, 9], []);
        UnlockNode n6 = new([1, 2, 3, 5, 7, 8, 9], [(4, 5)]);
        UnlockNode n7 = new([2, 4, 5, 6, 8], [(1, 4), (3, 5), (9, 8)]);
        UnlockNode n8 = new([1, 3, 4, 5, 6, 7, 9], [(2, 5)]);
        UnlockNode n9 = new([2, 4, 5, 6, 8], [(1, 5), (3, 6), (7, 8)]);

        Dictionary<int, UnlockNode> nodesDict = new()
        {
            { 1, n1 },
            { 2, n2 },
            { 3, n3 },
            { 4, n4 },
            { 5, n5 },
            { 6, n6 },
            { 7, n7 },
            { 8, n8 },
            { 9, n9 },
        };

        return new Map(nodesDict);
    }

    public UnlockNode GetNode(int nodeNumber) => this.nodes[nodeNumber];

    public List<int> GetReachableNodes(int nodeNumber, List<int> visited)
    {
        ArgumentNullException.ThrowIfNull(visited);
        return this.GetNode(nodeNumber).GetReachableNodes(visited);
    }
}

public class UnlockSolver(Map map)
{
    private readonly Map map = map;

    public int SolveRecursive(
        int currentNode,
        int numberOfNodesStillToVisit,
        List<int> visitedNodes,
        int numberOfNodesToVisit)
    {
        ArgumentNullException.ThrowIfNull(visitedNodes);

        visitedNodes.Add(currentNode);
        numberOfNodesStillToVisit--;

        // Stopcondition
        if (numberOfNodesStillToVisit == 0 && visitedNodes.Count == numberOfNodesToVisit)
        {
            visitedNodes.Remove(currentNode);
            return 1;
        }

        int result = 0;
        foreach (int node in this.map.GetReachableNodes(currentNode, visitedNodes))
        {
            result += this.SolveRecursive(node, numberOfNodesStillToVisit, visitedNodes, numberOfNodesToVisit);
        }

        visitedNodes.Remove(currentNode);

        return result;
    }

    public int Solve(int startingNode, int numberOfNodesToVisit)
    {
        if (numberOfNodesToVisit > this.map.NumberOfNodes || numberOfNodesToVisit == 0)
        {
            return 0;
        }

        return this.SolveRecursive(startingNode, numberOfNodesToVisit, [], numberOfNodesToVisit);
    }
}