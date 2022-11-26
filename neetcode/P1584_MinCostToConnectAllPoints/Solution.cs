namespace neetcode.P1584_MinCostToConnectAllPoints;

// https://leetcode.com/problems/min-cost-to-connect-all-points/
// https://youtu.be/f7JOBJIC-NA
public class Solution
{
    public int MinCostConnectPoints(int[][] points)
    {
        // preparing adjacency list

        var size = points.Length;

        var adjacencyList = new List<(int, int)>();

        for (var i = 0; i < size; i++)
        {
            var (x1, y1) = (points[i][0], points[i][1]);
            for (var j = i + 1; j < size; j++)
            {
                var (x2, y2) = (points[j][0], points[j][1]);
                var dist = Math.Abs(x1 - x2) + Math.Abs(y1 - y2);
                adjacencyList.Add((dist, i));
                adjacencyList.Add((dist, j));
            }
        }

        // applying Prim's algorithm

        var cost = 0;
        var visited = new HashSet<int>();
        var frontier = new PriorityQueue<(int, int), int>();
        frontier.Enqueue((0, 0), 0);

        while (frontier.Count > 0)
        {
            var (distance, node) = frontier.Dequeue();
            
            if (visited.Contains(node)) continue;

            visited.Add(node);
            cost += distance;

            foreach (var (neighborDistance, neighbor) in adjacencyList)
            {
                if (neighbor == node)
                {
                    frontier.Enqueue((neighborDistance, neighbor), neighborDistance);
                }
            }
        }
        
        return cost;
    }
}