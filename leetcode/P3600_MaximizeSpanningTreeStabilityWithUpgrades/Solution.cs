namespace leetcode.P3600_MaximizeSpanningTreeStabilityWithUpgrades;

// https://leetcode.com/problems/maximize-spanning-tree-stability-with-upgrades/description/?envType=daily-question&envId=2026-03-12
// v1
public class Solution
{
    public int MaxStability(int n, int[][] edges, int k)
    {
        // 1. Check if mandatory edges form a cycle
        if (HasMandatoryCycle(n, edges))
            return -1;

        int low = 1,
            high = 200000;
        int result = -1;

        while (low <= high)
        {
            int mid = low + (high - low) / 2;
            if (CanAchieve(mid, n, edges, k))
            {
                result = mid;
                low = mid + 1;
            }
            else
            {
                high = mid - 1;
            }
        }

        // Final check: Can we actually connect the whole graph at all?
        return result;
    }

    private bool HasMandatoryCycle(int n, int[][] edges)
    {
        DSU dsu = new DSU(n);
        int mandatoryEdgesCount = 0;
        foreach (var edge in edges)
        {
            if (edge[3] == 1)
            {
                if (!dsu.Union(edge[0], edge[1]))
                    return true;
                mandatoryEdgesCount++;
            }
        }
        // A spanning tree can't have more than n-1 edges total
        return mandatoryEdgesCount >= n;
    }

    private bool CanAchieve(int X, int n, int[][] edges, int k)
    {
        DSU dsu = new DSU(n);
        int edgesUsed = 0;

        // Step A: All mandatory edges must be >= X
        foreach (var edge in edges)
        {
            if (edge[3] == 1)
            {
                if (edge[2] < X)
                    return false;
                dsu.Union(edge[0], edge[1]);
                edgesUsed++;
            }
        }

        // Step B: Use "free" optional edges (strength already >= X)
        foreach (var edge in edges)
        {
            if (edge[3] == 0 && edge[2] >= X)
            {
                if (dsu.Union(edge[0], edge[1]))
                {
                    edgesUsed++;
                }
            }
        }

        // Step C: Use "upgradable" optional edges (2 * strength >= X)
        int upgradesUsed = 0;
        foreach (var edge in edges)
        {
            if (edge[3] == 0 && edge[2] < X && edge[2] * 2 >= X)
            {
                if (upgradesUsed < k)
                {
                    if (dsu.Union(edge[0], edge[1]))
                    {
                        edgesUsed++;
                        upgradesUsed++;
                    }
                }
            }
        }

        // To be a valid spanning tree, all nodes must be connected
        return dsu.Components == 1;
    }
}

public class DSU
{
    private int[] parent;
    public int Components { get; private set; }

    public DSU(int n)
    {
        parent = new int[n];
        for (int i = 0; i < n; i++)
            parent[i] = i;
        Components = n;
    }

    public int Find(int i)
    {
        if (parent[i] == i)
            return i;
        return parent[i] = Find(parent[i]);
    }

    public bool Union(int i, int j)
    {
        int rootI = Find(i);
        int rootJ = Find(j);
        if (rootI != rootJ)
        {
            parent[rootI] = rootJ;
            Components--;
            return true;
        }
        return false;
    }
}
