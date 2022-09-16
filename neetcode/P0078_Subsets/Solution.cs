namespace neetcode.P0078_Subsets;

// https://leetcode.com/problems/number-of-islands/
// https://youtu.be/pV2kpPD66nE
public class Solution
{
    private void dfs(int[] nums, IList<IList<int>> result, IList<int> subset, int i)
    {
        if (i >= nums.Length)
        {
            result.Add(new List<int>(subset));
            return;
        }

        subset.Add(nums[i]);
        dfs(nums, result, subset, i + 1);

        subset.Remove(nums[i]);
        dfs(nums, result, subset, i + 1);
    }

    public IList<IList<int>> Subsets(int[] nums)
    {
        IList<IList<int>> result = new List<IList<int>>();
        IList<int> subset = new List<int>();
        dfs(nums, result, subset, 0);
        return result;
    }
}