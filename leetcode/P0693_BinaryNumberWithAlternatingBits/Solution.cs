namespace leetcode.P0693_BinaryNumberWithAlternatingBits;

// https://leetcode.com/problems/binary-number-with-alternating-bits/description/?envType=daily-question&envId=2026-02-18
public class Solution
{
    public bool HasAlternatingBits(int n)
    {
        uint result = (uint)n ^ ((uint)n >> 1);
        return (result & (result + 1)) == 0;
    }
}
