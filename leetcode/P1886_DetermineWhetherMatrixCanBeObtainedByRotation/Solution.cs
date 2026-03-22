namespace leetcode.P1886_DetermineWhetherMatrixCanBeObtainedByRotation;

// https://leetcode.com/problems/determine-whether-matrix-can-be-obtained-by-rotation/description/?envType=daily-question&envId=2026-03-22
public class Solution
{
    public bool FindRotation(int[][] mat, int[][] target)
    {
        // Check all 4 possible rotations (0, 90, 180, 270 degrees)
        for (int i = 0; i < 4; i++)
        {
            if (IsEqual(mat, target))
            {
                return true;
            }
            mat = Rotate90(mat);
        }
        return false;
    }

    private int[][] Rotate90(int[][] mat)
    {
        int n = mat.Length;
        int[][] rotated = new int[n][];
        for (int i = 0; i < n; i++)
        {
            rotated[i] = new int[n];
        }

        // Apply the transformation: (i, j) -> (j, n - 1 - i)
        for (int i = 0; i < n; i++)
        {
            for (int j = 0; j < n; j++)
            {
                rotated[j][n - 1 - i] = mat[i][j];
            }
        }
        return rotated;
    }

    private bool IsEqual(int[][] mat, int[][] target)
    {
        int n = mat.Length;
        for (int i = 0; i < n; i++)
        {
            for (int j = 0; j < n; j++)
            {
                if (mat[i][j] != target[i][j])
                {
                    return false;
                }
            }
        }
        return true;
    }
}
