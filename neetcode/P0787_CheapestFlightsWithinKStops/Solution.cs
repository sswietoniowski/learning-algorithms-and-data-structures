namespace neetcode.P0787_CheapestFlightsWithinKStops;

// https://leetcode.com/problems/cheapest-flights-within-k-stops/description/
// https://neetcode.io/problems/cheapest-flight-path/question?list=neetcode150
public class Solution
{
    public int FindCheapestPrice(int n, int[][] flights, int src, int dst, int k)
    {
        int[] prices = new int[n];
        Array.Fill(prices, int.MaxValue);
        prices[src] = 0;
        List<int[]>[] adj = new List<int[]>[n];
        for (int i = 0; i < n; i++)
        {
            adj[i] = new List<int[]>();
        }
        foreach (var flight in flights)
        {
            adj[flight[0]].Add(new int[] { flight[1], flight[2] });
        }

        var q = new Queue<(int cst, int node, int stops)>();
        q.Enqueue((0, src, 0));

        while (q.Count > 0)
        {
            var (cst, node, stops) = q.Dequeue();
            if (stops > k)
                continue;

            foreach (var neighbor in adj[node])
            {
                int nei = neighbor[0],
                    w = neighbor[1];
                int nextCost = cst + w;
                if (nextCost < prices[nei])
                {
                    prices[nei] = nextCost;
                    q.Enqueue((nextCost, nei, stops + 1));
                }
            }
        }
        return prices[dst] == int.MaxValue ? -1 : prices[dst];
    }
}
