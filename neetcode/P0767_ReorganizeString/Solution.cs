namespace neetcode.P0767_ReorganizeString;

// https://leetcode.com/problems/reorganize-string/description/
// https://neetcode.io/problems/partition-labels/question?list=neetcode150
public class Solution
{
    public string ReorganizeString(string s)
    {
        int n = s.Length;
        int[] counts = new int[26];

        // 1. Count frequencies and find the most frequent character
        int maxCount = 0;
        char maxChar = ' ';
        foreach (char c in s)
        {
            counts[c - 'a']++;
            if (counts[c - 'a'] > maxCount)
            {
                maxCount = counts[c - 'a'];
                maxChar = c;
            }
        }

        // 2. Check if it's impossible
        // If the most frequent char appears more than half the length (rounded up), fail.
        if (maxCount > (n + 1) / 2)
        {
            return "";
        }

        char[] result = new char[n];
        int index = 0;

        // 3. Place the most frequent character first at even indices (0, 2, 4...)
        while (counts[maxChar - 'a'] > 0)
        {
            result[index] = maxChar;
            index += 2;
            counts[maxChar - 'a']--;
        }

        // 4. Fill the rest of the characters
        for (int i = 0; i < 26; i++)
        {
            while (counts[i] > 0)
            {
                // If we go past the end of the array, start filling odd indices (1, 3, 5...)
                if (index >= n)
                {
                    index = 1;
                }
                result[index] = (char)(i + 'a');
                index += 2;
                counts[i]--;
            }
        }

        return new string(result);
    }
}
