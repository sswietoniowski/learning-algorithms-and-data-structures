namespace leetcode.P1727_LargestSubmatrixWithRearrangements;

// https://leetcode.com/problems/largest-submatrix-with-rearrangements/description/?envType=daily-question&envId=2026-03-17
public class Solution
{
    public int LargestSubmatrix(int[][] matrix)
    {
        int m = matrix.Length;
        int n = matrix[0].Length;
        int maxArea = 0;

        // Step 1: Pre-calculate heights row by row
        // We modify the matrix in-place to store the height of consecutive 1s
        for (int i = 1; i < m; i++)
        {
            for (int j = 0; j < n; j++)
            {
                if (matrix[i][j] == 1)
                {
                    matrix[i][j] += matrix[i - 1][j];
                }
            }
        }

        // Step 2: For each row, sort heights and calculate area
        for (int i = 0; i < m; i++)
        {
            // We take the current row's heights
            int[] currentRow = matrix[i];

            // Sort ascending (default in C#)
            Array.Sort(currentRow);

            // Step 3: Calculate area by iterating backwards (largest heights first)
            // Or iterate forwards and use (n - j) as the width
            for (int j = 0; j < n; j++)
            {
                int height = currentRow[j];
                int width = n - j; // Number of columns with at least this height
                maxArea = Math.Max(maxArea, height * width);
            }
        }

        return maxArea;
    }
}
