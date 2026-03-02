namespace leetcode.P1536_MinimumSwapsToArrangeABinaryGrid;

// https://leetcode.com/problems/minimum-swaps-to-arrange-a-binary-grid/description/?envType=daily-question&envId=2026-03-02
public class Solution
{
    public int MinSwaps(int[][] grid)
    {
        int n = grid.Length;
        int[] trailingZeros = new int[n];

        for (int i = 0; i < n; i++)
        {
            int count = 0;
            for (int j = n - 1; j >= 0; j--)
            {
                if (grid[i][j] == 0)
                {
                    count++;
                }
                else
                {
                    break;
                }
            }
            trailingZeros[i] = count;
        }

        int totalSwaps = 0;

        for (int i = 0; i < n; i++)
        {
            int target = n - 1 - i;
            int foundIdx = -1;

            for (int j = i; j < n; j++)
            {
                if (trailingZeros[j] >= target)
                {
                    foundIdx = j;
                    break;
                }
            }

            if (foundIdx == -1)
                return -1;

            for (int k = foundIdx; k > i; k--)
            {
                int temp = trailingZeros[k];
                trailingZeros[k] = trailingZeros[k - 1];
                trailingZeros[k - 1] = temp;
                totalSwaps++;
            }
        }

        return totalSwaps;
    }
}
