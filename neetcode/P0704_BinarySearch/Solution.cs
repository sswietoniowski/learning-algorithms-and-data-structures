namespace neetcode.P0704_BinarySearch
{
    public class Solution
    {
        // https://leetcode.com/problems/binary-search/
        // https://youtu.be/s4DPM8ct1pI
        public int BinarySearch(int[] nums, int target)
        {
            int low = 0;
            int mid;
            int high = nums.Length - 1;

            while (low <= high)
            {
                mid = low + (high - low) / 2;

                if (nums[mid] == target)
                {
                    return mid;
                }
                else if (nums[mid] < target)
                {
                    low = mid + 1;
                }
                else
                {
                    high = mid - 1;
                }
            }

            return -1;
        }
    }
}
