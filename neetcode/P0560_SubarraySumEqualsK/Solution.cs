namespace neetcode.P0560_SubarraySumEqualsK;

// https://leetcode.com/problems/subarray-sum-equals-k/description/
// https://neetcode.io/problems/subarray-sum-equals-k/question?list=neetcode250
public class Solution
{
    public int SubarraySum(int[] nums, int k)
    {
        int res = 0,
            curSum = 0;
        Dictionary<int, int> prefixSums = new Dictionary<int, int>();
        prefixSums[0] = 1;

        foreach (int num in nums)
        {
            curSum += num;
            int diff = curSum - k;

            if (prefixSums.ContainsKey(diff))
            {
                res += prefixSums[diff];
            }

            if (!prefixSums.ContainsKey(curSum))
            {
                prefixSums[curSum] = 0;
            }
            prefixSums[curSum]++;
        }

        return res;
    }
}
