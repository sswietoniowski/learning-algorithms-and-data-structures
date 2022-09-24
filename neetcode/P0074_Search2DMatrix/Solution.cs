namespace neetcode.P0074_Search2DMatrix;

// https://leetcode.com/problems/search-a-2d-matrix/
// https://youtu.be/Ber2pi2C0j0
public class Solution
{
    public bool SearchMatrix(int[][] matrix, int target)
    {
        int n = matrix.Length;
        if (n == 0) return false;
        int m = matrix[0].Length;
        if (m == 0) return false;

        int l = 0;
        int r = n * m - 1;

        while (l <= r)
        {
            int mid = l + (r - l) / 2;
            int midVal = matrix[mid / m][mid % m];
            if (midVal == target) return true;
            if (midVal < target) l = mid + 1;
            else r = mid - 1;
        }

        return false;
    }
}