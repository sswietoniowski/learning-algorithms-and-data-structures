namespace neetcode.P0020_ValidParentheses
{
    public class Solution
    {
        private bool IsValidPair(char opening, char closing)
        {
            return (opening == '(' && closing == ')') ||
                   (opening == '[' && closing == ']') ||
                   (opening == '{' && closing == '}');
        }

        // https://leetcode.com/problems/valid-parentheses/
        // https://youtu.be/WTzjTskDFMg
        public bool IsValid(string s)
        {
            var stack = new Stack<char>();

            foreach (var ch in s)
            {
                if ("([{".Contains(ch))
                {
                    stack.Push(ch);
                    continue;
                }

                if (stack.Count == 0)
                {
                    return false;
                }

                var opening = stack.Pop();

                if (!IsValidPair(opening, ch))
                {
                    return false;
                }
            }

            if (stack.Count > 0)
            {
                return false;
            }

            return true;
        }
    }
}
