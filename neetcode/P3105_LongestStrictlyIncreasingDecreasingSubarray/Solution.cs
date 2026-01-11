namespace neetcode.P3105_LongestStrictlyIncreasingDecreasingSubarray;

// https://leetcode.com/problems/longest-strictly-increasing-or-strictly-decreasing-subarray/
// v1
/*
public class Solution
{
    public int LongestMonotonicSubarray(int[] nums)
    {
        int direction = 0;
        int maxLength = 1;
        int currentLength = 1;
        int previousNum = nums[0];
        for (int i = 1; i < nums.Length; i++)
        {
            if (nums[i - 1] < nums[i])
            {
                if (direction != 1)
                {
                    maxLength = maxLength >= currentLength ? maxLength : currentLength;
                    currentLength = 1;
                }
                currentLength++;
                direction = 1;
            }
            else if (nums[i - 1] > nums[i])
            {
                if (direction != -1)
                {
                    maxLength = maxLength >= currentLength ? maxLength : currentLength;
                    currentLength = 1;
                }
                currentLength++;
                direction = -1;
            }
            else
            {
                maxLength = maxLength >= currentLength ? maxLength : currentLength;
                currentLength = 1;
                direction = 0;
            }
        }
        maxLength = maxLength >= currentLength ? maxLength : currentLength;
        return maxLength;
    }
}
*/
// v2
public class Solution
{
    public int LongestMonotonicSubarray(int[] nums)
    {
        if (nums.Length == 0)
            return 0;

        int maxLen = 1;
        int inc = 1;
        int dec = 1;

        for (int i = 1; i < nums.Length; i++)
        {
            if (nums[i] > nums[i - 1])
            {
                inc++;
                dec = 1;
            }
            else if (nums[i] < nums[i - 1])
            {
                dec++;
                inc = 1;
            }
            else
            {
                inc = 1;
                dec = 1;
            }

            maxLen = Math.Max(maxLen, Math.Max(inc, dec));
        }

        return maxLen;
    }
}
