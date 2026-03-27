namespace neetcode.P3133_MinimumArrayEnd;

// https://leetcode.com/problems/minimum-array-end/description/
// https://neetcode.io/problems/minimum-array-end/question?list=neetcode250
public class Solution
{
    public long MinEnd(int n, int x)
    {
        // We need the (n-1)-th increment because the 1st number is just x
        long remaining = n - 1;
        long result = x;

        // We iterate through bit positions (0 to 63 for a 64-bit long)
        // to find where x has a 0 and fill it with bits from 'remaining'
        for (int i = 0; remaining > 0; i++)
        {
            // Check if the i-th bit of x is 0
            if (((result >> i) & 1) == 0)
            {
                // If it's 0, take the LSB of 'remaining' and put it here
                if ((remaining & 1) == 1)
                {
                    result |= (1L << i);
                }
                // Move to the next bit of 'remaining'
                remaining >>= 1;
            }
        }

        return result;
    }
}
