namespace neetcode.P0300_LongestIncreasingSubsequence;

// https://leetcode.com/problems/longest-increasing-subsequence/description/
// https://neetcode.io/problems/longest-increasing-subsequence/question?list=blind75
public class Solution
{
    public int LengthOfLIS(int[] nums)
    {
        List<int> dp = new List<int>();
        dp.Add(nums[0]);

        int LIS = 1;
        for (int i = 1; i < nums.Length; i++)
        {
            if (dp[dp.Count - 1] < nums[i])
            {
                dp.Add(nums[i]);
                LIS++;
                continue;
            }

            int idx = dp.BinarySearch(nums[i]);
            if (idx < 0)
                idx = ~idx;
            dp[idx] = nums[i];
        }

        return LIS;
    }
}
