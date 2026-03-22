namespace neetcode.P0064_MinimumPathSum;

// https://leetcode.com/problems/minimum-path-sum/description/
// https://neetcode.io/problems/minimum-path-sum/question
public class Solution
{
    public int MinPathSum(int[][] grid)
    {
        int m = grid.Length;
        int n = grid[0].Length;

        // Create a DP table to store the minimum path sum to each cell
        int[,] dp = new int[m, n];

        // Base case: the starting point
        dp[0, 0] = grid[0][0];

        // Fill the first row (can only come from the left)
        for (int j = 1; j < n; j++)
        {
            dp[0, j] = dp[0, j - 1] + grid[0][j];
        }

        // Fill the first column (can only come from above)
        for (int i = 1; i < m; i++)
        {
            dp[i, 0] = dp[i - 1, 0] + grid[i][0];
        }

        // Fill the rest of the dp table
        for (int i = 1; i < m; i++)
        {
            for (int j = 1; j < n; j++)
            {
                // The min path to this cell is the current value +
                // the minimum of the cell above or the cell to the left
                dp[i, j] = grid[i][j] + Math.Min(dp[i - 1, j], dp[i, j - 1]);
            }
        }

        // The answer is the value in the bottom-right corner
        return dp[m - 1, n - 1];
    }
}
