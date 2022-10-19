namespace neetcode.P0090_SubsetsII;

// https://leetcode.com/problems/subsets-ii/
// https://youtu.be/Vn2v6ajA7U0
public class Solution
{
    private void Backtrack(int[] nums, IList<IList<int>> result, IList<int> subset, int i)
    {
        if (i == nums.Length)
        {
            result.Add(new List<int>(subset));
            return;
        }

        subset.Add(nums[i]);
        Backtrack(nums, result, subset, i + 1);

        subset.Remove(nums[i]);
        while (i + 1 < nums.Length && nums[i] == nums[i + 1])
        {
            i++;
        }
        Backtrack(nums, result, subset, i + 1);
    }
    
    public IList<IList<int>> SubsetsWithDup(int[] nums)
    {
        IList<IList<int>> result = new List<IList<int>>();
        Array.Sort(nums);
        IList<int> subset = new List<int>();
        Backtrack(nums, result, subset, 0);
        return result;
    }
}