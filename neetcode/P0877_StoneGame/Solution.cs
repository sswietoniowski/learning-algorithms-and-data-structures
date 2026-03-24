namespace neetcode.P0877_StoneGame;

// https://leetcode.com/problems/stone-game/description/
// https://neetcode.io/problems/stone-game/question?list=neetcode250
public class Solution
{
    public bool StoneGame(int[] piles)
    {
        int n = piles.Length;
        // dp[i][j] will be the max relative score Alice can get for piles[i...j]
        int[,] dp = new int[n, n];

        // Base case: only one pile left
        for (int i = 0; i < n; i++)
        {
            dp[i, i] = piles[i];
        }

        // Fill the table for lengths 2 to n
        for (int len = 2; len <= n; len++)
        {
            for (int i = 0; i <= n - len; i++)
            {
                int j = i + len - 1;
                // Current player takes i or j, subtracting the other player's max gain
                dp[i, j] = Math.Max(piles[i] - dp[i + 1, j], piles[j] - dp[i, j - 1]);
            }
        }

        // Alice wins if her relative score for the whole row is > 0
        return dp[0, n - 1] > 0;
    }
}
