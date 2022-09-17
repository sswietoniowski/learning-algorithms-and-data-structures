using System.Text;

namespace neetcode.P0022_GenerateParentheses;

// https://leetcode.com/problems/generate-parentheses/
// https://youtu.be/s9fokUqJ76A
public class Solution
{
    private void backtrack(int n, int openN, int closedN, Stack<char> parentheses, IList<string> result)
    {
        if (openN == closedN && openN == n)
        {
            var parenthesesFromStack = parentheses.ToArray();
            Array.Reverse(parenthesesFromStack);
            result.Add(new string(parenthesesFromStack));
            return;
        }

        if (openN < n)
        {
            parentheses.Push('(');
            backtrack(n, openN + 1, closedN, parentheses, result);
            parentheses.Pop();
        }

        if (closedN < openN)
        {
            parentheses.Push(')');
            backtrack(n, openN, closedN + 1, parentheses, result);
            parentheses.Pop();
        }
    }

    public IList<string> GenerateParenthesis(int n)
    {
        List<string> result = new();
        Stack<char> stack = new();

        backtrack(n, 0, 0, stack, result);

        return result;
    }
}