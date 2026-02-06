namespace leetcode.P3634_MinimumRemovalsToBalanceArray;

// https://leetcode.com/problems/minimum-removals-to-balance-array/description/?envType=daily-question&envId=2026-02-06
// v1
public class Solution
{
    public int MinRemoval(int[] nums, int k)
    {
        int n = nums.Length;
        if (n <= 1)
            return 0;

        Array.Sort(nums);

        int maxKept = 0;
        int l = 0;

        for (int r = 0; r < n; r++)
        {
            while ((long)nums[r] > (long)nums[l] * k)
            {
                l++;
            }

            int currentWindowSize = r - l + 1;
            if (currentWindowSize > maxKept)
            {
                maxKept = currentWindowSize;
            }
        }

        return n - maxKept;
    }
}
