namespace neetcode.P0518_CoinChangeII;

// https://leetcode.com/problems/coin-change-ii/
// https://neetcode.io/problems/coin-change-ii/question
public class Solution
{
    public int Change(int amount, int[] coins)
    {
        int[] dp = new int[amount + 1];
        dp[0] = 1;
        for (int i = coins.Length - 1; i >= 0; i--)
        {
            for (int a = 1; a <= amount; a++)
            {
                dp[a] += (coins[i] <= a ? dp[a - coins[i]] : 0);
            }
        }
        return dp[amount];
    }
}
