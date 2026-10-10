namespace neetcode.P0463_IslandPerimeter;

public class Solution
{
    public int IslandPerimeter(int[][] grid)
    {
        int m = grid.Length;
        int n = grid[0].Length;
        int res = 0;

        for (int i = 0; i < m; i++)
        {
            for (int j = 0; j < n; j++)
            {
                if (grid[i][j] == 1)
                {
                    if (i + 1 >= m || grid[i + 1][j] == 0)
                        res++;
                    if (j + 1 >= n || grid[i][j + 1] == 0)
                        res++;
                    if (i - 1 < 0 || grid[i - 1][j] == 0)
                        res++;
                    if (j - 1 < 0 || grid[i][j - 1] == 0)
                        res++;
                }
            }
        }

        return res;
    }
}
