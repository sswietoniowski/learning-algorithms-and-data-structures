namespace neetcode.P0017_LetterCombinationsOfAPhoneNumber;

// https://leetcode.com/problems/letter-combinations-of-a-phone-number/
// https://youtu.be/0snEunUacZY
public class Solution
{
    public IList<string> LetterCombinations(string digits)
    {
        var result = new List<string>();

        if (digits.Length == 0)
        {
            return result;
        }

        var map = new Dictionary<char, string>()
        {
            {'2', "abc"},
            {'3', "def"},
            {'4', "ghi"},
            {'5', "jkl"},
            {'6', "mno"},
            {'7', "pqrs"},
            {'8', "tuv"},
            {'9', "wxyz"}
        };

        var queue = new Queue<string>();

        queue.Enqueue("");

        while (queue.Count > 0)
        {
            var current = queue.Dequeue();

            if (current.Length == digits.Length)
            {
                result.Add(current);
            }
            else
            {
                var letters = map[digits[current.Length]];

                foreach (var letter in letters)
                {
                    queue.Enqueue(current + letter);
                }
            }
        }

        return result;
    }
}