namespace neetcode.P0695_MaxAreaOfIsland;

// https://leetcode.com/problems/max-area-of-island/
// https://youtu.be/iJGr1OtmH0c
public class Solution
{
    private int GetArea(int[][] grid, int row, int col)
    {
        if (row < 0 || row >= grid.Length || col < 0 || col >= grid[row].Length || grid[row][col] == 0)
        {
            return 0;
        }

        grid[row][col] = 0;
        return 1 + GetArea(grid, row - 1, col) + GetArea(grid, row + 1, col) + GetArea(grid, row, col - 1) + GetArea(grid, row, col + 1);
    }

    public int MaxAreaOfIsland(int[][] grid)
    {
        int maxArea = 0;
        for (int i = 0; i < grid.Length; i++)
        {
            for (int j = 0; j < grid[i].Length; j++)
            {
                if (grid[i][j] == 1)
                {
                    maxArea = Math.Max(maxArea, GetArea(grid, i, j));
                }
            }
        }

        return maxArea;
    }
}