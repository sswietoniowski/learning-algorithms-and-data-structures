namespace leetcode.P1009_ComplementOfBase10Integer;

// https://leetcode.com/problems/complement-of-base-10-integer/description/?envType=daily-question&envId=2026-03-11
public class Solution
{
    public int BitwiseComplement(int n)
    {
        // Special case: if n is 0, its complement is 1
        if (n == 0)
            return 1;

        // Step 1: Create a mask of all 1s that is the same length as n
        int mask = 0;
        int temp = n;

        while (temp > 0)
        {
            // Shift the mask left and add a 1 at the end
            mask = (mask << 1) | 1;
            // Move to the next bit of temp
            temp >>= 1;
        }

        // Step 2: XOR n with the mask to flip all bits
        return n ^ mask;
    }
}
