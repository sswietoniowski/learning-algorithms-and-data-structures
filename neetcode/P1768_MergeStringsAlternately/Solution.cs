using System.Text;

namespace neetcode.P1768_MergeStringsAlternately;

// https://leetcode.com/problems/merge-strings-alternately/description/
// https://neetcode.io/problems/merge-strings-alternately/question
// v1
/*
public class Solution
{
    public string MergeAlternately(string word1, string word2)
    {
        var result = new StringBuilder(word1.Length + word2.Length);
        int index1 = 0;
        int index2 = 0;
        while (index1 < word1.Length || index2 < word2.Length)
        {
            if (index1 < word1.Length)
            {
                result.Append(word1[index1]);
                index1++;
            }

            if (index2 < word2.Length)
            {
                result.Append(word2[index2]);
                index2++;
            }
        }
        return result.ToString();
    }
}
*/
// v2
public class Solution
{
    public string MergeAlternately(string word1, string word2)
    {
        int n = word1.Length;
        int m = word2.Length;
        int minLength = Math.Min(n, m);
        var result = new StringBuilder(n + m);

        for (int i = 0; i < minLength; i++)
        {
            result.Append(word1[i]);
            result.Append(word2[i]);
        }

        if (n > m)
        {
            result.Append(word1.AsSpan(minLength));
        }
        else if (m > n)
        {
            result.Append(word2.AsSpan(minLength));
        }

        return result.ToString();
    }
}
