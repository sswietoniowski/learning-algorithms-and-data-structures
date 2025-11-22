namespace neetcode.P0213_HouseRobberII;

// https://leetcode.com/problems/house-robber-ii/description/
// https://neetcode.io/problems/house-robber-ii/question?list=blind75
public class Solution
{
    public int Rob(int[] nums)
    {
        if (nums.Length == 1)
            return nums[0];

        return Math.Max(Helper(nums[1..]), Helper(nums[..^1]));
    }

    private int Helper(int[] nums)
    {
        int rob1 = 0,
            rob2 = 0;
        foreach (int num in nums)
        {
            int newRob = Math.Max(rob1 + num, rob2);
            rob1 = rob2;
            rob2 = newRob;
        }
        return rob2;
    }
}
