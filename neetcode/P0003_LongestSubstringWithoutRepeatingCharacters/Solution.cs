namespace neetcode.P0003_LongestSubstringWithoutRepeatingCharacters;

// https://leetcode.com/problems/longest-substring-without-repeating-characters/
// https://youtu.be/wiGpQwVHdE0
public class Solution
{
    public int LengthOfLongestSubstring(string s)
    {
        HashSet<char> characters = new();
        int left = 0;
        int length = 0;
            
        for (int right = 0; right < s.Length; right++)
        {
            while (characters.Contains(s[right]))
            {
                characters.Remove(s[left]);
                left++;
            }

            characters.Add(s[right]);
            length = Math.Max(length, right - left + 1);
        }

        return length;
    }
}