namespace neetcode.P3442_MaximumDifference;

// https://leetcode.com/problems/maximum-difference-between-even-and-odd-frequency-i/description/
// https://neetcode.io/problems/maximum-difference-between-even-and-odd-frequency-i/question?list=allNC
public class Solution
{
    public int MaxDifference(string s)
    {
        int[] count = new int[26];
        foreach (char c in s)
        {
            count[c - 'a']++;
        }

        int oddMax = 0,
            evenMin = s.Length;
        foreach (int c in count)
        {
            if ((c & 1) == 1)
            {
                oddMax = Math.Max(oddMax, c);
            }
            else if (c > 0)
            {
                evenMin = Math.Min(evenMin, c);
            }
        }

        return oddMax - evenMin;
    }
}
