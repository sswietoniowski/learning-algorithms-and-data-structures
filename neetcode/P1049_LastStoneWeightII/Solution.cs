namespace neetcode.P1049_LastStoneWeightII;

// https://leetcode.com/problems/last-stone-weight-ii/description/
// https://neetcode.io/problems/last-stone-weight-ii/question
public class Solution
{
    public int LastStoneWeightII(int[] stones)
    {
        int totalSum = 0;
        foreach (int stone in stones)
            totalSum += stone;

        // We want to reach a sum as close to half as possible
        int target = totalSum / 2;

        // dp[i] will be true if a sum of 'i' is possible
        bool[] dp = new bool[target + 1];
        dp[0] = true;

        foreach (int weight in stones)
        {
            // Iterate backwards to ensure each stone is used only once
            for (int i = target; i >= weight; i--)
            {
                if (dp[i - weight])
                {
                    dp[i] = true;
                }
            }
        }

        // Find the largest sum 'S1' that is <= target
        for (int i = target; i >= 0; i--)
        {
            if (dp[i])
            {
                // The result is TotalSum - 2 * S1
                // (Because S2 = TotalSum - S1, and we want S2 - S1)
                return totalSum - 2 * i;
            }
        }

        return 0;
    }
}
