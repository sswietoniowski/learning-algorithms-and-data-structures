namespace neetcode.P1408_StringMatchingInAnArray;

// https://leetcode.com/problems/string-matching-in-an-array/description/
// https://neetcode.io/problems/string-matching-in-an-array/question?list=allNC
public class Solution
{
    public List<string> StringMatching(string[] words)
    {
        HashSet<string> substrings = new();
        for (int i = 0; i < words.Length; i++)
        {
            for (int j = 0; j < words.Length && i != j; j++)
            {
                if (words[i].Contains(words[j]))
                {
                    substrings.Add(words[j]);
                }
                else if (words[j].Contains(words[i]))
                {
                    substrings.Add(words[i]);
                }
            }
        }
        return substrings.ToList();
    }
}
