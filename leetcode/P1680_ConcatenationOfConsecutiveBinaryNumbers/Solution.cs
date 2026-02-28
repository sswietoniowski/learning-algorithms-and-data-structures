namespace leetcode.P1680_ConcatenationOfConsecutiveBinaryNumbers;

// https://leetcode.com/problems/concatenation-of-consecutive-binary-numbers/description/?envType=daily-question&envId=2026-02-28
public class Solution
{
    public int ConcatenatedBinary(int n)
    {
        long result = 0;
        int MOD = 1_000_000_007;
        int binaryLength = 0;

        for (int i = 1; i <= n; i++)
        {
            if ((i & (i - 1)) == 0)
            {
                binaryLength++;
            }

            result = ((result << binaryLength) | (uint)i) % MOD;
        }

        return (int)result;
    }
}
