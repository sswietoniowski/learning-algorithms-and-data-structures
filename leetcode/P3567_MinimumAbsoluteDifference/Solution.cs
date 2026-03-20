namespace leetcode.P3567_MinimumAbsoluteDifference;

// https://leetcode.com/problems/minimum-absolute-difference-in-sliding-submatrix/description/?envType=daily-question&envId=2026-03-20
using System.Collections.Generic;
using System.Linq;

public class Solution
{
    public int[][] MinAbsDiff(int[][] grid, int k)
    {
        int m = grid.Length;
        int n = grid[0].Length;

        // The result grid size is determined by how many k x k blocks fit
        int resRows = m - k + 1;
        int resCols = n - k + 1;
        int[][] ans = new int[resRows][];

        for (int i = 0; i < resRows; i++)
        {
            ans[i] = new int[resCols];
            for (int j = 0; j < resCols; j++)
            {
                ans[i][j] = GetMinDiffForSubmatrix(grid, i, j, k);
            }
        }

        return ans;
    }

    private int GetMinDiffForSubmatrix(int[][] grid, int startRow, int startCol, int k)
    {
        // Step 1: Collect all distinct values in the k x k submatrix
        HashSet<int> distinctValues = new HashSet<int>();
        for (int r = startRow; r < startRow + k; r++)
        {
            for (int c = startCol; c < startCol + k; c++)
            {
                distinctValues.Add(grid[r][c]);
            }
        }

        // Step 2: If there's 0 or 1 distinct value, the difference is 0 by definition
        if (distinctValues.Count <= 1)
        {
            return 0;
        }

        // Step 3: Sort the distinct values
        List<int> sorted = distinctValues.ToList();
        sorted.Sort();

        // Step 4: Find the minimum difference between adjacent elements
        int minDiff = int.MaxValue;
        for (int i = 0; i < sorted.Count - 1; i++)
        {
            int diff = sorted[i + 1] - sorted[i];
            if (diff < minDiff)
            {
                minDiff = diff;
            }

            // Optimization: if we find a difference of 1, we can't get lower
            // (unless there were duplicates, which we handled via HashSet)
            if (minDiff == 1)
                return 1;
        }

        return minDiff;
    }
}
