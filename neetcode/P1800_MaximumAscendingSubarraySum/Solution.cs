namespace neetcode.P1800_MaximumAscendingSubarraySum;

// https://leetcode.com/problems/maximum-ascending-subarray-sum/description/
public class Solution
{
    public int MaxAscendingSum(int[] nums)
    {
        int maximumSum = nums[0];
        int currentSum = nums[0];
        int previousValue = nums[0];

        for (int i = 1; i < nums.Length; i++)
        {
            if (nums[i] > previousValue)
            {
                currentSum += nums[i];
                maximumSum = Math.Max(maximumSum, currentSum);
            }
            else
            {
                currentSum = nums[i];
            }
            previousValue = nums[i];
        }
        maximumSum = Math.Max(maximumSum, currentSum);

        return maximumSum;
    }
}
