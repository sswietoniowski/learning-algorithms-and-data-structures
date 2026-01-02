namespace neetcode.P0485_MaxConsecutiveOnes;

// https://leetcode.com/problems/max-consecutive-ones/description/
// https://neetcode.io/problems/max-consecutive-ones/question
public class Solution
{
    public int FindMaxConsecutiveOnes(int[] nums)
    {
        int max = 0;
        for (int i = 0, counter = 0; i < nums.Length; i++)
        {
            if (nums[i] == 1)
            {
                counter++;
                if (counter > max)
                {
                    max = counter;
                }
            }
            else
            {
                counter = 0;
            }
        }
        return max;
    }
}
