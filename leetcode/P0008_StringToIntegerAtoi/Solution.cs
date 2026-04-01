namespace leetcode.P0008_StringToIntegerAtoi;

// https://leetcode.com/problems/string-to-integer-atoi/description/
public class Solution
{
    public int MyAtoi(string s)
    {
        if (string.IsNullOrEmpty(s))
            return 0;

        int i = 0;
        int n = s.Length;
        int sign = 1;
        long result = 0; // Use long to handle values outside the 32-bit int range during calculation

        // Step 1: Skip leading whitespace
        while (i < n && s[i] == ' ')
        {
            i++;
        }

        // If we reached the end after skipping spaces
        if (i == n)
            return 0;

        // Step 2: Determine Signedness
        if (s[i] == '+' || s[i] == '-')
        {
            sign = (s[i] == '-') ? -1 : 1;
            i++;
        }

        // Step 3: Conversion and Rounding
        while (i < n && char.IsDigit(s[i]))
        {
            int digit = s[i] - '0';

            // Build the number
            result = (result * 10) + digit;

            // Step 4: Check for 32-bit overflow/underflow immediately
            // We check this inside the loop to handle extremely long strings
            // that might even exceed the capacity of a 'long'.
            if (sign == 1 && result > int.MaxValue)
            {
                return int.MaxValue;
            }
            if (sign == -1 && -result < int.MinValue)
            {
                return int.MinValue;
            }

            i++;
        }

        return (int)(result * sign);
    }
}
