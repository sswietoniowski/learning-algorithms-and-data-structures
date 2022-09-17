namespace neetcode._150_EvaluateReversePolishNotation;

// https://leetcode.com/problems/evaluate-reverse-polish-notation/
// https://youtu.be/iu0082c4HDE
public class Solution
{
    public int EvalRPN(string[] tokens)
    {
        var operators = new HashSet<string> {"+", "-", "*", "/"};
        var stack = new Stack<int>();

        foreach (var token in tokens)
            if (operators.Contains(token))
            {
                var b = stack.Pop();
                var a = stack.Pop();
                var c = token switch
                {
                    "+" => a + b,
                    "-" => a - b,
                    "*" => a * b,
                    "/" => a / b,
                    _ => 0
                };

                stack.Push(c);
            }
            else
            {
                stack.Push(int.Parse(token));
            }

        return stack.Pop();
    }
}