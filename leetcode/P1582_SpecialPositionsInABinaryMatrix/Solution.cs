namespace leetcode.P1582_SpecialPositionsInABinaryMatrix;

// https://leetcode.com/problems/special-positions-in-a-binary-matrix/description/?envType=daily-question&envId=2026-03-04
public class Solution
{
    public int NumSpecial(int[][] mat)
    {
        int m = mat.Length;
        int n = mat[0].Length;
        int[] rowCount = new int[m];
        int[] columnCount = new int[n];
        for (int i = 0; i < m; i++)
        {
            for (int j = 0; j < n; j++)
            {
                if (mat[i][j] == 1)
                {
                    rowCount[i] += 1;
                    columnCount[j] += 1;
                }
            }
        }
        int counter = 0;
        for (int i = 0; i < m; i++)
        {
            for (int j = 0; j < n; j++)
            {
                if (mat[i][j] == 1 && rowCount[i] == 1 && columnCount[j] == 1)
                {
                    counter++;
                }
            }
        }
        return counter;
    }
}
