namespace leetcode.P3296_MinimumNumberOfSeconds;

// https://leetcode.com/problems/minimum-number-of-seconds-to-make-mountain-height-zero/description/?envType=daily-question&envId=2026-03-13
public class Solution
{
    public long MinNumberOfSeconds(int mountainHeight, int[] workerTimes)
    {
        // Binary search range for the total time in seconds
        // Lower bound is 1, Upper bound is worst case (one slow worker)
        long left = 1;
        long right = (long)1e16; // Safely large enough for constraints
        long result = right;

        while (left <= right)
        {
            long mid = left + (right - left) / 2;

            if (CanReduce(mid, mountainHeight, workerTimes))
            {
                result = mid;
                right = mid - 1; // Try to find a smaller time
            }
            else
            {
                left = mid + 1; // Need more time
            }
        }

        return result;
    }

    private bool CanReduce(long maxTime, int targetHeight, int[] workerTimes)
    {
        long totalHeightReduced = 0;

        foreach (int w in workerTimes)
        {
            // Solve: w * x * (x + 1) / 2 <= maxTime
            // x^2 + x - (2 * maxTime / w) <= 0
            // Using Quadratic Formula: x = (-1 + sqrt(1 + 8 * maxTime / w)) / 2
            double val = (double)2 * maxTime / w;
            long x = (long)((-1 + Math.Sqrt(1 + 4 * val)) / 2);

            totalHeightReduced += x;

            // Optimization: If we already hit the target, no need to check other workers
            if (totalHeightReduced >= targetHeight)
            {
                return true;
            }
        }

        return totalHeightReduced >= targetHeight;
    }
}
