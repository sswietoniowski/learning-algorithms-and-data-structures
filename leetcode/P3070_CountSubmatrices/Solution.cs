namespace leetcode.P3070_CountSubmatrices;

// https://leetcode.com/problems/count-submatrices-with-top-left-element-and-sum-less-than-k/description/?envType=daily-question&envId=2026-03-18
public class Solution
{
    public int CountSubmatrices(int[][] grid, int k)
    {
        int rows = grid.Length;
        int cols = grid[0].Length;
        int count = 0;

        for (int i = 0; i < rows; i++)
        {
            for (int j = 0; j < cols; j++)
            {
                // Calculate 2D Prefix Sum for the submatrix ending at (i, j)
                if (i > 0)
                    grid[i][j] += grid[i - 1][j];
                if (j > 0)
                    grid[i][j] += grid[i][j - 1];
                if (i > 0 && j > 0)
                    grid[i][j] -= grid[i - 1][j - 1];

                // If the sum is within the limit, increment count
                if (grid[i][j] <= k)
                {
                    count++;
                }
                else
                {
                    // Optimization: If a sum in the first row or first column
                    // exceeds k, we can potentially break, but since we
                    // need to calculate prefix sums for later rows/cols,
                    // it's safer to just skip the count.
                    // Note: If grid[i][j] > k, we don't count it.
                }
            }
        }

        return count;
    }
}
