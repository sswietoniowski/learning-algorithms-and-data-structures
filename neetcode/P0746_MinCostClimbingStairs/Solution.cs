namespace neetcode.P0746_MinCostClimbingStairs;

// https://leetcode.com/problems/min-cost-climbing-stairs/
// https://youtu.be/ktmzAZWkEZ0
public class Solution
{
    public int MinCostClimbingStairs(int[] cost)
    {
        var dp = new int[cost.Length + 1];

        Array.Copy(cost, dp, cost.Length);

        for (var i = dp.Length - 3; i >= 0; i--)
        {
            dp[i] += Math.Min(dp[i + 1], dp[i + 2]);
        }

        return Math.Min(dp[0], dp[1]);
    }
}