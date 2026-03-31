namespace leetcode.P3474_LexicographicallySmallestGeneratedString;

// https://leetcode.com/problems/lexicographically-smallest-generated-string/description/?envType=daily-question&envId=2026-03-31
using System;
using System.Text;

public class Solution
{
    public string GenerateString(string str1, string str2)
    {
        int n = str1.Length;
        int m = str2.Length;
        int totalLen = n + m - 1;

        char[] res = new char[totalLen];
        bool[] fixedByT = new bool[totalLen];

        // 1. Process 'T' constraints: These are mandatory
        for (int i = 0; i < n; i++)
        {
            if (str1[i] == 'T')
            {
                for (int j = 0; j < m; j++)
                {
                    int idx = i + j;
                    // If this position was already set by another 'T' to a different char
                    if (fixedByT[idx] && res[idx] != str2[j])
                    {
                        return "";
                    }
                    res[idx] = str2[j];
                    fixedByT[idx] = true;
                }
            }
        }

        // 2. Fill non-fixed positions with 'a' for lexicographical minimality
        for (int i = 0; i < totalLen; i++)
        {
            if (!fixedByT[i])
            {
                res[i] = 'a';
            }
        }

        // 3. Process 'F' constraints: Break matches greedily
        for (int i = 0; i < n; i++)
        {
            if (str1[i] == 'F')
            {
                // Check if the current substring matches str2
                if (IsMatch(res, i, str2))
                {
                    bool fixedMatch = true;
                    // Try to change the rightmost non-fixed character in this window
                    for (int j = m - 1; j >= 0; j--)
                    {
                        int idx = i + j;
                        if (!fixedByT[idx])
                        {
                            // If it's currently 'a', changing to 'b' is usually the smallest change.
                            // However, if str2[j] is actually 'b', 'a' would have worked,
                            // but since it matches str2, res[idx] must be str2[j].
                            // We just need to pick a character != str2[j].
                            // 'a' is smallest, then 'b'.
                            res[idx] = (str2[j] == 'a') ? 'b' : 'a';
                            fixedMatch = false;
                            break;
                        }
                    }

                    // If all characters in the window were fixed by 'T' and it matches str2
                    if (fixedMatch)
                        return "";
                }
            }
            else
            {
                // Safety check: Ensure 'T' conditions are still met after 'F' modifications
                if (!IsMatch(res, i, str2))
                {
                    return "";
                }
            }
        }

        return new string(res);
    }

    private bool IsMatch(char[] word, int start, string str2)
    {
        for (int j = 0; j < str2.Length; j++)
        {
            if (word[start + j] != str2[j])
                return false;
        }
        return true;
    }
}
