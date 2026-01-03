namespace neetcode.P2486_AppendCharacters;

// https://leetcode.com/problems/append-characters-to-string-to-make-subsequence/description/
// https://neetcode.io/problems/append-characters-to-string-to-make-subsequence/question?list=allNC
public class Solution
{
    public int AppendCharacters(string s, string t)
    {
        var j = 0;
        for (int i = 0; i < s.Length && j < t.Length; i++)
        {
            if (s[i] == t[j])
            {
                j++;
            }
        }

        return t.Length - j;
    }
}
