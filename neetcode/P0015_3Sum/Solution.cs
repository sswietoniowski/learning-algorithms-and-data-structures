namespace neetcode.P0015_3Sum;

// https://leetcode.com/problems/3sum/
// https://youtu.be/jzZsG8n2R9A
public class Solution
{
    public IList<IList<int>> ThreeSum(int[] nums)
    {
        Array.Sort(nums);

        IList<IList<int>> result = new List<IList<int>>();

        for (int i = 0; i < nums.Length; i++)
        {
            if (i > 0 && nums[i] == nums[i - 1])
            {
                continue;
            }

            int left = i + 1;
            int right = nums.Length - 1;

            while (left < right)
            {
                int threeSum = nums[i] + nums[left] + nums[right];
                if (threeSum > 0)
                {
                    right--;
                }
                else if (threeSum < 0)
                {
                    left++;
                }
                else
                {
                    result.Add(new List<int> { nums[i], nums[left], nums[right] });
                    left++;
                    while (nums[left] == nums[left - 1] && left < right)
                    {
                        left++;
                    }
                }
            }
        }

        return result;
    }
}