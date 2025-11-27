namespace neetcode.P0152_MaximumProductSubarray;

// https://leetcode.com/problems/maximum-product-subarray/description/
// https://neetcode.io/problems/maximum-product-subarray/question?list=blind75
public class Solution
{
    public int MaxProduct(int[] nums)
    {
        int n = nums.Length;
        int res = nums[0];
        int prefix = 0,
            suffix = 0;

        for (int i = 0; i < n; i++)
        {
            prefix = nums[i] * (prefix == 0 ? 1 : prefix);
            suffix = nums[n - 1 - i] * (suffix == 0 ? 1 : suffix);
            res = Math.Max(res, Math.Max(prefix, suffix));
        }
        return res;
    }
}
