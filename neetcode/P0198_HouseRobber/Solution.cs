namespace neetcode.P0198_HouseRobber;

public class Solution
{
    // https://leetcode.com/problems/house-robber/description/
    // https://neetcode.io/problems/house-robber/question?list=blind75
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
