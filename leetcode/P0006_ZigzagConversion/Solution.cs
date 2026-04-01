namespace leetcode.P0006_ZigzagConversion;

// https://leetcode.com/problems/zigzag-conversion/description/
using System.Text;

public class Solution
{
    public string Convert(string s, int numRows)
    {
        // Edge case: If there's only one row or the string is
        // shorter than the row count, no zigzagging is possible.
        if (numRows == 1 || s.Length <= numRows)
        {
            return s;
        }

        // Create an array of StringBuilders, one for each row.
        StringBuilder[] rows = new StringBuilder[numRows];
        for (int i = 0; i < numRows; i++)
        {
            rows[i] = new StringBuilder();
        }

        int currentRow = 0;
        bool goingDown = false;

        foreach (char c in s)
        {
            rows[currentRow].Append(c);

            // If we are at the very top or very bottom row,
            // it's time to "bounce" and change direction.
            if (currentRow == 0 || currentRow == numRows - 1)
            {
                goingDown = !goingDown;
            }

            // Move the pointer up or down based on the current direction.
            currentRow += goingDown ? 1 : -1;
        }

        // Combine all rows into one final string.
        StringBuilder result = new StringBuilder();
        foreach (StringBuilder row in rows)
        {
            result.Append(row);
        }

        return result.ToString();
    }
}
