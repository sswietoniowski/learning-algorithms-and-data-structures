namespace leetcode.P3418_MaximumAmountOfMoneyRobotCanEarn;

// https://leetcode.com/problems/maximum-amount-of-money-robot-can-earn/description/?envType=daily-question&envId=2026-04-02
using System;

public class Solution
{
    public int MaximumAmount(int[][] coins)
    {
        int m = coins.Length;
        int n = coins[0].Length;

        // dp[row][col][neutralizations_used]
        // We use long.MinValue / 2 to avoid overflow when adding negative coin values.
        long[,,] dp = new long[m, n, 3];
        long negInf = -1_000_000_000_000L;

        for (int i = 0; i < m; i++)
        {
            for (int j = 0; j < n; j++)
            {
                for (int k = 0; k < 3; k++)
                {
                    dp[i, j, k] = negInf;
                }
            }
        }

        // Base case: Starting point (0, 0)
        dp[0, 0, 0] = coins[0][0];
        if (coins[0][0] < 0)
        {
            // If the start is a robber, we can neutralize it using 1 or 2 of our slots
            dp[0, 0, 1] = 0;
            dp[0, 0, 2] = 0;
        }
        else
        {
            // If it's a gain, neutralizations don't change the value
            dp[0, 0, 1] = coins[0][0];
            dp[0, 0, 2] = coins[0][0];
        }

        for (int i = 0; i < m; i++)
        {
            for (int j = 0; j < n; j++)
            {
                if (i == 0 && j == 0)
                    continue;

                for (int k = 0; k < 3; k++)
                {
                    // 1. Standard Move (Add coins[i][j] regardless of sign)
                    long fromTop = (i > 0) ? dp[i - 1, j, k] : negInf;
                    long fromLeft = (j > 0) ? dp[i, j - 1, k] : negInf;
                    long bestPrev = Math.Max(fromTop, fromLeft);

                    if (bestPrev != negInf)
                    {
                        dp[i, j, k] = Math.Max(dp[i, j, k], bestPrev + coins[i][j]);
                    }

                    // 2. Neutralize Move (Only if current cell is a robber and we have k > 0)
                    if (k > 0 && coins[i][j] < 0)
                    {
                        long fromTopK = (i > 0) ? dp[i - 1, j, k - 1] : negInf;
                        long fromLeftK = (j > 0) ? dp[i, j - 1, k - 1] : negInf;
                        long bestPrevK = Math.Max(fromTopK, fromLeftK);

                        if (bestPrevK != negInf)
                        {
                            // We treat this cell as 0 coins because we neutralized the robber
                            dp[i, j, k] = Math.Max(dp[i, j, k], bestPrevK);
                        }
                    }
                }
            }
        }

        // The answer is the max profit at the bottom-right corner across all neutralization counts
        long result = Math.Max(
            dp[m - 1, n - 1, 0],
            Math.Max(dp[m - 1, n - 1, 1], dp[m - 1, n - 1, 2])
        );

        return (int)result;
    }
}
