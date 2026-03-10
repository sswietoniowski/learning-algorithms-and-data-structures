namespace neetcode.P0377_CombinationSumIV;

// https://leetcode.com/problems/combination-sum-iv/description/
// https://neetcode.io/problems/combination-sum-iv/question?list=neetcode250
public class Solution
{
    public int CombinationSum4(int[] nums, int target)
    {
        // dp[i] will store the number of combinations that add up to i
        int[] dp = new int[target + 1];

        // Base case: There is 1 way to reach a target of 0 (by choosing nothing)
        dp[0] = 1;

        // Iterate through all possible target values from 1 to the actual target
        for (int i = 1; i <= target; i++)
        {
            // For each target i, try adding every number from nums
            foreach (int num in nums)
            {
                // If the current number is less than or equal to the target i
                if (i - num >= 0)
                {
                    // Add the number of ways to reach (i - num) to our current total
                    dp[i] += dp[i - num];
                }
            }
        }

        return dp[target];
    }
}
