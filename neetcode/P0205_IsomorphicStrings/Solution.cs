namespace neetcode.P0205_IsomorphicStrings;

// https://leetcode.com/problems/isomorphic-strings/
// https://neetcode.io/problems/isomorphic-strings/question?list=allNC
public class Solution
{
    public bool IsIsomorphic(string s, string t)
    {
        int[] mapS = new int[256];
        int[] mapT = new int[256];

        for (int i = 0; i < s.Length; i++)
        {
            if (mapS[s[i]] != mapT[t[i]])
            {
                return false;
            }

            mapS[s[i]] = i + 1;
            mapT[t[i]] = i + 1;
        }

        return true;
    }
}
