namespace neetcode.P0605_CanPlaceFlowers;

// https://leetcode.com/problems/can-place-flowers/description/
public class Solution
{
    public bool CanPlaceFlowers(int[] flowerbed, int n)
    {
        int empty = flowerbed[0] == 0 ? 1 : 0;

        foreach (int f in flowerbed)
        {
            if (f == 1)
            {
                n -= (empty - 1) / 2;
                empty = 0;
            }
            else
            {
                empty++;
            }
        }

        n -= empty / 2;
        return n <= 0;
    }
}
