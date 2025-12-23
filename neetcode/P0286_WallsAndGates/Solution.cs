namespace neetcode.P0286_WallsAndGates;

// https://leetcode.com/problems/walls-and-gates
// https://neetcode.io/problems/islands-and-treasure/question?list=neetcode150
public class Solution
{
    public void islandsAndTreasure(int[][] grid)
    {
        Queue<int[]> q = new Queue<int[]>();
        int m = grid.Length;
        int n = grid[0].Length;
        for (int i = 0; i < m; i++)
        {
            for (int j = 0; j < n; j++)
            {
                if (grid[i][j] == 0)
                    q.Enqueue(new int[] { i, j });
            }
        }

        if (q.Count == 0)
            return;

        int[][] dirs =
        {
            new int[] { -1, 0 },
            new int[] { 0, -1 },
            new int[] { 1, 0 },
            new int[] { 0, 1 },
        };
        while (q.Count > 0)
        {
            int[] cur = q.Dequeue();
            int row = cur[0];
            int col = cur[1];
            foreach (int[] dir in dirs)
            {
                int r = row + dir[0];
                int c = col + dir[1];
                if (r >= m || c >= n || r < 0 || c < 0 || grid[r][c] != int.MaxValue)
                {
                    continue;
                }
                q.Enqueue(new int[] { r, c });

                grid[r][c] = grid[row][col] + 1;
            }
        }
    }
}
