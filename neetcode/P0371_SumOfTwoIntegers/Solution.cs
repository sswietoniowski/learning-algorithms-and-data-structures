namespace neetcode.P0371_SumOfTwoIntegers
{
    // https://leetcode.com/problems/sum-of-two-integers/
    // https://youtu.be/gVUrDV4tZfY
    public class Solution
    {
        public int GetSum(int a, int b)
        {
            int sum = a;
            int carry = 1;
            while (carry != 0)
            {
                sum = a ^ b;
                carry = (a & b) << 1;
                a = sum;
                b = carry;
            }
            return sum;
        }
    }
}
