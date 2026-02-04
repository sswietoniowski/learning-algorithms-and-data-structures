namespace neetcode.P0367_ValidPerfectSquare;

// https://leetcode.com/problems/valid-perfect-square/description/
// https://neetcode.io/problems/valid-perfect-square/question
// v1
public class Solution
{
    public bool IsPerfectSquare(int num)
    {
        if (num < 2)
            return true;

        int left = 1;
        int right = num / 2;

        while (left <= right)
        {
            int mid = left + (right - left) / 2;
            long result = (long)mid * mid;
            if (result == num)
            {
                return true;
            }
            else if (result < num)
            {
                left = mid + 1;
            }
            else
            {
                right = mid - 1;
            }
        }

        return false;
    }
}
