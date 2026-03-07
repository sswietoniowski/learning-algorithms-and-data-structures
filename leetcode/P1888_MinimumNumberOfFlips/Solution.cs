namespace leetcode.P1888_MinimumNumberOfFlips;

// https://leetcode.com/problems/minimum-number-of-flips-to-make-the-binary-string-alternating/description/?envType=daily-question&envId=2026-03-07
public class Solution
{
    public int MinFlips(string s)
    {
        int n = s.Length;
        string doubleS = s + s;

        // Count differences for the two alternating patterns
        // Pattern 1: 010101...
        // Pattern 2: 101010...
        int diff1 = 0,
            diff2 = 0;
        int minFlips = int.MaxValue;

        for (int i = 0; i < doubleS.Length; i++)
        {
            // Check Pattern 1 (Expected: i % 2)
            if (doubleS[i] - '0' != (i % 2))
                diff1++;

            // Check Pattern 2 (Expected: (i + 1) % 2)
            if (doubleS[i] - '0' != ((i + 1) % 2))
                diff2++;

            // Once the window reaches size n, start tracking the minimum
            if (i >= n)
            {
                // Remove the element that just left the window (at index i - n)
                if (doubleS[i - n] - '0' != ((i - n) % 2))
                    diff1--;
                if (doubleS[i - n] - '0' != ((i - n + 1) % 2))
                    diff2--;
            }

            // Only update minFlips when we have a full window of size n
            if (i >= n - 1)
            {
                minFlips = Math.Min(minFlips, Math.Min(diff1, diff2));
            }
        }

        return minFlips;
    }
}
