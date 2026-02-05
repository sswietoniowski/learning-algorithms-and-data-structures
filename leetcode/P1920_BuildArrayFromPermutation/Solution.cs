namespace leetcode.P1920_BuildArrayFromPermutation;

// https://leetcode.com/problems/build-array-from-permutation/description/
public class Solution
{
    public int[] BuildArray(int[] nums)
    {
        var result = new int[nums.Length];
        for (int i = 0; i < nums.Length; i++)
        {
            result[i] = nums[nums[i]];
        }
        return result;
    }
}
