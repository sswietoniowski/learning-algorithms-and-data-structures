namespace neetcode.P0287_FindTheDuplicateNumber;

public class Solution
{
    // https://leetcode.com/problems/find-the-duplicate-number/
    // https://youtu.be/wjYnzkAhcNk
    public int FindDuplicate(int[] nums)
    {
        int slow = 0;
        int fast = 0;

        do
        {
            slow = nums[slow];
            fast = nums[nums[fast]];
        } while (slow != fast);

        int slow2 = 0;
        while (slow2 != slow)
        {
            slow2 = nums[slow2];
            slow = nums[slow];
        }

        return slow;
    }
}