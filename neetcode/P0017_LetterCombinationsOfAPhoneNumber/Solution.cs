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

        void Backtrack(string combination, int index)
        {
            if (index == digits.Length)
            {
                result.Add(combination);
                return;
            }

            var digit = digits[index];
            var letters = map[digit];

            foreach (var letter in letters)
            {
                Backtrack(combination + letter, index + 1);
            }
        }

        Backtrack("", 0);

        return result;
    }
}