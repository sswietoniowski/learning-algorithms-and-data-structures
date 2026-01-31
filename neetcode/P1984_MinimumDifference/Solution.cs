namespace neetcode.P1984_MinimumDifference;

// https://leetcode.com/problems/minimum-difference-between-highest-and-lowest-of-k-scores/description/
// https://neetcode.io/problems/minimum-difference-between-highest-and-lowest-of-k-scores/question
public class Solution
{
    public int MinimumDifference(int[] nums, int k)
    {
        if (k == 1)
        {
            return 0;
        }

        Array.Sort(nums);

        int minDifference = int.MaxValue;

        for (int i = k - 1; i < nums.Length; i++)
        {
            int currentDifference = nums[i] - nums[i - k + 1];
            if (currentDifference < minDifference)
            {
                minDifference = currentDifference;
            }
        }

        return minDifference;
    }
}
