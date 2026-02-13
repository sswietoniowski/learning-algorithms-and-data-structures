namespace leetcode.P3714_LongestBalancedSubstringII;

// https://leetcode.com/problems/longest-balanced-substring-ii/description/?envType=daily-question&envId=2026-02-13
public class Solution
{
    public int LongestBalanced(string s)
    {
        int maxLen = 0;

        maxLen = Math.Max(maxLen, GetMaxSingleChar(s));

        maxLen = Math.Max(maxLen, GetMaxTwoChars(s, 'a', 'b', 'c'));
        maxLen = Math.Max(maxLen, GetMaxTwoChars(s, 'a', 'c', 'b'));
        maxLen = Math.Max(maxLen, GetMaxTwoChars(s, 'b', 'c', 'a'));

        maxLen = Math.Max(maxLen, GetMaxThreeChars(s));

        return maxLen;
    }

    private int GetMaxSingleChar(string s)
    {
        if (s.Length == 0)
            return 0;
        int max = 0;
        int current = 0;
        char last = '\0';

        foreach (char c in s)
        {
            if (c == last)
            {
                current++;
            }
            else
            {
                max = Math.Max(max, current);
                current = 1;
                last = c;
            }
        }
        return Math.Max(max, current);
    }

    private int GetMaxTwoChars(string s, char target1, char target2, char forbiddenChar)
    {
        int max = 0;
        int balance = 0;

        var map = new Dictionary<int, int>();
        map[0] = -1;

        for (int i = 0; i < s.Length; i++)
        {
            char c = s[i];

            if (c == forbiddenChar)
            {
                map.Clear();
                map[0] = i;
                balance = 0;
            }
            else
            {
                if (c == target1)
                    balance++;
                else if (c == target2)
                    balance--;

                if (map.ContainsKey(balance))
                {
                    max = Math.Max(max, i - map[balance]);
                }
                else
                {
                    map[balance] = i;
                }
            }
        }
        return max;
    }

    private int GetMaxThreeChars(string s)
    {
        int max = 0;
        int countA = 0,
            countB = 0,
            countC = 0;

        var map = new Dictionary<(int, int), int>();
        map[(0, 0)] = -1;

        for (int i = 0; i < s.Length; i++)
        {
            char c = s[i];
            if (c == 'a')
                countA++;
            else if (c == 'b')
                countB++;
            else if (c == 'c')
                countC++;

            int diff1 = countA - countB;
            int diff2 = countB - countC;

            if (map.ContainsKey((diff1, diff2)))
            {
                max = Math.Max(max, i - map[(diff1, diff2)]);
            }
            else
            {
                map[(diff1, diff2)] = i;
            }
        }
        return max;
    }
}
