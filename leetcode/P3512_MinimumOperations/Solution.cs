namespace leetcode.P3512_MinimumOperations;

// https://leetcode.com/problems/minimum-operations-to-make-array-sum-divisible-by-k/description/
// v1
public class Solution
{
    public int MinOperations(int[] nums, int k)
    {
        int sum = 0;
        foreach (var n in nums)
        {
            sum += n;
        }
        return sum % k;
    }
}
