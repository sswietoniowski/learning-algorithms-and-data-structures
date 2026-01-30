namespace neetcode.P0448_FindAllNumbersDisappeared;

using System.Collections.Generic;

// https://leetcode.com/problems/find-all-numbers-disappeared-in-an-array/description/
// https://neetcode.io/problems/find-all-numbers-disappeared-in-an-array/question
// v1
/*
public class Solution
{
    public List<int> FindDisappearedNumbers(int[] nums)
    {
        var occurrences = new int[nums.Length + 1];
        for (int i = 0; i < nums.Length; i++)
        {
            occurrences[nums[i]]++;
        }
        var result = new List<int>();
        for (int i = 1; i <= nums.Length; i++)
        {
            if (occurrences[i] == 0)
            {
                result.Add(i);
            }
        }
        return result;
    }
}
*/
// v2
public class Solution
{
    public List<int> FindDisappearedNumbers(int[] nums)
    {
        for (int i = 0; i < nums.Length; i++)
        {
            if (nums[Math.Abs(nums[i]) - 1] > 0)
            {
                nums[Math.Abs(nums[i]) - 1] = -nums[Math.Abs(nums[i]) - 1];
            }
        }
        var result = new List<int>();
        for (int i = 1; i <= nums.Length; i++)
        {
            if (nums[i - 1] > 0)
            {
                result.Add(i);
            }
        }
        return result;
    }
}
