namespace neetcode.P1143_LongestCommonSubsequence;

// https://leetcode.com/problems/longest-common-subsequence/description/
// https://neetcode.io/problems/longest-common-subsequence/question?list=blind75
public class Solution
{
    public int LongestCommonSubsequence(string text1, string text2)
    {
        if (text1.Length < text2.Length)
        {
            string temp = text1;
            text1 = text2;
            text2 = temp;
        }

        int[] dp = new int[text2.Length + 1];

        for (int i = text1.Length - 1; i >= 0; i--)
        {
            int prev = 0;
            for (int j = text2.Length - 1; j >= 0; j--)
            {
                int temp = dp[j];
                if (text1[i] == text2[j])
                {
                    dp[j] = 1 + prev;
                }
                else
                {
                    dp[j] = Math.Max(dp[j], dp[j + 1]);
                }
                prev = temp;
            }
        }

        return dp[0];
    }
}
