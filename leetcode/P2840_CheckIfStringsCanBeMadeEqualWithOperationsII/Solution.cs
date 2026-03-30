namespace leetcode.P2840_CheckIfStringsCanBeMadeEqualWithOperationsII;

// https://leetcode.com/problems/check-if-strings-can-be-made-equal-with-operations-ii/description/?envType=daily-question&envId=2026-03-30
public class Solution
{
    public bool CheckStrings(string s1, string s2)
    {
        int n = s1.Length;

        // Frequency arrays for 'a' through 'z' (26 letters)
        int[] evenCounts = new int[26];
        int[] oddCounts = new int[26];

        for (int i = 0; i < n; i++)
        {
            if (i % 2 == 0)
            {
                // For even indices: increment for s1, decrement for s2
                evenCounts[s1[i] - 'a']++;
                evenCounts[s2[i] - 'a']--;
            }
            else
            {
                // For odd indices: increment for s1, decrement for s2
                oddCounts[s1[i] - 'a']++;
                oddCounts[s2[i] - 'a']--;
            }
        }

        // If the strings can be made equal, all frequency counts must be zero
        for (int i = 0; i < 26; i++)
        {
            if (evenCounts[i] != 0 || oddCounts[i] != 0)
            {
                return false;
            }
        }

        return true;
    }
}
