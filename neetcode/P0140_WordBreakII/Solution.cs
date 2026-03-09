namespace neetcode.P0140_WordBreakII;

using System.Collections.Generic;

// https://neetcode.io/problems/word-break-ii/question?list=neetcode250
// https://leetcode.com/problems/word-break-ii/description/
public class Solution
{
    // Memoization dictionary to store results for substrings we've already solved
    private Dictionary<string, List<string>> _memo = new Dictionary<string, List<string>>();

    public IList<string> WordBreak(string s, IList<string> wordDict)
    {
        // Convert list to HashSet for O(1) lookups
        HashSet<string> wordSet = new HashSet<string>(wordDict);
        return Solve(s, wordSet);
    }

    private List<string> Solve(string s, HashSet<string> wordSet)
    {
        // Base case: If we've already computed this substring, return it
        if (_memo.ContainsKey(s))
        {
            return _memo[s];
        }

        // Base case: If the string is empty, return a list containing an empty string
        // This helps us build the sentences as we bubble back up the recursion
        if (string.IsNullOrEmpty(s))
        {
            return new List<string> { "" };
        }

        List<string> result = new List<string>();

        // Try every possible prefix length
        for (int i = 1; i <= s.Length; i++)
        {
            string prefix = s.Substring(0, i);

            if (wordSet.Contains(prefix))
            {
                // Recursively get all valid sentences for the remaining suffix
                string suffix = s.Substring(i);
                List<string> suffixWays = Solve(suffix, wordSet);

                // Combine the current prefix with every sentence found in the suffix
                foreach (string way in suffixWays)
                {
                    string joined = string.IsNullOrEmpty(way) ? prefix : prefix + " " + way;
                    result.Add(joined);
                }
            }
        }

        // Save result to memo before returning
        _memo[s] = result;
        return result;
    }
}
