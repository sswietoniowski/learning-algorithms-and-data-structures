namespace neetcode.P0047_PermutationsII;

// https://leetcode.com/problems/permutations-ii/description/
// https://neetcode.io/problems/permutations-ii/question?list=neetcode250
public class Solution
{
    public IList<IList<int>> PermuteUnique(int[] nums)
    {
        var results = new List<IList<int>>();
        var currentPath = new List<int>();
        bool[] used = new bool[nums.Length];

        // 1. Sort the array to handle duplicates
        Array.Sort(nums);

        Backtrack(nums, used, currentPath, results);

        return results;
    }

    private void Backtrack(
        int[] nums,
        bool[] used,
        IList<int> currentPath,
        IList<IList<int>> results
    )
    {
        // Base case: If the path is the same length as nums, we found a permutation
        if (currentPath.Count == nums.Length)
        {
            results.Add(new List<int>(currentPath));
            return;
        }

        for (int i = 0; i < nums.Length; i++)
        {
            // Skip if this specific element is already in our current path
            if (used[i])
                continue;

            // 2. Skip duplicates:
            // If the current number is the same as the previous number,
            // AND the previous number was NOT used in the current recursive branch,
            // skip it to avoid generating the same permutation again.
            if (i > 0 && nums[i] == nums[i - 1] && !used[i - 1])
            {
                continue;
            }

            // Choose
            used[i] = true;
            currentPath.Add(nums[i]);

            // Explore
            Backtrack(nums, used, currentPath, results);

            // Un-choose (Backtrack)
            currentPath.RemoveAt(currentPath.Count - 1);
            used[i] = false;
        }
    }
}
