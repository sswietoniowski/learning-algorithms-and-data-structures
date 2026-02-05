namespace leetcode.P3379_TransformedArray;

// https://leetcode.com/problems/transformed-array/description/?envType=daily-question&envId=2026-02-05
// v1
/*
public class Solution
{
    public int[] ConstructTransformedArray(int[] nums)
    {
        var result = new int[nums.Length];

        for (int i = 0, j = 0; i < nums.Length; i++)
        {
            if (nums[i] > 0)
            {
                j = (i + nums[i]) % nums.Length;
            }
            else if (nums[i] < 0)
            {
                if (i - Math.Abs(nums[i]) > 0)
                {
                    j = i - Math.Abs(nums[i]);
                }
                else
                {
                    j =
                        (nums.Length - Math.Abs((i - Math.Abs(nums[i]))) % nums.Length)
                        % nums.Length;
                }
            }
            else
            {
                j = i;
            }
            result[i] = nums[j];
        }

        return result;
    }
}
*/
// v2
public class Solution
{
    public int[] ConstructTransformedArray(int[] nums)
    {
        int n = nums.Length;
        int[] result = new int[n];

        for (int i = 0; i < n; i++)
        {
            int targetIndex = ((i + nums[i]) % n + n) % n;
            result[i] = nums[targetIndex];
        }

        return result;
    }
}
