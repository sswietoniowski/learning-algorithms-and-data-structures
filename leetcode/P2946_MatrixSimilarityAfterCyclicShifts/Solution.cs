namespace leetcode.P2946_MatrixSimilarityAfterCyclicShifts;

// https://leetcode.com/problems/matrix-similarity-after-cyclic-shifts/description/?envType=daily-question&envId=2026-03-27
public class Solution
{
    public bool AreSimilar(int[][] mat, int k)
    {
        int m = mat.Length;
        int n = mat[0].Length;

        // Optimization: any shift k is equivalent to k % n
        k = k % n;

        // If k % n is 0, the matrix remains unchanged regardless of content
        if (k == 0)
            return true;

        for (int i = 0; i < m; i++)
        {
            for (int j = 0; j < n; j++)
            {
                // Check if the current element matches the element
                // that would be shifted into its position.
                // For both left and right shifts, this periodic
                // check (j + k) % n covers the requirement.
                if (mat[i][j] != mat[i][(j + k) % n])
                {
                    return false;
                }
            }
        }

        return true;
    }
}
