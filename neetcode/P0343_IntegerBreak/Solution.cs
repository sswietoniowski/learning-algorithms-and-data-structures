namespace neetcode.P0343_IntegerBreak;

// https://leetcode.com/problems/integer-break/description/
// https://neetcode.io/problems/integer-break/question
public class Solution
{
    public int IntegerBreak(int n)
    {
        // dp[i] will store the maximum product for integer i
        int[] dp = new int[n + 1];

        // Base cases
        dp[1] = 1;

        // Fill the dp table from 2 to n
        for (int i = 2; i <= n; i++)
        {
            // Try splitting i into j and (i - j)
            // We only need to go up to i/2 because of symmetry (2+3 is same as 3+2)
            for (int j = 1; j <= i / 2; j++)
            {
                /* For each split, we compare:
                   1. The current max in dp[i]
                   2. j * (i - j) -> splitting i into exactly two pieces
                   3. j * dp[i - j] -> splitting i into more than two pieces
                */
                int currentMax = Math.Max(j * (i - j), j * dp[i - j]);
                dp[i] = Math.Max(dp[i], currentMax);
            }
        }

        return dp[n];
    }
}
