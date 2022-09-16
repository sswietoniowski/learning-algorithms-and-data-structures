namespace neetcode.P0128_LongestConsecutiveSequence;

// https://leetcode.com/problems/longest-consecutive-sequence/
// https://youtu.be/P6RZZMu_maU
public class Solution
{
    public int LongestConsecutive(int[] nums)
    {
        if (nums.Length <= 1)
        {
            return nums.Length;
        }

        HashSet<int> set = new HashSet<int>(nums);

        int longest = 1;
        int current = 1;

        for (int i = 0; i < nums.Length; i++)
        {
            if (!set.Contains(nums[i] - 1))
            {
                current = 1;
                int j = nums[i] + 1;
                while (set.Contains(j))
                {
                    current++;
                    j++;
                }

                if (current > longest)
                {
                    longest = current;
                }
            }
        }

        return longest;
    }
}