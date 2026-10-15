// https://www.codewars.com/kata/585894545a8a07255e0002f1
// 3 kyu
namespace CodeWarsProject.Solutions;

public static class Kata
{
    public static int CountPatternsFrom(char firstDot, int length)
    => new UnlockSolver(Map.CreateMap()).Solve(firstDot, length);
}

public static class Unlock
{
}

public class UnlockNode(List<int> directlyReachableNodes,
                        List<(int ReachableNode, int BlockerNode)> indirectlyReachableNodes)
{
    private readonly List<int> directlyReachableNodes = directlyReachableNodes;
    private readonly List<(int ReachableNode, int BlockerNode)> indirectlyReachableNodes = indirectlyReachableNodes;

    public List<int> GetDirectlyReachableNodes(List<int> visited)
    => this.directlyReachableNodes.Where(i => !visited.Contains(i)).ToList();

    public List<int> GetIndirectlyReachableNodes(List<int> visited)
    {
        return this.indirectlyReachableNodes
            .Where(t => visited.Contains(t.BlockerNode))
            .Select(t => t.ReachableNode)
            .Where(i => !visited.Contains(i))
            .ToList();
    }

    public List<int> GetReachableNodes(List<int> visited)
    => this.GetDirectlyReachableNodes(visited).Concat(this.GetIndirectlyReachableNodes(visited)).ToList();
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

        // DebugPrint(visitedNodes);

        // Stopcondition
        if (numberOfNodesStillToVisit == 0 && visitedNodes.Count == numberOfNodesToVisit)
        {
            // string output = " " + visitedNodes[0] + visitedNodes[1] + visitedNodes[2] + visitedNodes[3] + visitedNodes[4];
            // Console.Out.WriteLine(output);
            // TestContext.Out.WriteLine(output);
            // TestContext.Progress.WriteLine(output);
            // System.Diagnostics.Debug.WriteLine(output);
            visitedNodes.Remove(currentNode);
            return 1;
        }

        int result = 0;
        List<int> reachableNodes = this.map.GetReachableNodes(currentNode, visitedNodes);
        foreach (int node in reachableNodes)
        {
            result += this.SolveRecursive(node, numberOfNodesStillToVisit, visitedNodes, numberOfNodesToVisit);
        }

        visitedNodes.Remove(currentNode);
        numberOfNodesStillToVisit++;

        return result;
    }

    public int Solve(int startingNode, int numberOfNodesToVisit)
    {
        if (numberOfNodesToVisit > this.map.NumberOfNodes || numberOfNodesToVisit == 0)
        {
            return 0;
        }

        return this.SolveRecursive(startingNode, numberOfNodesToVisit, new List<int>(), numberOfNodesToVisit);
    }

    // private static void DebugPrint(List<int> visitedNodes)
    // {
    //     string output = string.Empty;
    //     char letter = 'A';
    //     char[] letterPerNode = ['x', 'x', 'x', 'x', 'x', 'x'];
    //     for (int i = 0; i < visitedNodes.Count; i++)
    //     {
    //         int nodeNumber = visitedNodes[i];
    //         letterPerNode[nodeNumber] = letter;
    //         letter++;
    //     }
    //     char n1 = letterPerNode[1] == 'x' ? '1' : letterPerNode[1];
    //     char n2 = letterPerNode[2] == 'x' ? '2' : letterPerNode[2];
    //     char n3 = letterPerNode[3] == 'x' ? '3' : letterPerNode[3];
    //     char n4 = letterPerNode[4] == 'x' ? '4' : letterPerNode[4];
    //     char n5 = letterPerNode[5] == 'x' ? '5' : letterPerNode[5];
    //     output = n1 + " " + n2 + " " + n3 + System.Environment.NewLine + n4 + " " + n5;
    //     // Console.Out.WriteLine(DateTime.Now.Ticks);
    //     // Console.Out.WriteLine(output);
    //     TestContext.Out.WriteLine(output);
    //     TestContext.Progress.WriteLine(output);
    //     System.Diagnostics.Debug.WriteLine(output);
    // }
}