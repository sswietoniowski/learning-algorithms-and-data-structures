namespace neetcode.P0190_ReverseBits;

// https://leetcode.com/problems/reverse-bits/description/?envType=daily-question&envId=2026-02-16
public class Solution
{
    public int ReverseBits(int n)
    {
        int result = 0;
        for (int i = 0; i < 32; i++)
        {
            result = result << 1;

            result = result | (n & 1);

            n = n >> 1;
        }
        return result;
    }
}
