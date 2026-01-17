namespace neetcode.P1584_MinCostToConnectAllPoints;

// https://leetcode.com/problems/min-cost-to-connect-all-points/
// https://youtu.be/f7JOBJIC-NA
public class Solution
{
    public int MinCostConnectPoints(int[][] points)
    {
        // preparing adjacency list

        var n = points.Length;

        if (n == 1)
        {
            return 0;
        }

        var adjacencyList = new Dictionary<int, List<(int, int)>>();

        for (var i = 0; i < n; i++)
        {
            var (x1, y1) = (points[i][0], points[i][1]);
            for (var j = i + 1; j < n; j++)
            {
                var (x2, y2) = (points[j][0], points[j][1]);
                var distance = Math.Abs(x1 - x2) + Math.Abs(y1 - y2);
                if (!adjacencyList.ContainsKey(i))
                {
                    adjacencyList[i] = new List<(int, int)>();
                }
                if (!adjacencyList.ContainsKey(j))
                {
                    adjacencyList[j] = new List<(int, int)>();
                }
                adjacencyList[i].Add((distance, j));
                adjacencyList[j].Add((distance, i));
            }
        }

        // applying Prim's algorithm

        var cost = 0;
        var visited = new HashSet<int>();
        var frontier = new PriorityQueue<(int, int), int>();
        frontier.Enqueue((0, 0), 0);

        while (visited.Count < n)
        {
            var (distance, node) = frontier.Dequeue();

            if (visited.Contains(node))
                continue;

            visited.Add(node);
            cost += distance;

            foreach (var (neighborDistance, neighbor) in adjacencyList[node])
            {
                if (!visited.Contains(neighbor))
                {
                    frontier.Enqueue((neighborDistance, neighbor), neighborDistance);
                }
            }
        }

        return cost;
    }
}
