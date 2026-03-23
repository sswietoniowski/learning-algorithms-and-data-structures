namespace leetcode.P1594_MaximumNonNegativeProductInAMatrix;

// https://leetcode.com/problems/maximum-non-negative-product-in-a-matrix/description/?envType=daily-question&envId=2026-03-23
public class Solution
{
    public int MaxProductPath(int[][] grid)
    {
        int m = grid.Length;
        int n = grid[0].Length;
        long mod = 1_000_000_007;

        // dpMax[i][j] stores the maximum product to reach (i, j)
        // dpMin[i][j] stores the minimum product to reach (i, j)
        long[,] dpMax = new long[m, n];
        long[,] dpMin = new long[m, n];

        // Initialize the starting point
        dpMax[0, 0] = dpMin[0, 0] = grid[0][0];

        // Fill the first column (only one way: from above)
        for (int i = 1; i < m; i++)
        {
            dpMax[i, 0] = dpMin[i, 0] = dpMax[i - 1, 0] * grid[i][0];
        }

        // Fill the first row (only one way: from left)
        for (int j = 1; j < n; j++)
        {
            dpMax[0, j] = dpMin[0, j] = dpMax[0, j - 1] * grid[0][j];
        }

        // Fill the rest of the DP table
        for (int i = 1; i < m; i++)
        {
            for (int j = 1; j < n; j++)
            {
                long val = grid[i][j];

                // If the current number is non-negative,
                // Max * Pos = Max, Min * Pos = Min
                if (val >= 0)
                {
                    dpMax[i, j] = Math.Max(dpMax[i - 1, j], dpMax[i, j - 1]) * val;
                    dpMin[i, j] = Math.Min(dpMin[i - 1, j], dpMin[i, j - 1]) * val;
                }
                // If the current number is negative,
                // Min * Neg = Max, Max * Neg = Min
                else
                {
                    dpMax[i, j] = Math.Min(dpMin[i - 1, j], dpMin[i, j - 1]) * val;
                    dpMin[i, j] = Math.Max(dpMax[i - 1, j], dpMax[i, j - 1]) * val;
                }
            }
        }

        long result = dpMax[m - 1, n - 1];

        // If the max product is negative, return -1 as per requirements
        return result < 0 ? -1 : (int)(result % mod);
    }
}
