namespace neetcode.P0136_SingleNumber;

public class Solution
{
    // https://leetcode.com/problems/single-number/
    // https://youtu.be/qMPX1AOa83k
    public int SingleNumber(int[] nums)
    {
        if (nums.Length == 1)
        {
            return nums[0];
        }

        Dictionary<int, int> occurrences = new();

        for (int i = 0; i < nums.Length; i++)
        {
            if (occurrences.ContainsKey(nums[i]))
            {
                occurrences[nums[i]] += 1;
            }
            else
            {
                occurrences.Add(nums[i], 1);
            }
        }

        foreach (var kvp in occurrences)
        {
            if (kvp.Value == 1)
            {
                return kvp.Key;
            }
        }

        throw new ArgumentException();
    }
}