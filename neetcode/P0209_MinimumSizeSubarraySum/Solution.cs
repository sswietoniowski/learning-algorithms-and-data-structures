namespace neetcode.P0209_MinimumSizeSubarraySum;

// https://leetcode.com/problems/minimum-size-subarray-sum/description/
// https://neetcode.io/problems/minimum-size-subarray-sum/question
public class Solution
{
    public int MinSubArrayLen(int target, int[] nums)
    {
        int l = 0;
        int total = 0;
        int result = nums.Length + 1;

        for (int r = 0; r < nums.Length; r++)
        {
            total += nums[r];
            while (total >= target)
            {
                result = Math.Min(result, r - l + 1);
                total -= nums[l];
                l++;
            }
        }

        return result == nums.Length + 1 ? 0 : result;
    }
}
