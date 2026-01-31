namespace neetcode.P1189_MaximumNumberOfBalloons;

// https://leetcode.com/problems/maximum-number-of-balloons/description/
// https://neetcode.io/problems/maximum-number-of-balloons/question?list=allNC
public class Solution
{
    public int MaxNumberOfBalloons(string text)
    {
        var frequencies = new Dictionary<char, int>();
        string word = "balloon";

        foreach (var c in text)
        {
            if (word.Contains(c))
            {
                if (frequencies.ContainsKey(c))
                {
                    frequencies[c]++;
                }
                else
                {
                    frequencies.Add(c, 1);
                }
            }
        }

        int combinations = int.MaxValue;

        foreach (var c in "balon")
        {
            if (frequencies.ContainsKey(c))
            {
                switch (c)
                {
                    case 'b':
                    case 'a':
                    case 'n':
                        combinations = Math.Min(frequencies.GetValueOrDefault(c), combinations);
                        break;
                    case 'l':
                    case 'o':
                        combinations = Math.Min(frequencies.GetValueOrDefault(c) / 2, combinations);
                        break;
                }
            }
            else
            {
                combinations = 0;
                break;
            }
        }

        return combinations;
    }
}
