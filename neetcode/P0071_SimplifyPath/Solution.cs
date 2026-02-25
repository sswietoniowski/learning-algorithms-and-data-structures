namespace neetcode.P0071_SimplifyPath;

// https://leetcode.com/problems/simplify-path/description/
// https://neetcode.io/problems/simplify-path/question
public class Solution
{
    public string SimplifyPath(string path)
    {
        string[] components = path.Split('/', StringSplitOptions.RemoveEmptyEntries);
        Stack<string> stack = new Stack<string>();

        foreach (string directory in components)
        {
            if (directory == ".")
            {
                continue;
            }
            else if (directory == "..")
            {
                if (stack.Count > 0)
                {
                    stack.Pop();
                }
            }
            else
            {
                stack.Push(directory);
            }
        }

        var result = new List<string>(stack);
        result.Reverse();

        return "/" + string.Join("/", result);
    }
}
