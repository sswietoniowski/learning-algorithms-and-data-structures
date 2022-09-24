namespace neetcode.P0153_FindMinimumInRotatedSortedArray;

// https://leetcode.com/problems/find-minimum-in-rotated-sorted-array/
// https://youtu.be/nIVW4P8b1VA
public class Solution
{
    public int FindMin(int[] nums)
    {
        if (nums.Length == 1)
        {
            return nums[0];
        }
            
        int result = nums[0];
            
        int left = 0;
        int right = nums.Length - 1;

        while (left <= right)
        {
            if (nums[left] < nums[right])
            {
                result = Math.Min(result, nums[left]);
                break;
            }

            int mid = left + (right - left) / 2;

            result = Math.Min(result, nums[mid]);

            if (nums[left] <= nums[mid])
            {
                left = mid + 1;
            }
            else
            {
                right = mid - 1;
            }
        }

        return result;
    }
}