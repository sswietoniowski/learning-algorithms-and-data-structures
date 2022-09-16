namespace neetcode.P0048_RotateImage;

// https://leetcode.com/problems/rotate-image/
// https://youtu.be/fMSJSS7eO1w
public class Solution
{
    // v1
    //public void Rotate(int[][] matrix)
    //{
    //    int left = 0; int right = matrix.Length - 1;
    //    int top = 0; int bottom = matrix.Length - 1;

    //    while (left < right)
    //    {
    //        for (int i = 0; i < right - left; i++)
    //        {
    //            int temp = matrix[top][left + i];
    //            matrix[top][left + i] = matrix[bottom - i][left];
    //            matrix[bottom - i][left] = matrix[bottom][right - i];
    //            matrix[bottom][right - i] = matrix[top + i][right];
    //            matrix[top + i][right] = temp;
    //        }
    //        left++; right--;
    //        top++; bottom--;
    //    }
    //}

    // v2
    public void Rotate(int[][] matrix)
    {
        Transpose(matrix);
        Reflect(matrix);
    }

    private void Transpose(int[][] matrix)
    {
        int n = matrix.Length;
        for (int i = 0; i < n; i++)
        {
            for (int j = i + 1; j < n; j++)
            {
                (matrix[j][i], matrix[i][j]) = (matrix[i][j], matrix[j][i]);
            }
        }
    }

    private void Reflect(int[][] matrix)
    {
        int n = matrix.Length;
        for (int i = 0; i < n; i++)
        {
            for (int j = 0; j < n / 2; j++)
            {
                (matrix[i][j], matrix[i][n - j - 1]) = (matrix[i][n - j - 1], matrix[i][j]);
            }
        }
    }
}