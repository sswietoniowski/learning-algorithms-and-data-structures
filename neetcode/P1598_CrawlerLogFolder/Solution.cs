namespace neetcode.P1598_CrawlerLogFolder;

// https://leetcode.com/problems/crawler-log-folder/description/
// https://neetcode.io/problems/crawler-log-folder/question
// v1
/*
public class Solution
{
    public int MinOperations(string[] logs)
    {
        var levels = new Stack<string>();

        foreach (var log in logs)
        {
            switch (log)
            {
                case "../":
                    if (levels.Count > 0)
                    {
                        levels.Pop();
                    }
                    break;
                case "./":
                    break;
                default:
                    levels.Push(log);
                    break;
            }
        }

        return levels.Count;
    }
}
*/
// v2
public class Solution
{
    public int MinOperations(string[] logs)
    {
        int res = 0;
        foreach (string log in logs)
        {
            if (log == "./")
            {
                continue;
            }
            if (log == "../")
            {
                res = Math.Max(0, res - 1);
            }
            else
            {
                res++;
            }
        }
        return res;
    }
}
