namespace neetcode.P0279_PerfectSquares;

// https://leetcode.com/problems/perfect-squares/description/
// https://neetcode.io/problems/perfect-squares/question?list=neetcode250
public class Solution
{
    public int NumSquares(int n)
    {
        // dp[i] will store the least number of perfect squares that sum to i
        int[] dp = new int[n + 1];

        // Initialize the DP table with a maximum possible value (n)
        // because the worst case is 1+1+1... (n times)
        Array.Fill(dp, n);

        // Base case: 0 requires 0 squares
        dp[0] = 0;

        // Iterate through all numbers from 1 to n
        for (int i = 1; i <= n; i++)
        {
            // Check all perfect squares j*j that are less than or equal to i
            for (int j = 1; j * j <= i; j++)
            {
                int square = j * j;
                // The recurrence relation:
                // Min squares for i is 1 (for the current square) + min squares for the remainder (i - square)
                dp[i] = Math.Min(dp[i], dp[i - square] + 1);
            }
        }

        return dp[n];
    }
}
