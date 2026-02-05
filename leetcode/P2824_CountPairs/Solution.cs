namespace leetcode.P2824_CountPairs;

// https://leetcode.com/problems/count-pairs-whose-sum-is-less-than-target/description/
// v1
/*
public class Solution
{
    public int CountPairs(IList<int> nums, int target)
    {
        int count = 0;
        var array = nums.ToArray();
        for (int i = 0; i < array.Length - 1; i++)
        {
            for (int j = i + 1; j < array.Length; j++)
            {
                if (array[i] + array[j] < target)
                {
                    count++;
                }
            }
        }
        return count;
    }
}
*/
// v2
public class Solution
{
    public int CountPairs(IList<int> nums, int target)
    {
        List<int> sortedNums = nums.ToList();
        sortedNums.Sort();

        int count = 0;
        int left = 0;
        int right = sortedNums.Count - 1;

        while (left < right)
        {
            if (sortedNums[left] + sortedNums[right] < target)
            {
                count += (right - left);
                left++;
            }
            else
            {
                right--;
            }
        }

        return count;
    }
}
