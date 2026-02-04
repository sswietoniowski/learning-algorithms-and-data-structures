namespace neetcode.P0374_GuessNumberHigherOrLower;

// https://leetcode.com/problems/guess-number-higher-or-lower/description/
// https://neetcode.io/problems/guess-number-higher-or-lower/question
/**
 * Forward declaration of guess API.
 * @param  num   your guess
 * @return 	     -1 if num is higher than the picked number
 *			      1 if num is lower than the picked number
 *               otherwise return 0
 * int guess(int num);
 */
// v1
/*
public class Solution : GuessGame {
    public int GuessNumber(int n) {
        int left = 1;
        int right = n;

        while (left <= right)
        {
            int mid = left + (right - left) / 2;
            int result = guess(mid);
            if (result == 0)
            {
                return mid;
            }
            else if (result == -1)
            {
                right = mid - 1;
            } else
            {
                left = mid + 1;
            }
        }

        return -1;
    }
}
*/
