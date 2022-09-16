namespace neetcode.P0049_GroupAnagrams;

public class Solution
{
    // https://leetcode.com/problems/group-anagrams/
    // https://youtu.be/vzdNOK2oB2E
    public IList<IList<string>> GroupAnagrams(string[] strs)
    {
        var result = new List<IList<string>>();
        var wordsSet = new HashSet<string>();
        var anagramsDictionary = new Dictionary<string, IList<string>>();

        foreach (var word in strs)
        {
            char[] chars = word.ToCharArray();
            Array.Sort(chars);
            var key = new String(chars);
            if (!wordsSet.Contains(key))
            {
                wordsSet.Add(key);
                anagramsDictionary[key] = new List<string>();
            }

            anagramsDictionary[key].Add(word);
        }

        foreach (var kvp in anagramsDictionary)
        {
            result.Add(kvp.Value);
        }

        return result;
    }
}