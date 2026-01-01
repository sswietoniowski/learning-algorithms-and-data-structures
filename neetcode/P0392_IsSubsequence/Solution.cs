namespace neetcode.P0392_IsSubsequence;

// https://leetcode.com/problems/is-subsequence/description/
// https://neetcode.io/problems/is-subsequence/question
public class Solution
{
    public bool IsSubsequence(string s, string t)
    {
        if (s.Length == 0)
        {
            return true;
        }

        if (s.Length > t.Length)
        {
            return false;
        }

        for (int i = 0, j = 0; i < s.Length && j < t.Length; j++)
        {
            if (s[i] == t[j])
            {
                i++;

                if (i == s.Length)
                {
                    return true;
                }
            }
        }

        return false;
    }
}
