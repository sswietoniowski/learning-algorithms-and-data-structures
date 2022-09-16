namespace neetcode.P0001_TwoSum;

public class Solution
{
    // https://leetcode.com/problems/two-sum/
    // https://youtu.be/KLlXCFG5TnA
    public int[] TwoSum(int[] nums, int target)
    {
        // v1
        //int[] result = new int[2];
        //for (int i = 0; i < nums.Length - 1; i++)
        //{
        //    for (int j = i + 1; j < nums.Length; j++)
        //    {
        //        if (nums[i] + nums[j] == target)
        //        {
        //            result[0] = i;
        //            result[1] = j;
        //            return result;
        //        }
        //    }
        //}
        //return result;

        // v2
        Dictionary<int, int> mapping = new();

        for (int i = 0; i < nums.Length; i++)
        {
            int complement = target - nums[i];

            if (mapping.ContainsKey(complement))
            {
                return new int[] { mapping[complement], i };
            }

            if (!mapping.ContainsKey(nums[i]))
            {
                mapping.Add(nums[i], i);
            }
        }

        return null;
    }
}