namespace neetcode.P0261_GraphValidTree;

public class DSU
{
    private int[] Parent,
        Size;
    private int comps;

    public DSU(int n)
    {
        comps = n;
        Parent = new int[n + 1];
        Size = new int[n + 1];
        for (int i = 0; i <= n; i++)
        {
            Parent[i] = i;
            Size[i] = 1;
        }
    }

    public int Find(int node)
    {
        if (Parent[node] != node)
        {
            Parent[node] = Find(Parent[node]);
        }
        return Parent[node];
    }

    public bool Union(int u, int v)
    {
        int pu = Find(u),
            pv = Find(v);
        if (pu == pv)
            return false;
        if (Size[pu] < Size[pv])
        {
            int temp = pu;
            pu = pv;
            pv = temp;
        }
        comps--;
        Size[pu] += Size[pv];
        Parent[pv] = pu;
        return true;
    }

    public int Components()
    {
        return comps;
    }
}

// https://leetcode.com/problems/graph-valid-tree
// https://neetcode.io/problems/valid-tree/question?list=blind75
public class Solution
{
    public bool ValidTree(int n, int[][] edges)
    {
        if (edges.Length > n - 1)
        {
            return false;
        }

        DSU dsu = new DSU(n);
        foreach (var edge in edges)
        {
            if (!dsu.Union(edge[0], edge[1]))
            {
                return false;
            }
        }
        return dsu.Components() == 1;
    }
}
