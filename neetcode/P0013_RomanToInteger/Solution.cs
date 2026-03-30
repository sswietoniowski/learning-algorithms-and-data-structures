namespace neetcode.P0013_RomanToInteger;

// https://leetcode.com/problems/roman-to-integer/description/
// https://neetcode.io/problems/roman-to-integer/question?list=neetcode250
public class Solution
{
    public int RomanToInt(string s)
    {
        // 1. Map Roman symbols to their integer values
        Dictionary<char, int> romanValues = new Dictionary<char, int>
        {
            { 'I', 1 },
            { 'V', 5 },
            { 'X', 10 },
            { 'L', 50 },
            { 'C', 100 },
            { 'D', 500 },
            { 'M', 1000 },
        };

        int total = 0;
        int n = s.Length;

        for (int i = 0; i < n; i++)
        {
            int currentValue = romanValues[s[i]];

            // 2. Look ahead: If there is a next character and it's larger,
            // we subtract the current value (e.g., IV where 1 < 5)
            if (i + 1 < n && currentValue < romanValues[s[i + 1]])
            {
                total -= currentValue;
            }
            // 3. Otherwise, we add it normally
            else
            {
                total += currentValue;
            }
        }

        return total;
    }
}
