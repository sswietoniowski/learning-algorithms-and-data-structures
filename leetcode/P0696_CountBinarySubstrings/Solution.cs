namespace leetcode.P0696_CountBinarySubstrings;

// https://leetcode.com/problems/count-binary-substrings/description/?envType=daily-question&envId=2026-02-19
public class Solution
{
    public int CountBinarySubstrings(string s)
    {
        int count = 0;
        int prevGroupLength = 0;
        int currGroupLength = 1;

        for (int i = 1; i < s.Length; i++)
        {
            if (s[i] == s[i - 1])
            {
                currGroupLength++;
            }
            else
            {
                count += Math.Min(prevGroupLength, currGroupLength);

                prevGroupLength = currGroupLength;
                currGroupLength = 1;
            }
        }

        count += Math.Min(prevGroupLength, currGroupLength);

        return count;
    }
}
