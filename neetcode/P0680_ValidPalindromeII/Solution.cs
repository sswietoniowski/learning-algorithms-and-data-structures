namespace neetcode.P0680_ValidPalindromeII;

// https://leetcode.com/problems/valid-palindrome-ii/description/
// https://neetcode.io/problems/valid-palindrome-ii/question?list=neetcode250
// v1
public class Solution
{
    public bool ValidPalindrome(string s)
    {
        bool IsPalindrome(int l, int r)
        {
            while (l < r)
            {
                if (s[l] != s[r])
                    return false;
                l++;
                r--;
            }
            return true;
        }

        int left = 0,
            right = s.Length - 1;
        while (left < right)
        {
            if (s[left] != s[right])
            {
                return IsPalindrome(left + 1, right) || IsPalindrome(left, right - 1);
            }
            left++;
            right--;
        }

        return true;
    }
}
