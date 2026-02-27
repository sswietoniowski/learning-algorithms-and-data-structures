namespace neetcode.P1863_SumOfAllSubsetXORTotals;

// https://leetcode.com/problems/sum-of-all-subset-xor-totals/description/
// https://neetcode.io/problems/sum-of-all-subset-xor-totals/question
// v1
/*
public class Solution
{
    public int SubsetXORSum(int[] nums)
    {
        return backtrack(nums, 0, 0);
    }

    private int backtrack(int[] nums, int index, int currentXor)
    {
        if (index == nums.Length)
            return currentXor;

        return backtrack(nums, index + 1, currentXor)
            + backtrack(nums, index + 1, currentXor ^ nums[index]);
    }
}
*/
// v2
public class Solution
{
    public int SubsetXORSum(int[] nums)
    {
        int allOr = 0;
        foreach (int num in nums)
        {
            allOr |= num;
        }

        return allOr << (nums.Length - 1);
    }
}
