namespace neetcode.P0678_ValidParenthesisString;

// https://leetcode.com/problems/valid-parenthesis-string/description/
// https://neetcode.io/problems/valid-parenthesis-string/question?list=neetcode150
public class Solution
{
    public bool CheckValidString(string s)
    {
        int leftMin = 0,
            leftMax = 0;

        foreach (char c in s)
        {
            if (c == '(')
            {
                leftMin++;
                leftMax++;
            }
            else if (c == ')')
            {
                leftMin--;
                leftMax--;
            }
            else
            {
                leftMin--;
                leftMax++;
            }
            if (leftMax < 0)
            {
                return false;
            }
            if (leftMin < 0)
            {
                leftMin = 0;
            }
        }
        return leftMin == 0;
    }
}
