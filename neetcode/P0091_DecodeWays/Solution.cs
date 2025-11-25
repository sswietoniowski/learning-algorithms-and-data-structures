namespace neetcode.P0091_DecodeWays;

// https://leetcode.com/problems/decode-ways/description/
// https://neetcode.io/problems/decode-ways/question?list=blind75
public class Solution
{
    public int NumDecodings(string s)
    {
        int dp = 0,
            dp1 = 1,
            dp2 = 0;
        for (int i = s.Length - 1; i >= 0; i--)
        {
            if (s[i] == '0')
            {
                dp = 0;
            }
            else
            {
                dp = dp1;
                if (i + 1 < s.Length && (s[i] == '1' || s[i] == '2' && s[i + 1] < '7'))
                {
                    dp += dp2;
                }
            }
            dp2 = dp1;
            dp1 = dp;
            dp = 0;
        }
        return dp1;
    }
}
