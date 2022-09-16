using System.Text;

namespace neetcode.P0125_ValidPalindrome;

public class Solution
{
    private string StripExtraCharacters(string s)
    {
        // v1
        //StringBuilder sb = new();

        //foreach (var ch in s.ToLower())
        //{
        //    if ((ch >= 'a' && ch <= 'z') || (ch >= '0' && ch <= '9'))
        //    {
        //        sb.Append(ch);
        //    }
        //}

        //return sb.ToString();

        StringBuilder sb = new();

        foreach (var ch in s.ToLower())
        {
            if (Char.IsLetterOrDigit(ch))
            {
                sb.Append(ch);
            }
        }

        return sb.ToString();
    }

    // https://leetcode.com/problems/valid-palindrome/
    // https://youtu.be/jJXJ16kPFWg
    public bool IsPalindrome(string s)
    {
        var cleanedString = StripExtraCharacters(s);
        var length = cleanedString.Length;

        for (int i = 0; i < length / 2; i++)
        {
            if (cleanedString[i] != cleanedString[length - i - 1])
            {
                return false;
            }
        }

        return true;
    }
}