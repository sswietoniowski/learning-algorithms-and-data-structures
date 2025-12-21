namespace neetcode.P0010_RegularExpressionMatching;

// https://leetcode.com/problems/regular-expression-matching/description/
// https://neetcode.io/problems/regular-expression-matching/question?list=neetcode150
public class Solution
{
    public bool IsMatch(string s, string p)
    {
        bool[] dp = new bool[p.Length + 1];
        dp[p.Length] = true;

        for (int i = s.Length; i >= 0; i--)
        {
            bool dp1 = dp[p.Length];
            dp[p.Length] = (i == s.Length);

            for (int j = p.Length - 1; j >= 0; j--)
            {
                bool match = i < s.Length && (s[i] == p[j] || p[j] == '.');
                bool res = false;
                if (j + 1 < p.Length && p[j + 1] == '*')
                {
                    res = dp[j + 2];
                    if (match)
                    {
                        res |= dp[j];
                    }
                }
                else if (match)
                {
                    res = dp1;
                }
                dp1 = dp[j];
                dp[j] = res;
            }
        }

        return dp[0];
    }
}
