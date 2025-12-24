namespace neetcode.P0743_NetworkDelayTime;

// https://leetcode.com/problems/network-delay-time/description/
// https://neetcode.io/problems/network-delay-time/question?list=neetcode150
public class Solution
{
    public int NetworkDelayTime(int[][] times, int n, int k)
    {
        var edges = new Dictionary<int, List<int[]>>();
        foreach (var time in times)
        {
            if (!edges.ContainsKey(time[0]))
            {
                edges[time[0]] = new List<int[]>();
            }
            edges[time[0]].Add(new int[] { time[1], time[2] });
        }

        var pq = new PriorityQueue<int, int>();
        pq.Enqueue(k, 0);

        var dist = new Dictionary<int, int>();
        for (int i = 1; i <= n; i++)
        {
            dist[i] = int.MaxValue;
        }
        dist[k] = 0;

        while (pq.Count > 0)
        {
            // Correctly using TryDequeue to get node and its distance
            if (pq.TryDequeue(out int node, out int minDist))
            {
                if (minDist > dist[node])
                {
                    continue;
                }

                if (edges.ContainsKey(node))
                {
                    foreach (var edge in edges[node])
                    {
                        var next = edge[0];
                        var weight = edge[1];
                        var newDist = minDist + weight;
                        if (newDist < dist[next])
                        {
                            dist[next] = newDist;
                            pq.Enqueue(next, newDist);
                        }
                    }
                }
            }
        }

        int result = 0;
        for (int i = 1; i <= n; i++)
        {
            if (dist[i] == int.MaxValue)
                return -1;
            result = Math.Max(result, dist[i]);
        }

        return result;
    }
}
