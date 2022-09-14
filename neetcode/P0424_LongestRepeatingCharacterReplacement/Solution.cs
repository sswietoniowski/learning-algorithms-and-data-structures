namespace neetcode.P0424_LongestRepeatingCharacterReplacement
{
    // https://leetcode.com/problems/longest-repeating-character-replacement/
    // https://youtu.be/gqXU1UyA8pk
    public class Solution
    {
        public int CharacterReplacement(string s, int k)
        {
            int result = 0;

            int left = 0;

            int[] charCount = new int[26];

            for (int right = 0; right < s.Length; right++)
            {
                charCount[s[right] - 'A']++;

                while (right - left + 1 - charCount.Max() > k)
                {
                    charCount[s[left] - 'A']--;
                    left++;
                }

                result = Math.Max(result, right - left + 1);
            }

            return result;
        }
    }
}
