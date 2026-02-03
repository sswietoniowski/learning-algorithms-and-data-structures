namespace neetcode.P0682_BaseballGame;

// https://leetcode.com/problems/baseball-game/description/
// https://neetcode.io/problems/baseball-game/question
// v1
public class Solution
{
    public int CalPoints(string[] operations)
    {
        var results = new Stack<int>();

        foreach (var operation in operations)
        {
            switch (operation)
            {
                case "+":
                    if (results.Count >= 2)
                    {
                        int score2 = results.Pop();
                        int score1 = results.Peek();
                        results.Push(score2);
                        results.Push(score1 + score2);
                    }
                    break;
                case "D":
                    if (results.Count >= 1)
                    {
                        int score = results.Peek();
                        results.Push(2 * score);
                    }
                    break;
                case "C":
                    if (results.Count > 0)
                    {
                        results.Pop();
                    }
                    break;
                default:
                    results.Push(int.Parse(operation));
                    break;
            }
        }

        int sum = 0;
        while (results.Count > 0)
        {
            sum += results.Pop();
        }
        return sum;
    }
}
