namespace neetcode.P0007_ReverseInteger
{
    // https://leetcode.com/problems/reverse-integer/
    // https://youtu.be/HAgLH58IgJQ
    public class Solution
    {
        public int Reverse(int x)
        {
            int result = 0;
            int power = 1;
            int sign = (x < 0 ? -1 : 1);
            try
            {
                checked
                {
                    foreach (var c in Math.Abs(x).ToString())
                    {
                        result += sign * (c - '0') * power;
                        unchecked
                        {
                            power *= 10;
                        }
                    }
                }
            }
            catch (OverflowException e)
            {
                result = 0;
            }
            return result;
        }
    }
}
