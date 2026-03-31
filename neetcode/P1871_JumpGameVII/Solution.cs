namespace neetcode.P1871_JumpGameVII;

// https://leetcode.com/problems/jump-game-vii/description/
// https://neetcode.io/problems/jump-game-vii/question?list=neetcode250
public class Solution
{
    public bool CanReach(string s, int minJump, int maxJump)
    {
        int n = s.Length;
        // dp[i] indicates if index i is reachable
        bool[] dp = new bool[n];
        dp[0] = true;

        // reachableCount tracks how many 'true' DP values are
        // in the current window [i - maxJump, i - minJump]
        int reachableCount = 0;

        for (int i = 1; i < n; i++)
        {
            // 1. Add the new potential source to the window
            // When we are at index i, the index (i - minJump)
            // just entered the valid range.
            if (i >= minJump)
            {
                if (dp[i - minJump])
                {
                    reachableCount++;
                }
            }

            // 2. Remove the old potential source from the window
            // When we are at index i, the index (i - maxJump - 1)
            // is now too far away to jump to i.
            if (i > maxJump)
            {
                if (dp[i - maxJump - 1])
                {
                    reachableCount--;
                }
            }

            // 3. Check if current index i is reachable
            // It's reachable if s[i] is '0' AND there's at least
            // one 'true' in our sliding window.
            if (s[i] == '0' && reachableCount > 0)
            {
                dp[i] = true;
            }
        }

        return dp[n - 1];
    }
}
