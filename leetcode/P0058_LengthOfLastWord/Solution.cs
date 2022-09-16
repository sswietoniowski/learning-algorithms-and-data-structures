using System.Text.RegularExpressions;

namespace leetcode.P0058_LengthOfLastWord;

public class Solution
{
    public int LengthOfLastWord(string s)
    {
        Regex re = new Regex(@"\s+");
        string[] words = re.Split(s);
        int i = words.Length - 1;
        for (; i >= 0; i--)
        {
            if (!string.IsNullOrEmpty(words[i]))
            {
                break;
            }
        }
        return words[i].Length;
    }
}