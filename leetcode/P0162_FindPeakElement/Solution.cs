namespace leetcode.P0162_FindPeakElement;

// https://leetcode.com/problems/find-peak-element/description/
public class Solution
{
    public int FindPeakElement(int[] nums)
    {
        int start = 0;
        int end = nums.Length - 1;
        while (start < end)
        {
            int mid = start + (end - start) / 2;

            if (nums[mid] < nums[mid + 1])
            {
                start = mid + 1;
            }
            else
            {
                end = mid;
            }
        }
        return start;
    }
}
