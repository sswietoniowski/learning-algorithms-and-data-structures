namespace neetcode.P0918_MaximumSumCircularSubarray;

// https://leetcode.com/problems/maximum-sum-circular-subarray/description/
// https://neetcode.io/problems/maximum-sum-circular-subarray/question?list=neetcode250
public class Solution
{
    public int MaxSubarraySumCircular(int[] nums)
    {
        int totalSum = 0;
        int maxSum = nums[0],
            curMax = 0;
        int minSum = nums[0],
            curMin = 0;

        foreach (int x in nums)
        {
            // Standard Kadane's for Maximum Subarray
            curMax = Math.Max(curMax + x, x);
            maxSum = Math.Max(maxSum, curMax);

            // Modified Kadane's for Minimum Subarray
            curMin = Math.Min(curMin + x, x);
            minSum = Math.Min(minSum, curMin);

            totalSum += x;
        }

        // If maxSum is negative, the entire array consists of negative numbers.
        // In this case, totalSum - minSum would result in 0 (an empty subarray),
        // but the problem requires a non-empty subarray.
        if (maxSum < 0)
        {
            return maxSum;
        }

        // The answer is the maximum of:
        // 1. The standard maximum subarray (no wrap-around)
        // 2. The wrap-around subarray (Total Sum - Minimum Subarray)
        return Math.Max(maxSum, totalSum - minSum);
    }
}
