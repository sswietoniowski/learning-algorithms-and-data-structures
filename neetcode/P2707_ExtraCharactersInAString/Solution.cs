namespace neetcode.P2707_ExtraCharactersInAString;

public class Solution
{
    public int MinExtraChar(string s, string[] dictionary)
    {
        HashSet<string> words = new HashSet<string>(dictionary);
        int n = s.Length;
        int[] dp = new int[n + 1];

        for (int i = n - 1; i >= 0; i--)
        {
            dp[i] = 1 + dp[i + 1];
            for (int j = i; j < n; j++)
            {
                if (words.Contains(s.Substring(i, j - i + 1)))
                {
                    dp[i] = Math.Min(dp[i], dp[j + 1]);
                }
            }
        }

        return dp[0];
    }
}
