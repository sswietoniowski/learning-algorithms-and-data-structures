namespace neetcode.P0303_RangeSumQueryImmutable;

// https://leetcode.com/problems/range-sum-query-immutable/description/
// https://neetcode.io/problems/range-sum-query-immutable/question?list=allNC
// v1
/*
public class NumArray {
    private int[] nums;

    public NumArray(int[] nums) {
        this.nums = nums;
    }
    
    public int SumRange(int left, int right) {
        int sum = 0;

        for int (i = left; i <= right; i++)
        {
            sum += nums[i];
        }

        return sum;
    }
}
*/
// v2
public class NumArray
{
    private int[] prefixes;

    public NumArray(int[] nums)
    {
        prefixes = new int[nums.Length + 1];
        for (int i = 0; i < nums.Length; i++)
        {
            prefixes[i + 1] = prefixes[i] + nums[i];
        }
    }

    public int SumRange(int left, int right)
    {
        return prefixes[right + 1] - prefixes[left];
    }
}
/**
 * Your NumArray object will be instantiated and called as such:
 * NumArray obj = new NumArray(nums);
 * int param_1 = obj.SumRange(left,right);
 */
