namespace neetcode.P1406_StoneGameIII;

// https://leetcode.com/problems/stone-game-iii/description/
// https://neetcode.io/problems/stone-game-iii/question?list=neetcode250
public class Solution
{
    public string StoneGameIII(int[] stoneValue)
    {
        int n = stoneValue.Length;
        int[] dp = new int[4];

        for (int i = n - 1; i >= 0; i--)
        {
            int total = 0;
            dp[i % 4] = int.MinValue;

            for (int j = i; j < Math.Min(i + 3, n); j++)
            {
                total += stoneValue[j];
                dp[i % 4] = Math.Max(dp[i % 4], total - dp[(j + 1) % 4]);
            }
        }

        if (dp[0] == 0)
            return "Tie";
        return dp[0] > 0 ? "Alice" : "Bob";
    }
}
