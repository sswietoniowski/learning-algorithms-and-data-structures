namespace leetcode.P1545_FindKthBitInNthBinaryString;

// https://leetcode.com/problems/find-kth-bit-in-nth-binary-string/description/?envType=daily-question&envId=2026-03-03
public class Solution
{
    public char FindKthBit(int n, int k)
    {
        if (n == 1)
        {
            return '0';
        }

        int length = (1 << n) - 1;
        int mid = length / 2 + 1;

        if (k == mid)
        {
            return '1';
        }
        else if (k < mid)
        {
            return FindKthBit(n - 1, k);
        }
        else
        {
            char mirroredBit = FindKthBit(n - 1, length - k + 1);
            return mirroredBit == '0' ? '1' : '0';
        }
    }
}
