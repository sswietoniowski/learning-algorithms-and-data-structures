namespace leetcode.P3661_MaximumWallsDestroyedByRobots;

// https://leetcode.com/problems/maximum-walls-destroyed-by-robots/description/?envType=daily-question&envId=2026-04-03
public class Solution
{
    public int MaxWalls(int[] robots, int[] distance, int[] walls)
    {
        int n = robots.Length;

        // 1. Pair robots with distances and sort them by position
        var botPairs = new (int pos, int dist)[n];
        for (int i = 0; i < n; i++)
        {
            botPairs[i] = (robots[i], distance[i]);
        }
        Array.Sort(botPairs, (a, b) => a.pos.CompareTo(b.pos));

        // 2. Sort walls for binary search
        Array.Sort(walls);

        // DP Table
        // dp[i][0]: robot i fires left
        // dp[i][1]: robot i fires right
        long[,] dp = new long[n, 2];

        // Base case: Robot 0
        // Left: covers [pos - dist, pos]
        dp[0, 0] = CountWalls(walls, botPairs[0].pos - botPairs[0].dist, botPairs[0].pos);
        // Right: covers nothing yet (will be added in the gap to Robot 1)
        dp[0, 1] = 0;

        for (int i = 1; i < n; i++)
        {
            int prevPos = botPairs[i - 1].pos;
            int currPos = botPairs[i].pos;
            int prevDist = botPairs[i - 1].dist;
            int currDist = botPairs[i].dist;

            // Transition for dp[i, 0] (Current robot fires Left)
            // Case A: Previous fired Left. Current hits walls in [max(prevPos, currPos - currDist), currPos]
            long fromLeftToLeft =
                dp[i - 1, 0] + CountWalls(walls, Math.Max(prevPos, currPos - currDist), currPos);

            // Case B: Previous fired Right. They might overlap in the gap.
            // We calculate the union of [prevPos, prevPos + prevDist] and [currPos - currDist, currPos]
            // restricted within the gap [prevPos, currPos].
            long fromRightToLeft =
                dp[i - 1, 1]
                + CountUnionWalls(
                    walls,
                    prevPos,
                    prevPos + prevDist,
                    currPos - currDist,
                    currPos,
                    prevPos,
                    currPos
                );

            dp[i, 0] = Math.Max(fromLeftToLeft, fromRightToLeft);

            // Transition for dp[i, 1] (Current robot fires Right)
            // Case A: Previous fired Left. No walls destroyed in this gap.
            long fromLeftToRight = dp[i - 1, 0];

            // Case B: Previous fired Right. Previous destroys walls in [prevPos, min(currPos, prevPos + prevDist)]
            long fromRightToRight =
                dp[i - 1, 1] + CountWalls(walls, prevPos, Math.Min(currPos, prevPos + prevDist));

            dp[i, 1] = Math.Max(fromLeftToRight, fromRightToRight);
        }

        // Final step: If the last robot fired right, add its contribution to the infinite right gap
        long lastRightShot = CountWalls(
            walls,
            botPairs[n - 1].pos,
            botPairs[n - 1].pos + botPairs[n - 1].dist
        );

        return (int)Math.Max(dp[n - 1, 0], dp[n - 1, 1] + lastRightShot);
    }

    // Binary search to count walls in [L, R]
    private int CountWalls(int[] walls, int L, int R)
    {
        if (L > R)
            return 0;
        int start = LowerBound(walls, L);
        int end = UpperBound(walls, R);
        return Math.Max(0, end - start + 1);
    }

    // Helper for Union of two ranges within a gap
    private int CountUnionWalls(int[] walls, int r1L, int r1R, int r2L, int r2R, int gapL, int gapR)
    {
        // Clamp ranges to the gap
        int s1 = Math.Max(r1L, gapL),
            e1 = Math.Min(r1R, gapR);
        int s2 = Math.Max(r2L, gapL),
            e2 = Math.Min(r2R, gapR);

        // If ranges overlap or touch, merge them
        if (Math.Max(s1, s2) <= Math.Min(e1, e2))
        {
            return CountWalls(walls, Math.Min(s1, s2), Math.Max(e1, e2));
        }
        // Otherwise, count them separately
        return CountWalls(walls, s1, e1) + CountWalls(walls, s2, e2);
    }

    private int LowerBound(int[] arr, int target)
    {
        int low = 0,
            high = arr.Length - 1;
        int ans = arr.Length;
        while (low <= high)
        {
            int mid = low + (high - low) / 2;
            if (arr[mid] >= target)
            {
                ans = mid;
                high = mid - 1;
            }
            else
                low = mid + 1;
        }
        return ans;
    }

    private int UpperBound(int[] arr, int target)
    {
        int low = 0,
            high = arr.Length - 1;
        int ans = -1;
        while (low <= high)
        {
            int mid = low + (high - low) / 2;
            if (arr[mid] <= target)
            {
                ans = mid;
                low = mid + 1;
            }
            else
                high = mid - 1;
        }
        return ans;
    }
}
