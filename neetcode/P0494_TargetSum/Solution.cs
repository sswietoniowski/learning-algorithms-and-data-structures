namespace neetcode.P0494_TargetSum;

// https://leetcode.com/problems/target-sum/description/
// https://neetcode.io/problems/target-sum/question?list=neetcode150
public class Solution
{
    public int FindTargetSumWays(int[] nums, int target)
    {
        Dictionary<int, int> dp = new Dictionary<int, int>();
        dp[0] = 1;

        foreach (int num in nums)
        {
            Dictionary<int, int> nextDp = new Dictionary<int, int>();
            foreach (var entry in dp)
            {
                int total = entry.Key;
                int count = entry.Value;

                if (!nextDp.ContainsKey(total + num))
                {
                    nextDp[total + num] = 0;
                }
                nextDp[total + num] += count;

                if (!nextDp.ContainsKey(total - num))
                {
                    nextDp[total - num] = 0;
                }
                nextDp[total - num] += count;
            }
            dp = nextDp;
        }
        return dp.ContainsKey(target) ? dp[target] : 0;
    }
}
