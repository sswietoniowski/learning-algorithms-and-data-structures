namespace leetcode.P0012_IntegerToRoman;

// https://leetcode.com/problems/integer-to-roman/description/
using System.Text;

public class Solution
{
    public string IntToRoman(int num)
    {
        // 1. Define all "building blocks" in descending order.
        // This includes the standard symbols and the special subtractive forms.
        int[] values = { 1000, 900, 500, 400, 100, 90, 50, 40, 10, 9, 5, 4, 1 };
        string[] symbols =
        {
            "M",
            "CM",
            "D",
            "CD",
            "C",
            "XC",
            "L",
            "XL",
            "X",
            "IX",
            "V",
            "IV",
            "I",
        };

        // 2. Use StringBuilder for better performance when concatenating strings in a loop.
        StringBuilder roman = new StringBuilder();

        // 3. Iterate through our values array.
        for (int i = 0; i < values.Length && num > 0; i++)
        {
            // While the current value can be subtracted from num,
            // keep appending the symbol and subtracting the value.
            while (num >= values[i])
            {
                num -= values[i];
                roman.Append(symbols[i]);
            }
        }

        return roman.ToString();
    }
}
