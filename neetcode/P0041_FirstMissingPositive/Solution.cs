namespace neetcode.P0041_FirstMissingPositive;

// https://leetcode.com/problems/first-missing-positive/description/
// https://neetcode.io/problems/first-missing-positive/question?list=neetcode250
public class Solution
{
    public int FirstMissingPositive(int[] nums)
    {
        int n = nums.Length;

        for (int i = 0; i < n; i++)
        {
            while (nums[i] > 0 && nums[i] <= n && nums[nums[i] - 1] != nums[i])
            {
                int correctIndex = nums[i] - 1;

                int temp = nums[correctIndex];
                nums[correctIndex] = nums[i];
                nums[i] = temp;
            }
        }

        for (int i = 0; i < n; i++)
        {
            if (nums[i] != i + 1)
            {
                return i + 1;
            }
        }

        return n + 1;
    }
}
