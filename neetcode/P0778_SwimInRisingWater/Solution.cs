namespace neetcode.P0778_SwimInRisingWater;

// https://leetcode.com/problems/swim-in-rising-water/description/
// https://neetcode.io/problems/swim-in-rising-water/question?list=neetcode150
public class DSU
{
    private int[] Parent,
        Size;

    public DSU(int n)
    {
        Parent = new int[n + 1];
        Size = new int[n + 1];
        for (int i = 0; i <= n; i++)
            Parent[i] = i;
        Array.Fill(Size, 1);
    }

    public int Find(int node)
    {
        if (Parent[node] != node)
            Parent[node] = Find(Parent[node]);
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
        Size[pu] += Size[pv];
        Parent[pv] = pu;
        return true;
    }

    public bool Connected(int u, int v)
    {
        return Find(u) == Find(v);
    }
}

public class Solution
{
    public int SwimInWater(int[][] grid)
    {
        int N = grid.Length;
        DSU dsu = new DSU(N * N);
        List<int[]> positions = new List<int[]>();
        for (int r = 0; r < N; r++)
        for (int c = 0; c < N; c++)
            positions.Add(new int[] { grid[r][c], r, c });
        positions.Sort((a, b) => a[0] - b[0]);
        int[][] directions = new int[][]
        {
            new int[] { 0, 1 },
            new int[] { 1, 0 },
            new int[] { 0, -1 },
            new int[] { -1, 0 },
        };

        foreach (var pos in positions)
        {
            int t = pos[0],
                r = pos[1],
                c = pos[2];
            foreach (var dir in directions)
            {
                int nr = r + dir[0],
                    nc = c + dir[1];
                if (nr >= 0 && nr < N && nc >= 0 && nc < N && grid[nr][nc] <= t)
                {
                    dsu.Union(r * N + c, nr * N + nc);
                }
            }
            if (dsu.Connected(0, N * N - 1))
                return t;
        }
        return N * N;
    }
}
