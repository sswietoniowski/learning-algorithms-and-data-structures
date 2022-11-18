namespace neetcode.P0684_RedundantConnection;

// https://leetcode.com/problems/redundant-connection/
// https://youtu.be/FXWRE67PLL0
public class Solution
{
    public int[] FindRedundantConnection(int[][] edges)
    {
        var parent = new int[edges.Length + 1];
        for (int i = 0; i < parent.Length; i++)
        {
            parent[i] = i;
        }

        var rank = new int[edges.Length + 1];
        for (int i = 0; i < rank.Length; i++)
        {
            rank[i] = 1;
        }

        int Find(int x)
        {
            if (x != parent[x])
            {
                parent[x] = Find(parent[x]);
            }

            return parent[x];
        }

        foreach (var edge in edges)
        {
            var u = edge[0];
            var v = edge[1];

            var pu = Find(u);
            var pv = Find(v);

            if (pu == pv)
            {
                return edge;
            }

            if (rank[pu] < rank[pv])
            {
                parent[pu] = pv;
            }
            else if (rank[pu] > rank[pv])
            {
                parent[pv] = pu;
            }
            else
            {
                parent[pu] = pv;
                rank[pv]++;
            }
        }

        return null;
    }
}