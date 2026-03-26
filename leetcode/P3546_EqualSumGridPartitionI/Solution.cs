namespace leetcode.P3546_EqualSumGridPartitionI;

// https://leetcode.com/problems/equal-sum-grid-partition-i/description/?envType=daily-question&envId=2026-03-25
public class Solution
{
    public bool CanPartitionGrid(int[][] grid)
    {
        int m = grid.Length;
        int n = grid[0].Length;
        long totalSum = 0;

        // Step 1: Calculate the total sum of the grid
        for (int i = 0; i < m; i++)
        {
            for (int j = 0; j < n; j++)
            {
                totalSum += grid[i][j];
            }
        }

        // If total sum is odd, we cannot partition it into two equal integers
        if (totalSum % 2 != 0)
            return false;
        long target = totalSum / 2;

        // Step 2: Check for a horizontal cut
        long rowPrefixSum = 0;
        // We stop at m - 1 because each section must be non-empty
        for (int i = 0; i < m - 1; i++)
        {
            for (int j = 0; j < n; j++)
            {
                rowPrefixSum += grid[i][j];
            }
            if (rowPrefixSum == target)
                return true;
        }

        // Step 3: Check for a vertical cut
        long colPrefixSum = 0;
        // We stop at n - 1 because each section must be non-empty
        for (int j = 0; j < n - 1; j++)
        {
            for (int i = 0; i < m; i++)
            {
                colPrefixSum += grid[i][j];
            }
            if (colPrefixSum == target)
                return true;
        }

        return false;
    }
}
