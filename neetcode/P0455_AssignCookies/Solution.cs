namespace neetcode.P455_AssignCookies;

// https://leetcode.com/problems/assign-cookies/description/
// https://neetcode.io/problems/assign-cookies/question
public class Solution
{
    public int FindContentChildren(int[] g, int[] s)
    {
        Array.Sort(g);
        Array.Sort(s);

        int childIndex = 0;
        int cookieIndex = 0;

        while (childIndex < g.Length && cookieIndex < s.Length)
        {
            if (s[cookieIndex] >= g[childIndex])
            {
                childIndex++;
            }

            cookieIndex++;
        }

        return childIndex;
    }
}
