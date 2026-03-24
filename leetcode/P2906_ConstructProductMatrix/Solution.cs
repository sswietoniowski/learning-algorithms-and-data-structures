namespace leetcode.P2906_ConstructProductMatrix;

// https://leetcode.com/problems/construct-product-matrix/description/?envType=daily-question&envId=2026-03-24
public class Solution
{
    public int[][] ConstructProductMatrix(int[][] grid)
    {
        int n = grid.Length;
        int m = grid[0].Length;
        int[][] p = new int[n][];
        for (int i = 0; i < n; i++)
        {
            p[i] = new int[m];
        }

        long currentProduct = 1;
        int mod = 12345;

        // Pass 1: Forward (Prefix Product)
        // Stores the product of all elements BEFORE grid[i][j]
        for (int i = 0; i < n; i++)
        {
            for (int j = 0; j < m; j++)
            {
                p[i][j] = (int)(currentProduct % mod);
                currentProduct = (currentProduct * grid[i][j]) % mod;
            }
        }

        currentProduct = 1;

        // Pass 2: Backward (Suffix Product)
        // Multiplies the existing prefix product by all elements AFTER grid[i][j]
        for (int i = n - 1; i >= 0; i--)
        {
            for (int j = m - 1; j >= 0; j--)
            {
                p[i][j] = (int)((p[i][j] * currentProduct) % mod);
                currentProduct = (currentProduct * grid[i][j]) % mod;
            }
        }

        return p;
    }
}
