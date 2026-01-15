using System.Text;

namespace neetcode.P0249_GroupShiftedStrings;

// https://leetcode.com/problems/group-shifted-strings
// https://neetcode.io/problems/group-shifted-strings/question
public class Solution
{
    private string GetHash(string s)
    {
        var hashKey = new StringBuilder();
        for (int i = 1; i < s.Length; i++)
        {
            hashKey.Append((char)((s[i] - s[i - 1] + 26) % 26 + 'a'));
        }
        return hashKey.ToString();
    }

    public IList<IList<string>> GroupStrings(string[] strings)
    {
        var mapHashToList = new Dictionary<string, IList<string>>();

        // Create a hash_value (hashKey) for each string and append the string
        // to the list of hash values i.e. mapHashToList["cd"] = ["acf", "gil", "xzc"]
        foreach (var str in strings)
        {
            var hashKey = GetHash(str);
            if (!mapHashToList.ContainsKey(hashKey))
            {
                mapHashToList[hashKey] = new List<string>();
            }
            mapHashToList[hashKey].Add(str);
        }

        // Return a list of all of the grouped strings
        return mapHashToList.Values.ToList<IList<string>>();
    }
}
