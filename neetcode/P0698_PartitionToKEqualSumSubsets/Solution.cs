namespace neetcode.P0698_PartitionToKEqualSumSubsets;

// https://leetcode.com/problems/partition-to-k-equal-sum-subsets/description/
// https://neetcode.io/problems/partition-to-k-equal-sum-subsets/question?list=neetcode250
public class Solution
{
    public bool CanPartitionKSubsets(int[] nums, int k)
    {
        int sum = 0;
        foreach (int n in nums)
            sum += n;

        // If total sum isn't divisible by k, it's impossible
        if (sum % k != 0)
            return false;

        int target = sum / k;
        Array.Sort(nums);
        Array.Reverse(nums); // Sorting descending helps prune the search tree faster

        // If the largest element is bigger than target, it's impossible
        if (nums[0] > target)
            return false;

        // Memoization: map the bitmask (used elements) to a boolean
        // 1 << nums.Length creates a bitmask for all possible combinations
        bool?[] memo = new bool?[1 << nums.Length];

        return Backtrack(0, 0, k, target, nums, memo);
    }

    private bool Backtrack(int mask, int currentSum, int k, int target, int[] nums, bool?[] memo)
    {
        // Base case: If we have filled k-1 subsets, the last one must be valid
        if (k == 1)
            return true;

        // Check if we've already computed this "used elements" state
        if (memo[mask].HasValue)
            return memo[mask].Value;

        // If current subset is full, move to the next subset (k - 1)
        if (currentSum == target)
        {
            return (bool)(memo[mask] = Backtrack(mask, 0, k - 1, target, nums, memo));
        }

        for (int i = 0; i < nums.Length; i++)
        {
            // Check if the i-th bit is NOT set (number not used yet)
            if (((mask >> i) & 1) == 0)
            {
                // If adding this number doesn't exceed target
                if (currentSum + nums[i] <= target)
                {
                    // Set the i-th bit and recurse
                    if (Backtrack(mask | (1 << i), currentSum + nums[i], k, target, nums, memo))
                    {
                        return (bool)(memo[mask] = true);
                    }
                }
            }
        }

        return (bool)(memo[mask] = false);
    }
}
