using System.ComponentModel.Design;

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
            var p = parent[x];
            while (p != parent[p])
            {
                parent[p] = parent[parent[p]];
                p = parent[p];
            }
            return p;
        }

        bool Union(int x, int y)
        {
            var px = Find(x);
            var py = Find(y);
            
            if (px == py)
            {
                return false;
            }

            if (rank[px] > rank[py])
            {
                parent[py] = px;
                rank[px] += rank[py];
            }
            else
            {
                parent[px] = py;
                rank[py] += rank[px];
            }

            return true;
        }

        foreach (var edge in edges)
        {
            var u = edge[0];
            var v = edge[1];

            if (!Union(u, v))
            {
                return edge;
            }
        }

        return null;
    }
}