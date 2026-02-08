namespace neetcode.P0081_SearchInRotatedSortedArrayII;

// https://leetcode.com/problems/search-in-rotated-sorted-array-ii/description/
// https://neetcode.io/problems/search-in-rotated-sorted-array-ii/question
public class Solution
{
    public bool Search(int[] nums, int target)
    {
        int n = nums.Length;
        int start = 0;
        int end = n - 1;

        while (start <= end)
        {
            int mid = start + (end - start) / 2;

            if (nums[mid] == target)
            {
                return true;
            }

            if (nums[start] == nums[mid])
            {
                start++;
                continue;
            }
            else if (nums[start] < nums[mid])
            {
                if (target >= nums[start] && target < nums[mid])
                {
                    end = mid - 1;
                }
                else
                {
                    start = mid + 1;
                }
            }
            else
            {
                if (target > nums[mid] && target <= nums[end])
                {
                    start = mid + 1;
                }
                else
                {
                    end = mid - 1;
                }
            }
        }

        return false;
    }
}
