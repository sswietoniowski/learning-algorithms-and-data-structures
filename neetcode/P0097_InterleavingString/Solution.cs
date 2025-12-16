namespace neetcode.P0097_InterleavingString;

// https://leetcode.com/problems/interleaving-string/description/
// https://neetcode.io/problems/interleaving-string/question?list=neetcode150
public class Solution
{
    public bool IsInterleave(string s1, string s2, string s3)
    {
        int m = s1.Length,
            n = s2.Length;
        if (m + n != s3.Length)
            return false;
        if (n < m)
        {
            var temp = s1;
            s1 = s2;
            s2 = temp;
            int tempLen = m;
            m = n;
            n = tempLen;
        }

        bool[] dp = new bool[n + 1];
        dp[n] = true;
        for (int i = m; i >= 0; i--)
        {
            bool nextDp = (i == m ? true : false);
            for (int j = n; j >= 0; j--)
            {
                bool res = (j < n ? false : nextDp);
                if (i < m && s1[i] == s3[i + j] && dp[j])
                {
                    res = true;
                }
                if (j < n && s2[j] == s3[i + j] && nextDp)
                {
                    res = true;
                }
                dp[j] = res;
                nextDp = dp[j];
            }
        }
        return dp[0];
    }
}
