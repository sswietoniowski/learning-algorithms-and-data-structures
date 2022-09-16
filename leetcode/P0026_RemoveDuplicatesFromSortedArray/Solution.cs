namespace leetcode.P0026_RemoveDuplicatesFromSortedArray;

public class Solution
{
    // https://leetcode.com/problems/remove-duplicates-from-sorted-array/
    public int RemoveDuplicates(int[] nums)
    {
        int k = 0;
        for (int i = 1; i < nums.Length; i++)
        {
            if (nums[k] != nums[i])
            {
                k++;
                nums[k] = nums[i];
            }
        }
        return k + 1;
    }
}