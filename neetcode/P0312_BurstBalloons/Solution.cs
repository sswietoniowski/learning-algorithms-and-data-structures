namespace neetcode.P0312_BurstBalloons;

// https://leetcode.com/problems/burst-balloons/description/
// https://neetcode.io/problems/burst-balloons/question?list=neetcode150
public class Solution
{
    public int MaxCoins(int[] nums)
    {
        int n = nums.Length;
        int[] newNums = new int[n + 2];
        newNums[0] = newNums[n + 1] = 1;
        for (int i = 0; i < n; i++)
        {
            newNums[i + 1] = nums[i];
        }

        int[,] dp = new int[n + 2, n + 2];
        for (int l = n; l >= 1; l--)
        {
            for (int r = l; r <= n; r++)
            {
                for (int i = l; i <= r; i++)
                {
                    int coins = newNums[l - 1] * newNums[i] * newNums[r + 1];
                    coins += dp[l, i - 1] + dp[i + 1, r];
                    dp[l, r] = Math.Max(dp[l, r], coins);
                }
            }
        }

        return dp[1, n];
    }
}
