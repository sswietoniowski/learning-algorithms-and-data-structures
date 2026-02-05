namespace neetcode.P0054_SpiralMatrix;

// https://leetcode.com/problems/spiral-matrix/
// https://youtu.be/BJnMZNwUk1M
public class Solution
{
    public IList<int> SpiralOrder(int[][] matrix)
    {
        var result = new List<int>();

        if (matrix.Length == 0)
            return result;

        var left = 0;
        var right = matrix[0].Length;
        var top = 0;
        var bottom = matrix.Length;

        while (left < right && top < bottom)
        {
            // left to right
            for (int i = left; i < right; i++)
            {
                result.Add(matrix[top][i]);
            }
            top++;

            // top to bottom
            for (int i = top; i < bottom; i++)
            {
                result.Add(matrix[i][right - 1]);
            }
            right--;

            if (!(left < right && top < bottom))
            {
                break;
            }

            // right to left
            for (int i = right - 1; i >= left; i--)
            {
                result.Add(matrix[bottom - 1][i]);
            }
            bottom--;

            // bottom to top
            for (int i = bottom - 1; i >= top; i--)
            {
                result.Add(matrix[i][left]);
            }
            left++;
        }

        return result;
    }
}
