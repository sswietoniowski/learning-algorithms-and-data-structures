namespace neetcode.P0344_ReverseString;

// https://leetcode.com/problems/reverse-string/description/
// https://neetcode.io/problems/reverse-string/question?list=neetcode250
public class Solution
{
    public void ReverseString(char[] s)
    {
        int l = 0,
            r = s.Length - 1;

        while (l < r)
        {
            char tmp = s[l];
            s[l] = s[r];
            s[r] = tmp;
            l++;
            r--;
        }
    }
}
