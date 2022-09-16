namespace neetcode.P0202_HappyNumber;

public class Solution
{
    private int SumDigitsSquares(int n)
    {
        int result = 0;
        while (n > 0)
        {
            int digit = n % 10;
            result += digit * digit;
            n /= 10;
        }
        return result;
    }


    // https://leetcode.com/problems/happy-number/
    // https://youtu.be/ljz85bxOYJ0
    public bool IsHappy(int n)
    {
        var testedNumbers = new HashSet<int>();

        while (n != 1)
        {
            n = SumDigitsSquares(n);
            if (testedNumbers.Contains(n))
            {
                return false;
            }
            testedNumbers.Add(n);
        }

        return true;
    }
}