namespace leetcode.P0009_PalindromeNumber
{
    public class Solution
    {
        public bool IsPalindrome(string s)
        {
            for (int i = 0; i < s.Length / 2; i++)
            {
                if (s[i] != s[s.Length - 1 - i])
                {
                    return false;
                }
            }

            return true;
        }

        public bool IsPalindrome(int x)
        {
            return IsPalindrome(x.ToString());
        }
    }
}
