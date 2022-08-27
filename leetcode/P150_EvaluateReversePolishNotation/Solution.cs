namespace leetcode.P150_EvaluateReversePolishNotation
{
    public class Solution
    {
        // https://leetcode.com/problems/evaluate-reverse-polish-notation/
        public int EvalRPN(string[] tokens)
        {
            var operators = new HashSet<string>() { "+", "-", "*", "/" };
            var stack = new Stack<int>();

            foreach (var token in tokens)
            {
                if (operators.Contains(token))
                {
                    int b = stack.Pop();
                    int a = stack.Pop();
                    int c = token switch
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
            }

            return stack.Pop();
        }
    }
}
