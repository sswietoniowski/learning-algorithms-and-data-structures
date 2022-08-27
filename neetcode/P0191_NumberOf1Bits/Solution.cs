namespace neetcode.P0191_NumberOf1Bits
{
    public class Solution
    {
        // https://leetcode.com/problems/number-of-1-bits/
        // https://youtu.be/5Km3utixwZs
        public int HammingWeight(uint n)
        {
            // v1
            //int counter = 0;
            //for (int i = 0; i < 32; i++)
            //{
            //    if ((n & (1 << i)) != 0)
            //    {
            //        counter++;
            //    }
            //}
            //return counter;
            // v2
            int counter = 0;
            int mask = 1;
            for (int i = 0; i < 32; i++)
            {
                if ((n & mask) != 0)
                {
                    counter++;
                }

                mask <<= 1;
            }

            return counter;
        }
    }
}
