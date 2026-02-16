namespace neetcode.P0304_RangeSumQuery2DImmutable;

// https://leetcode.com/problems/range-sum-query-2d-immutable/description/
// https://neetcode.io/problems/range-sum-query-2d-immutable/question?list=neetcode250
public class NumMatrix
{
    private int[,] dp;

    public NumMatrix(int[][] matrix)
    {
        if (matrix.Length == 0 || matrix[0].Length == 0)
            return;

        int m = matrix.Length;
        int n = matrix[0].Length;
        dp = new int[m + 1, n + 1];

        for (int i = 0; i < m; i++)
        {
            for (int j = 0; j < n; j++)
            {
                dp[i + 1, j + 1] = matrix[i][j] + dp[i, j + 1] + dp[i + 1, j] - dp[i, j];
            }
        }
    }

    public int SumRegion(int row1, int col1, int row2, int col2)
    {
        return dp[row2 + 1, col2 + 1] - dp[row1, col2 + 1] - dp[row2 + 1, col1] + dp[row1, col1];
    }
}

/**
 * Your NumMatrix object will be instantiated and called as such:
 * NumMatrix obj = new NumMatrix(matrix);
 * int param_1 = obj.SumRegion(row1,col1,row2,col2);
 */
