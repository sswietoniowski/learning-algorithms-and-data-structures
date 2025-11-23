namespace neetcode.P0005_LongestPalindromicSubstring;

public class Solution
{
    // https://leetcode.com/problems/longest-palindromic-substring/description/
    // https://neetcode.io/problems/longest-palindromic-substring/question?list=blind75
    public int[] Manacher(string s)
    {
        string t = "#" + string.Join("#", s.ToCharArray()) + "#";
        int n = t.Length;
        int[] p = new int[n];
        int l = 0,
            r = 0;
        for (int i = 0; i < n; i++)
        {
            p[i] = (i < r) ? Math.Min(r - i, p[l + (r - i)]) : 0;
            while (i + p[i] + 1 < n && i - p[i] - 1 >= 0 && t[i + p[i] + 1] == t[i - p[i] - 1])
            {
                p[i]++;
            }
            if (i + p[i] > r)
            {
                l = i - p[i];
                r = i + p[i];
            }
        }
        return p;
    }

    public string LongestPalindrome(string s)
    {
        int[] p = Manacher(s);
        int resLen = 0,
            center_idx = 0;
        for (int i = 0; i < p.Length; i++)
        {
            if (p[i] > resLen)
            {
                resLen = p[i];
                center_idx = i;
            }
        }
        int resIdx = (center_idx - resLen) / 2;
        return s.Substring(resIdx, resLen);
    }
}
