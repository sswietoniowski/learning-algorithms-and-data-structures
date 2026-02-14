namespace leetcode.P3010_DivideAnArray;

// https://leetcode.com/problems/divide-an-array-into-subarrays-with-minimum-cost-i/description/?envType=daily-question&envId=2026-02-01
public class Solution
{
    public int MinimumCost(int[] nums)
    {
        int sum = nums[0];

        int min1 = int.MaxValue;
        int min2 = int.MaxValue;

        for (int i = 1; i < nums.Length; i++)
        {
            int current = nums[i];

            if (current < min1)
            {
                min2 = min1;
                min1 = current;
            }
            else if (current < min2)
            {
                min2 = current;
            }
        }

        return sum + min1 + min2;
    }
}
