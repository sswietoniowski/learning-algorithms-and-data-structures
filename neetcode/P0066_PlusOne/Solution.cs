namespace neetcode.P0066_PlusOne;

public class Solution
{
    // https://leetcode.com/problems/plus-one/
    // https://youtu.be/jIaA8boiG1s
    public int[] PlusOne(int[] digits)
    {
        int[] result = new int[digits.Length];
        int i = digits.Length - 1;
        bool add = true;
        int digit = 0;
        while (i >= 0)
        {
            digit = digits[i] + (add ? 1 : 0);
            if (digit >= 10)
            {
                result[i] = digit % 10;
                add = true;
            }
            else
            {
                result[i] = digit;
                add = false;
            }
            i--;
        }
        if (add)
        {
            int[] newResult = new int[result.Length + 1];
            newResult[0] = 1;
            Array.Copy(result, 0, newResult, 1, result.Length);
            result = newResult;
        }
        return result;
    }
}