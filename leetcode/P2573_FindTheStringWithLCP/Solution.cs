namespace leetcode.P2573_FindTheStringWithLCP;

// https://leetcode.com/problems/find-the-string-with-lcp/description/?envType=daily-question&envId=2026-03-28
public class Solution
{
    public string FindTheString(int[][] lcp)
    {
        int n = lcp.Length;
        char[] s = new char[n];
        char c = 'a';

        // 1. Greedy Construction
        for (int i = 0; i < n; i++)
        {
            if (s[i] != '\0')
                continue; // Already assigned
            if (c > 'z')
                return ""; // Out of lowercase letters

            for (int j = i; j < n; j++)
            {
                if (lcp[i][j] > 0)
                {
                    s[j] = c;
                }
            }
            c++;
        }

        // 2. Validation
        // We must check if the string we built actually produces the input matrix
        for (int i = n - 1; i >= 0; i--)
        {
            for (int j = n - 1; j >= 0; j--)
            {
                int expectedLcp = 0;
                if (s[i] == s[j])
                {
                    // Standard LCP DP: 1 + LCP of the next suffixes
                    expectedLcp = (i + 1 < n && j + 1 < n) ? lcp[i + 1][j + 1] + 1 : 1;
                }

                if (lcp[i][j] != expectedLcp)
                {
                    return "";
                }
            }
        }

        return new string(s);
    }
}
