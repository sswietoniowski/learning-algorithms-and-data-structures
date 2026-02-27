namespace neetcode.P0077_Combinations;

// https://leetcode.com/problems/combinations/description/
// https://neetcode.io/problems/combinations/question
public class Solution
{
    public IList<IList<int>> Combine(int n, int k)
    {
        var combinations = new List<IList<int>>();

        void Backtrack(int i, List<int> combination)
        {
            if (i > n)
            {
                if (combination.Count == k)
                {
                    combinations.Add([.. combination]);
                }
                return;
            }

            combination.Add(i);
            Backtrack(i + 1, combination);
            combination.RemoveAt(combination.Count - 1);
            Backtrack(i + 1, combination);
        }

        Backtrack(1, new List<int>());

        return combinations;
    }
}
