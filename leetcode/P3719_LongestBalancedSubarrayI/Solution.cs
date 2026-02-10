namespace leetcode.P3719_LongestBalancedSubarrayI;

// https://leetcode.com/problems/longest-balanced-subarray-i/?envType=daily-question&envId=2026-02-10
public class Solution
{
    public int LongestBalanced(int[] nums)
    {
        int maxLen = 0;
        int n = nums.Length;

        for (int i = 0; i < n; i++)
        {
            HashSet<int> distinctEvens = new HashSet<int>();
            HashSet<int> distinctOdds = new HashSet<int>();

            for (int j = i; j < n; j++)
            {
                if (nums[j] % 2 == 0)
                {
                    distinctEvens.Add(nums[j]);
                }
                else
                {
                    distinctOdds.Add(nums[j]);
                }

                if (distinctEvens.Count == distinctOdds.Count)
                {
                    maxLen = Math.Max(maxLen, j - i + 1);
                }
            }
        }

        return maxLen;
    }
}
