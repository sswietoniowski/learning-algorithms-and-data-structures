namespace neetcode.P1598_CrawlerLogFolder;

// https://leetcode.com/problems/crawler-log-folder/description/
// https://neetcode.io/problems/crawler-log-folder/question
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
