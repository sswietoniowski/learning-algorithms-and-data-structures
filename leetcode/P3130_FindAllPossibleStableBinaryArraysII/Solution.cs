namespace leetcode.P3130_FindAllPossibleStableBinaryArraysII;

// https://leetcode.com/problems/find-all-possible-stable-binary-arrays-ii/description/?envType=daily-question&envId=2026-03-10
public class Solution
{
    public int NumberOfStableArrays(int zero, int one, int limit)
    {
        int MOD = 1_000_000_007;

        // Correct 3D array declaration in C#
        int[,,] dp = new int[zero + 1, one + 1, 2];

        for (int i = 0; i <= zero; i++)
        {
            for (int j = 0; j <= one; j++)
            {
                // Calculating dp[i, j, 0] (Ending in a 0)
                if (i > 0)
                {
                    if (j == 0)
                    {
                        // If no ones are used, only one sequence [0,0...] exists
                        dp[i, j, 0] = (i <= limit) ? 1 : 0;
                    }
                    else
                    {
                        // Use long to prevent overflow during addition
                        long val = (long)dp[i - 1, j, 0] + dp[i - 1, j, 1];

                        // If i exceeds limit, subtract sequences that would create (limit + 1) zeros
                        if (i > limit)
                        {
                            val -= dp[i - limit - 1, j, 1];
                        }

                        // Ensure the result is positive before applying modulo
                        dp[i, j, 0] = (int)((val + MOD) % MOD);
                    }
                }

                // Calculating dp[i, j, 1] (Ending in a 1)
                if (j > 0)
                {
                    if (i == 0)
                    {
                        // If no zeros are used, only one sequence [1,1...] exists
                        dp[i, j, 1] = (j <= limit) ? 1 : 0;
                    }
                    else
                    {
                        long val = (long)dp[i, j - 1, 0] + dp[i, j - 1, 1];

                        // If j exceeds limit, subtract sequences that would create (limit + 1) ones
                        if (j > limit)
                        {
                            val -= dp[i, j - limit - 1, 0];
                        }

                        dp[i, j, 1] = (int)((val + MOD) % MOD);
                    }
                }
            }
        }

        return (int)(((long)dp[zero, one, 0] + dp[zero, one, 1]) % MOD);
    }
}
