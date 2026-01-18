namespace neetcode.P0724_FindPivotIndex;

// https://leetcode.com/problems/find-pivot-index/description/
// https://neetcode.io/problems/find-pivot-index/question
public class Solution
{
    public int PivotIndex(int[] nums)
    {
        int total = 0;
        foreach (int num in nums)
        {
            total += num;
        }
        int leftSum = 0;
        for (int i = 0; i < nums.Length; i++)
        {
            int rightSum = total - nums[i] - leftSum;
            if (leftSum == rightSum)
            {
                return i;
            }
            leftSum += nums[i];
        }
        return -1;
    }
}
