namespace neetcode.P0003_LongestSubstringWithoutRepeatingCharacters
{
    public class Solution
    {
        public int LengthOfLongestSubstring(string s)
        {
            int longestIndex = 0;
            int longestLength = 0;

            int currentIndex = 0;
            int currentLength = 0;
            HashSet<char> currentCharacters = new();

            for (int i = 0; i < s.Length; i++)
            {
                if (!currentCharacters.Contains(s[i]))
                {
                    currentCharacters.Add(s[i]);
                    currentLength++;
                }
                else
                {
                    if (currentLength > longestLength)
                    {
                        longestIndex = currentIndex;
                        longestLength = currentLength;
                    }

                    currentIndex = i;
                    currentLength = 1;
                    currentCharacters.Clear();
                    currentCharacters.Add(s[i]);
                    while (currentIndex - 1 >= 0 && !currentCharacters.Contains(s[currentIndex - 1]))
                    {
                        currentIndex--;
                        currentLength++;
                        currentCharacters.Add(s[currentIndex]);
                    }
                }
            }

            if (currentLength > longestLength)
            {
                longestIndex = currentIndex;
                longestLength = currentLength;
            }

            return longestLength;
        }
    }
}
