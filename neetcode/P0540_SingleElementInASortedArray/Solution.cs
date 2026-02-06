namespace neetcode.P0540_SingleElementInASortedArray;

// https://leetcode.com/problems/single-element-in-a-sorted-array/description/
// https://neetcode.io/problems/single-element-in-a-sorted-array/question
public class Solution
{
    public int SingleNonDuplicate(int[] nums)
    {
        int start = 0;
        int end = nums.Length - 1;
        while (start < end)
        {
            int mid = start + (end - start) / 2;
            if (nums[mid] == nums[mid ^ 1])
            {
                start = mid + 1;
            }
            else
            {
                end = mid;
            }
        }
        return nums[start];
    }
}
