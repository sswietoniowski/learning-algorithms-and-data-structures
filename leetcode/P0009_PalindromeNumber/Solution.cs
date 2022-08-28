namespace leetcode.P0009_PalindromeNumber
{
    public class Solution
    {
        // v1
        //public bool IsPalindrome(string s)
        //{
        //    for (int i = 0; i < s.Length / 2; i++)
        //    {
        //        if (s[i] != s[s.Length - 1 - i])
        //        {
        //            return false;
        //        }
        //    }

        //    return true;
        //}

        //public bool IsPalindrome(int x)
        //{
        //    return IsPalindrome(x.ToString());
        //}

        // v2
        public bool IsPalindrome(int x)
        {
            if (x < 0 || (x % 10 == 0 && x != 0))
            {
                return false;
            }

            int revertedNumber = 0;
            while (x > revertedNumber)
            {
                revertedNumber = revertedNumber * 10 + x % 10;
                x /= 10;
            }

            return x == revertedNumber || x == revertedNumber / 10;
        }
    }
}
