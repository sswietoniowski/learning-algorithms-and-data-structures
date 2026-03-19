namespace neetcode.P0201_BitwiseANDOfNumbersRange;

// https://leetcode.com/problems/bitwise-and-of-numbers-range/description/
// https://neetcode.io/problems/bitwise-and-of-numbers-range/question?list=neetcode250
public class Solution
{
    public int RangeBitwiseAnd(int left, int right)
    {
        int shift = 0;

        // While the numbers are different, they haven't reached the common prefix
        while (left < right)
        {
            left >>= 1;
            right >>= 1;
            shift++;
        }

        // Shift the common prefix back to its original position
        return left << shift;
    }
}
