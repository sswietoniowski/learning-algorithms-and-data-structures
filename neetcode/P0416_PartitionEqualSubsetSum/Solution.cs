namespace neetcode.P0416_PartitionEqualSubsetSum;

public class Solution
{
    public bool CanPartition(int[] nums)
    {
        if (Sum(nums) % 2 != 0)
        {
            return false;
        }

        int target = Sum(nums) / 2;
        bool[] dp = new bool[target + 1];

        dp[0] = true;
        for (int i = 0; i < nums.Length; i++)
        {
            for (int j = target; j >= nums[i]; j--)
            {
                dp[j] = dp[j] || dp[j - nums[i]];
            }
        }

        return dp[target];
    }

    private int Sum(int[] nums)
    {
        int total = 0;
        foreach (var num in nums)
        {
            total += num;
        }
        return total;
    }
}
