namespace neetcode.P0080_RemoveDuplicatesFromSortedArrayII;

// https://leetcode.com/problems/remove-duplicates-from-sorted-array-ii/description/
public class Solution
{
    public int RemoveDuplicates(int[] nums)
    {
        int n = nums.Length;
        if (n <= 2)
        {
            return n;
        }

        int left = 2;
        for (int right = 2; right < n; right++)
        {
            if (nums[right] != nums[left - 2])
            {
                nums[left] = nums[right];
                left++;
            }
        }

        return left;
    }
}
