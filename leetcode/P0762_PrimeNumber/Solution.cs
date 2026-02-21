namespace leetcode.P0762_PrimeNumber;

// https://leetcode.com/problems/prime-number-of-set-bits-in-binary-representation/description/?envType=daily-question&envId=2026-02-21
using System.Numerics;

public class Solution
{
    public int CountPrimeSetBits(int left, int right)
    {
        if (left > right)
        {
            return 0;
        }

        var primeSet = new HashSet<int>() { 2, 3, 5, 7, 11, 13, 17, 19 };

        int count = 0;
        for (int i = left; i <= right; i++)
        {
            int bits = BitOperations.PopCount((uint)i);
            if (primeSet.Contains(bits))
            {
                count++;
            }
        }

        return count;
    }
}
