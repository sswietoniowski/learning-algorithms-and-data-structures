namespace neetcode.P0567_PermutationInString
{
    // https://leetcode.com/problems/permutation-in-string/
    // https://youtu.be/UbyhOgBN834
    public class Solution
    {
        public bool CheckInclusion(string s1, string s2)
        {
            if (s1.Length == 0 || s2.Length == 0 || s1.Length > s2.Length)
            {
                return false;
            }

            int[] s1Map = new int[26];
            int[] s2Map = new int[26];

            for (int i = 0; i < s1.Length; i++)
            {
                s1Map[s1[i] - 'a']++;
                s2Map[s2[i] - 'a']++;
            }

            int matches = 0;

            for (int i = 0; i < 26; i++)
            {
                if (s1Map[i] == s2Map[i])
                {
                    matches++;
                }
            }

            int left = 0;
            for (int right = s1.Length; right < s2.Length; right++)
            {
                if (matches == 26)
                {
                    return true;
                }

                int index = s2[right] - 'a';
                s2Map[index]++;
                if (s1Map[index] == s2Map[index])
                {
                    matches++;
                }
                else if (s1Map[index] + 1 == s2Map[index])
                {
                    matches--;
                }

                index = s2[left] - 'a';
                s2Map[index]--;
                if (s1Map[index] == s2Map[index])
                {
                    matches++;
                }
                else if (s1Map[index] - 1 == s2Map[index])
                {
                    matches--;
                }

                left++;
            }

            return matches == 26;
        }
    }
}
