namespace neetcode.P0070_ClimbingStairs;

public class Solution
{
    public int ClimbStairs(int n)
    {
        int one = 1;
        int two = 1;
        for (int i = 0; i < n - 1; i++)
        {
            (one, two) = (one + two, one);
        }
        return one;
    }
}