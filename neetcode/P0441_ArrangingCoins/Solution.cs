namespace neetcode.P0441_ArrangingCoins;

// https://leetcode.com/problems/arranging-coins/description/
// https://neetcode.io/problems/arranging-coins/question
public class Solution
{
    public int ArrangeCoins(int n)
    {
        int left = 1;
        int right = n;
        int rows = 0;
        while (left <= right)
        {
            int mid = left + (right - left) / 2;
            if (((long)mid * mid + mid) / 2 > (long)n)
            {
                right = mid - 1;
            }
            else
            {
                rows = mid;
                left = mid + 1;
            }
        }
        return rows;
    }
}
