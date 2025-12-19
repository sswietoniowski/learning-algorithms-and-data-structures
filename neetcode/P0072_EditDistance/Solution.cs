namespace neetcode.P0072_EditDistance;

public class Solution
{
    public int MinDistance(string word1, string word2)
    {
        int m = word1.Length,
            n = word2.Length;
        if (m < n)
        {
            string temp = word1;
            word1 = word2;
            word2 = temp;
            m = word1.Length;
            n = word2.Length;
        }

        int[] dp = new int[n + 1];
        for (int i = 0; i <= n; i++)
            dp[i] = n - i;

        for (int i = m - 1; i >= 0; i--)
        {
            int nextDp = dp[n];
            dp[n] = m - i;
            for (int j = n - 1; j >= 0; j--)
            {
                int temp = dp[j];
                if (word1[i] == word2[j])
                {
                    dp[j] = nextDp;
                }
                else
                {
                    dp[j] = 1 + Math.Min(dp[j], Math.Min(dp[j + 1], nextDp));
                }
                nextDp = temp;
            }
        }
        return dp[0];
    }
}
