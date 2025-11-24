namespace neetcode.P0647_PalindromicSubstrings;

// https://leetcode.com/problems/palindromic-substrings/description/
// https://neetcode.io/problems/palindromic-substrings/question?list=blind75
public class Solution
{
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

    public int CountSubstrings(string s)
    {
        int[] p = Manacher(s);
        int res = 0;
        foreach (int i in p)
        {
            res += (i + 1) / 2;
        }
        return res;
    }
}
