namespace neetcode.P0039_CombinationSum;

// https://leetcode.com/problems/combination-sum/
// https://youtu.be/GBKI9VSKdGg
public class Solution
{
    private void dfs(int[] candidates, int target, int start, List<int> path, IList<IList<int>> result)
    {
        if (target == 0)
        {
            result.Add(new List<int>(path));
            return;
        }

        for (int i = start; i < candidates.Length; i++)
        {
            if (candidates[i] > target)
            {
                continue;
            }

            path.Add(candidates[i]);
            dfs(candidates, target - candidates[i], i, path, result);
            path.RemoveAt(path.Count - 1);
        }
    }

    public IList<IList<int>> CombinationSum(int[] candidates, int target)
    {
        var result = new List<IList<int>>();

        if (candidates == null || candidates.Length == 0)
        {
            return result;
        }

        Array.Sort(candidates);

        dfs(candidates, target, 0, new List<int>(), result);

        return result;
    }
}