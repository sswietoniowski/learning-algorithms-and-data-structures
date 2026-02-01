namespace neetcode.P0896_MonotonicArray;

// https://leetcode.com/problems/monotonic-array/description/
// v1
/*
public class Solution
{
    public bool IsMonotonic(int[] nums)
    {
        if (nums.Length <= 2)
        {
            return true;
        }

        int min = nums[1] - nums[0];
        int max = min;

        for (int i = 2; i < nums.Length; i++)
        {
            min = Math.Min(nums[i] - nums[i - 1], min);
            max = Math.Max(nums[i] - nums[i - 1], max);

            if (min < 0 && max > 0)
            {
                return false;
            }
        }

        return true;
    }
}
*/
// v2
public class Solution
{
    public bool IsMonotonic(int[] nums)
    {
        bool increasing = true;
        bool decreasing = true;

        for (int i = 0; i < nums.Length - 1; i++)
        {
            if (nums[i] > nums[i + 1])
            {
                increasing = false;
            }
            if (nums[i] < nums[i + 1])
            {
                decreasing = false;
            }

            if (!increasing && !decreasing)
            {
                return false;
            }
        }

        return increasing || decreasing;
    }
}
