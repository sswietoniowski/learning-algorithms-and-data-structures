namespace neetcode.P0290_WordPattern;

// https://leetcode.com/problems/word-pattern/description/
// https://neetcode.io/problems/word-pattern/question?list=allNC
public class Solution
{
    public bool WordPattern(string pattern, string s)
    {
        string[] words = s.Split(' ');

        if (pattern.Length != words.Length)
        {
            return false;
        }

        Dictionary<char, string> charToWord = new Dictionary<char, string>();
        Dictionary<string, char> wordToChar = new Dictionary<string, char>();

        for (int i = 0; i < pattern.Length; i++)
        {
            char c = pattern[i];
            string w = words[i];

            if (charToWord.ContainsKey(c))
            {
                if (charToWord[c] != w)
                {
                    return false;
                }
            }
            else
            {
                if (wordToChar.ContainsKey(w))
                {
                    return false;
                }

                charToWord.Add(c, w);
                wordToChar.Add(w, c);
            }
        }

        return true;
    }
}
