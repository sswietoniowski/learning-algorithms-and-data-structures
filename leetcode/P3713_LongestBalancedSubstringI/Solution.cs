namespace leetcode.P3713_LongestBalancedSubstringI;

// https://leetcode.com/problems/longest-balanced-substring-i/submissions/1916685170/?envType=daily-question&envId=2026-02-12
public class Solution
{
    public int LongestBalanced(string s)
    {
        int maxLength = 0;
        for (int i = 0; i < s.Length; i++)
        {
            int[] frequencies = new int[26];
            for (int j = i; j < s.Length; j++)
            {
                frequencies[s[j] - 'a']++;
                bool isBalanced = true;
                int targetFreq = 0;

                for (int k = 0; k < 26; k++)
                {
                    if (frequencies[k] > 0)
                    {
                        if (targetFreq == 0)
                        {
                            targetFreq = frequencies[k];
                        }
                        else if (frequencies[k] != targetFreq)
                        {
                            isBalanced = false;
                            break;
                        }
                    }
                }
                if (isBalanced)
                {
                    maxLength = Math.Max(j - i + 1, maxLength);
                }
            }
        }
        return maxLength;
    }
}
