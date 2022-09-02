namespace neetcode.P0053_MaximumSubarray
{
    // https://leetcode.com/problems/maximum-subarray/
    // https://youtu.be/5WZl3MMT0Eg
    public class Solution
    {
        public int MaxSubArray(int[] nums)
        {
            int maxSum = nums[0];
            int currentSum = 0;
            for (int i = 0; i < nums.Length; i++)
            {
                if (currentSum < 0)
                {
                    currentSum = 0;
                }
                currentSum += nums[i];
                if (currentSum > maxSum)
                {
                    maxSum = currentSum;
                }
            }
            return maxSum;
        }
    }
}
