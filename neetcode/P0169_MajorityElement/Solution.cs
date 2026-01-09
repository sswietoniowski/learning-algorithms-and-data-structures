namespace neetcode.P0169_MajorityElement;

// https://leetcode.com/problems/majority-element/description/
// https://neetcode.io/problems/majority-element/question

// v1: Hash Map
/*
public class Solution
{
    public int MajorityElement(int[] nums)
    {
        Dictionary<int, int> histogram = new();
        int element = 0;
        int majority = 0;
        for (int i = 0; i < nums.Length; i++)
        {
            var key = nums[i];
            var value = 1;
            if (histogram.ContainsKey(key))
            {
                value += histogram[key];
            }
            histogram[key] = value;
            if (value > majority)
            {
                element = key;
                majority = value;
            }
        }
        return element;
    }
}
*/
// v2: Boyer-Moore Voting Algorithm
public class Solution
{
    public int MajorityElement(int[] nums)
    {
        int res = 0,
            count = 0;

        foreach (int num in nums)
        {
            if (count == 0)
            {
                res = num;
            }
            count += (num == res) ? 1 : -1;
        }

        return res;
    }
}
