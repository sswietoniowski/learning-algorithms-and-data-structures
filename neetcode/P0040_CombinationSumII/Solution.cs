namespace neetcode.P0040_CombinationSumII;

// https://leetcode.com/problems/combination-sum-ii/
// https://youtu.be/rSA3t6BDDwg
public class Solution
{
    private void Backtrack(
        int[] candidates,
        int target,
        int start,
        List<int> path,
        IList<IList<int>> result
    )
    {
        if (target == 0)
        {
            result.Add(new List<int>(path));
            return;
        }

        if (target < 0)
        {
            return;
        }

        var previous = -1;
        for (var i = start; i < candidates.Length; i++)
        {
            if (previous != -1 && candidates[previous] == candidates[i])
            {
                continue;
            }

            path.Add(candidates[i]);
            Backtrack(candidates, target - candidates[i], i + 1, path, result);
            path.RemoveAt(path.Count - 1);

            previous = i;
        }
    }

    public IList<IList<int>> CombinationSum2(int[] candidates, int target)
    {
        var result = new List<IList<int>>();

        if (candidates == null || candidates.Length == 0)
        {
            return result;
        }

        Array.Sort(candidates);

        Backtrack(candidates, target, 0, new List<int>(), result);

        return result;
    }
}
