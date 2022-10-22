namespace neetcode.P0131_PalindromePartitioning;

// https://leetcode.com/problems/palindrome-partitioning/
// https://youtu.be/3jvWodd7ht0
public class Solution
{
    private bool IsPalindrome(string s)
    {
        int i = 0;
        int j = s.Length - 1;
        while (i < j)
        {
            if (s[i] != s[j])
            {
                return false;
            }

            i++;
            j--;
        }

        return true;
    }

    public IList<IList<string>> Partition(string s)
    {
        var result = new List<IList<string>>();

        if (string.IsNullOrEmpty(s))
        {
            return result;
        }

        var current = new List<string>();

        void Backtrack(int index)
        {
            if (index == s.Length)
            {
                result.Add(new List<string>(current));
                return;
            }

            for (var i = index; i < s.Length; i++)
            {
                var substring = s.Substring(index, i - index + 1);

                if (!IsPalindrome(substring))
                {
                    continue;
                }

                current.Add(substring);
                Backtrack(i + 1);
                current.RemoveAt(current.Count - 1);
            }
        }

        Backtrack(0);

        return result;
    }
}