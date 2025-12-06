namespace neetcode.P0323_NumberOfConnectedComponentsInAnUndirectedGraph;

// https://leetcode.com/problems/number-of-connected-components-in-an-undirected-graph/description/
// https://neetcode.io/problems/count-connected-components/question?list=blind75
public class DSU
{
    private int[] parent;
    private int[] rank;

    public DSU(int n)
    {
        parent = new int[n];
        rank = new int[n];
        for (int i = 0; i < n; i++)
        {
            parent[i] = i;
            rank[i] = 1;
        }
    }

    public int Find(int node)
    {
        int cur = node;
        while (cur != parent[cur])
        {
            parent[cur] = parent[parent[cur]];
            cur = parent[cur];
        }
        return cur;
    }

    public bool Union(int u, int v)
    {
        int pu = Find(u);
        int pv = Find(v);
        if (pu == pv)
        {
            return false;
        }
        if (rank[pv] > rank[pu])
        {
            int temp = pu;
            pu = pv;
            pv = temp;
        }
        parent[pv] = pu;
        rank[pu] += rank[pv];
        return true;
    }
}

public class Solution
{
    public int CountComponents(int n, int[][] edges)
    {
        DSU dsu = new DSU(n);
        int res = n;
        foreach (var edge in edges)
        {
            if (dsu.Union(edge[0], edge[1]))
            {
                res--;
            }
        }
        return res;
    }
}
