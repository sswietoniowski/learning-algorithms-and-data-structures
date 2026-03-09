namespace leetcode.P3129_FindAllPossibleStableBinaryArraysI;

// https://leetcode.com/problems/find-all-possible-stable-binary-arrays-i/description/?envType=daily-question&envId=2026-03-09
public class Solution
{
    public int NumberOfStableArrays(int zero, int one, int limit)
    {
        long MOD = 1_000_000_007;
        // dp[i][j][k] -> i zeros used, j ones used, k is the last digit (0 or 1)
        long[,,] dp = new long[zero + 1, one + 1, 2];

        // Base cases: single blocks of 0s or 1s within the limit
        for (int i = 1; i <= Math.Min(zero, limit); i++)
            dp[i, 0, 0] = 1;
        for (int j = 1; j <= Math.Min(one, limit); j++)
            dp[0, j, 1] = 1;

        for (int i = 1; i <= zero; i++)
        {
            for (int j = 1; j <= one; j++)
            {
                // Ending in 0:
                // We could add a 0 to any valid array ending in 0 or 1
                dp[i, j, 0] = (dp[i - 1, j, 0] + dp[i - 1, j, 1]) % MOD;
                if (i > limit)
                {
                    // Subtract sequences that would have resulted in (limit + 1) zeros
                    // These are sequences that ended in 1 at (i - limit - 1, j)
                    dp[i, j, 0] = (dp[i, j, 0] - dp[i - limit - 1, j, 1] + MOD) % MOD;
                }

                // Ending in 1:
                // We could add a 1 to any valid array ending in 0 or 1
                dp[i, j, 1] = (dp[i, j - 1, 0] + dp[i, j - 1, 1]) % MOD;
                if (j > limit)
                {
                    // Subtract sequences that would have resulted in (limit + 1) ones
                    // These are sequences that ended in 0 at (i, j - limit - 1)
                    dp[i, j, 1] = (dp[i, j, 1] - dp[i, j - limit - 1, 0] + MOD) % MOD;
                }
            }
        }

        return (int)((dp[zero, one, 0] + dp[zero, one, 1]) % MOD);
    }
}
