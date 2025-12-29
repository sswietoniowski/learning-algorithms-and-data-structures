namespace neetcode.P3110_ScoreOfAString;

// https://leetcode.com/problems/score-of-a-string/description/
// https://neetcode.io/problems/score-of-a-string/question
public class Solution
{
    public int ScoreOfString(string s)
    {
        int sum = 0;
        for (int i = 1; i < s.Length; i++)
        {
            int value = (int)s[i - 1] - (int)s[i];
            sum += value >= 0 ? value : -value;
        }
        return sum;
    }
}
