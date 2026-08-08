namespace leetcode.P3471_FindTheLargestAlmostMissingInteger;

// https://leetcode.com/problems/find-the-largest-almost-missing-integer/description/?envType=daily-question&envId=2026-08-18
public class Solution
{
    public int LargestInteger(int[] nums, int k)
    {
        Dictionary<int, int> counts = new Dictionary<int, int>();
        int n = nums.Length;

        // Iterate through all possible subarrays of size k
        for (int i = 0; i <= n - k; i++)
        {
            HashSet<int> seenInSubarray = new HashSet<int>();

            // Collect unique elements in the current subarray
            for (int j = 0; j < k; j++)
            {
                seenInSubarray.Add(nums[i + j]);
            }

            // Increment the subarray presence count for each unique element
            foreach (int num in seenInSubarray)
            {
                if (!counts.ContainsKey(num))
                {
                    counts[num] = 0;
                }
                counts[num]++;
            }
        }

        int maxAns = -1;

        // Find the maximum integer that appears in exactly 1 subarray
        foreach (var kvp in counts)
        {
            if (kvp.Value == 1)
            {
                maxAns = Math.Max(maxAns, kvp.Key);
            }
        }

        return maxAns;
    }
}
