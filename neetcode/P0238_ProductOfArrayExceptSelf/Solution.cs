namespace neetcode.P0238_ProductOfArrayExceptSelf;

// https://leetcode.com/problems/product-of-array-except-self/
// https://youtu.be/bNvIQI2wAjk
public class Solution
{
    public int[] ProductExceptSelf(int[] nums)
    {
        int[] result = Enumerable.Repeat(1, nums.Length).ToArray();

        int prefix = 1;
        for (int i = 0; i < nums.Length; i++)
        {
            result[i] = prefix;
            prefix *= nums[i];
        }
        int postfix = 1;
        for (int i = nums.Length - 1; i >= 0; i--)
        {
            result[i] *= postfix;
            postfix *= nums[i];
        }

        return result;
    }
}