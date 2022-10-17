using System.Runtime.CompilerServices;

namespace neetcode.P0046_Permutations;

// https://leetcode.com/problems/permutations/
// https://youtu.be/s7AvT7cGdSo
public class Solution
{
    private void dfs(int[] nums, int start, IList<IList<int>> result)
    {
        if (start == nums.Length)
        {
            result.Add(new List<int>(nums));
            return;
        }

        for (int i = start; i < nums.Length; i++)
        {
            (nums[start], nums[i]) = (nums[i], nums[start]);
            dfs(nums, start + 1, result);
            (nums[start], nums[i]) = (nums[i], nums[start]);
        }
    }

    public IList<IList<int>> Permute(int[] nums)
    {
        var result = new List<IList<int>>();
        
        if (nums is { Length: 0 })
        {
            return result;
        }

        if (nums.Length == 1)
        {
            result.Add(new List<int>(nums));
            return result;
        }

        dfs(nums, 0, result);

        return result;
    }
}