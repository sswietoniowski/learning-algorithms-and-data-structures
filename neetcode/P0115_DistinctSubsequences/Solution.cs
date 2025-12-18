namespace neetcode.P0115_DistinctSubsequences;

// https://leetcode.com/problems/distinct-subsequences/
// https://neetcode.io/problems/count-subsequences/question?list=neetcode150
public class Solution
{
    public int NumDistinct(string s, string t)
    {
        int m = s.Length,
            n = t.Length;
        int[] dp = new int[n + 1];

        dp[n] = 1;
        for (int i = m - 1; i >= 0; i--)
        {
            int prev = 1;
            for (int j = n - 1; j >= 0; j--)
            {
                int res = dp[j];
                if (s[i] == t[j])
                {
                    res += prev;
                }

                prev = dp[j];
                dp[j] = res;
            }
        }

        return dp[0];
    }
}
