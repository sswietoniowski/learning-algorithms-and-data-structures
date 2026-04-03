namespace leetcode.P3661_MaximumWallsDestroyedByRobots;

// https://leetcode.com/problems/maximum-walls-destroyed-by-robots/description/?envType=daily-question&envId=2026-04-03
public class Solution
{
    public int MaxWalls(int[] robots, int[] distance, int[] walls)
    {
        int n = robots.Length;
        var botPairs = new (int pos, int dist)[n];
        for (int i = 0; i < n; i++)
            botPairs[i] = (robots[i], distance[i]);

        // Sort robots by position
        Array.Sort(botPairs, (a, b) => a.pos.CompareTo(b.pos));
        // Sort walls for binary search
        Array.Sort(walls);

        // 1. Separate walls into Fixed (on robots) and Dynamic (between robots)
        HashSet<int> robotPosSet = new HashSet<int>(robots);
        List<int> dynamicWallsList = new List<int>();
        int fixedWallsCount = 0;
        foreach (int w in walls)
        {
            if (robotPosSet.Contains(w))
                fixedWallsCount++;
            else
                dynamicWallsList.Add(w);
        }
        int[] dWalls = dynamicWallsList.ToArray();

        // 2. DP for walls in gaps (open intervals)
        // dp[i, 0] = max dynamic walls in gaps up to R_i, where R_i fires Left
        // dp[i, 1] = max dynamic walls in gaps up to R_i, where R_i fires Right
        long[,] dp = new long[n, 2];

        // Base Case: Gap 0 (-infinity to R_0)
        // If R0 fires Left, it hits dynamic walls in [R0 - dist, R0 - 1]
        dp[0, 0] = CountWalls(dWalls, botPairs[0].pos - botPairs[0].dist, botPairs[0].pos - 1);
        dp[0, 1] = 0;

        for (int i = 1; i < n; i++)
        {
            int rPrev = botPairs[i - 1].pos;
            int dPrev = botPairs[i - 1].dist;
            int rCurr = botPairs[i].pos;
            int dCurr = botPairs[i].dist;

            // Transition for dp[i, 0] (Current robot i fires Left)
            // It can hit walls in (rPrev, rCurr) in range [rCurr - dCurr, rCurr - 1]
            long wallsFromCurrLeft = CountWalls(
                dWalls,
                Math.Max(rPrev + 1, rCurr - dCurr),
                rCurr - 1
            );

            // If prev fired Left, only current's left shot hits walls in this gap
            long fromLeftToLeft = dp[i - 1, 0] + wallsFromCurrLeft;

            // If prev fired Right, we need the union of prev-Right and curr-Left in (rPrev, rCurr)
            long unionRange = CountUnion(
                dWalls,
                rPrev + 1,
                Math.Min(rCurr - 1, rPrev + dPrev), // Prev Right
                Math.Max(rPrev + 1, rCurr - dCurr),
                rCurr - 1 // Curr Left
            );
            long fromRightToLeft = dp[i - 1, 1] + unionRange;

            dp[i, 0] = Math.Max(fromLeftToLeft, fromRightToLeft);

            // Transition for dp[i, 1] (Current robot i fires Right)
            // Robot i doesn't hit anything in (rPrev, rCurr) because it fires Right
            long fromLeftToRight = dp[i - 1, 0];

            // If prev fired Right, it hits walls in [rPrev + 1, min(rCurr - 1, rPrev + dPrev)]
            long wallsFromPrevRight = CountWalls(
                dWalls,
                rPrev + 1,
                Math.Min(rCurr - 1, rPrev + dPrev)
            );
            long fromRightToRight = dp[i - 1, 1] + wallsFromPrevRight;

            dp[i, 1] = Math.Max(fromLeftToRight, fromRightToRight);
        }

        // 3. Final calculation: add contribution of last robot firing Right into the infinite end gap
        long lastRightEndGap = CountWalls(
            dWalls,
            botPairs[n - 1].pos + 1,
            botPairs[n - 1].pos + botPairs[n - 1].dist
        );

        return fixedWallsCount + (int)Math.Max(dp[n - 1, 0], dp[n - 1, 1] + lastRightEndGap);
    }

    private int CountWalls(int[] walls, int L, int R)
    {
        if (L > R || walls.Length == 0)
            return 0;
        int start = LowerBound(walls, L);
        int end = UpperBound(walls, R);
        return (end >= start) ? (end - start + 1) : 0;
    }

    private int CountUnion(int[] walls, int s1, int e1, int s2, int e2)
    {
        bool v1 = s1 <= e1;
        bool v2 = s2 <= e2;
        if (!v1 && !v2)
            return 0;
        if (!v1)
            return CountWalls(walls, s2, e2);
        if (!v2)
            return CountWalls(walls, s1, e1);

        // If ranges overlap or touch, merge them
        if (Math.Max(s1, s2) <= Math.Min(e1, e2))
        {
            return CountWalls(walls, Math.Min(s1, s2), Math.Max(e1, e2));
        }
        // Disjoint ranges
        return CountWalls(walls, s1, e1) + CountWalls(walls, s2, e2);
    }

    private int LowerBound(int[] arr, int target)
    {
        int low = 0,
            high = arr.Length - 1,
            ans = arr.Length;
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
            high = arr.Length - 1,
            ans = -1;
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
