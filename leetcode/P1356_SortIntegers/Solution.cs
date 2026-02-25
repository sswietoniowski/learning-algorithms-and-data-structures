namespace leetcode.P1356_SortIntegers;

// https://leetcode.com/problems/sort-integers-by-the-number-of-1-bits/description/?envType=daily-question&envId=2026-02-25
using System.Numerics;

public class Solution
{
    public int[] SortByBits(int[] arr)
    {
        Array.Sort(
            arr,
            (a, b) =>
            {
                int aBits = BitOperations.PopCount((uint)a);
                int bBits = BitOperations.PopCount((uint)b);
                int result = aBits.CompareTo(bBits);
                return result != 0 ? result : a.CompareTo(b);
            }
        );
        return arr;
    }
}
