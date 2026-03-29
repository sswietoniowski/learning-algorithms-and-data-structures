namespace leetcode.P2839_CheckIfStringsCanBeMadeEqualWithOperationsI;

// https://leetcode.com/problems/check-if-strings-can-be-made-equal-with-operations-i/description/?envType=daily-question&envId=2026-03-29
public class Solution
{
    public bool CanBeEqual(string s1, string s2)
    {
        // Check if the characters at even indices (0 and 2) are the same in both strings
        bool evenIndicesMatch =
            (s1[0] == s2[0] && s1[2] == s2[2]) || (s1[0] == s2[2] && s1[2] == s2[0]);

        // Check if the characters at odd indices (1 and 3) are the same in both strings
        bool oddIndicesMatch =
            (s1[1] == s2[1] && s1[3] == s2[3]) || (s1[1] == s2[3] && s1[3] == s2[1]);

        // Both sets must match for the strings to be transformable
        return evenIndicesMatch && oddIndicesMatch;
    }
}
