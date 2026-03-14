namespace leetcode.P1415_TheKthLexicographicalString;

// https://leetcode.com/problems/the-k-th-lexicographical-string-of-all-happy-strings-of-length-n/description/?envType=daily-question&envId=2026-03-14
public class Solution
{
    private int _count = 0;
    private string _result = "";

    public string GetHappyString(int n, int k)
    {
        _count = 0;
        _result = "";

        Backtrack(n, k, new System.Text.StringBuilder());

        return _result;
    }

    private void Backtrack(int n, int k, System.Text.StringBuilder sb)
    {
        // Base case: If we found the result or reached length n
        if (_result != "" || sb.Length == n)
        {
            if (sb.Length == n)
            {
                _count++;
                if (_count == k)
                {
                    _result = sb.ToString();
                }
            }
            return;
        }

        // Try 'a', 'b', and 'c' in order to maintain lexicographical sorting
        foreach (char c in new char[] { 'a', 'b', 'c' })
        {
            // Check the "Happy" condition: current char != previous char
            if (sb.Length == 0 || sb[sb.Length - 1] != c)
            {
                sb.Append(c);
                Backtrack(n, k, sb);

                // If we found the k-th string during recursion, stop exploring
                if (_result != "")
                    return;

                // Standard backtracking step: remove the last char to try the next option
                sb.Remove(sb.Length - 1, 1);
            }
        }
    }
}
