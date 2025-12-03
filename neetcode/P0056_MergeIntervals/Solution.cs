namespace neetcode.P0056_MergeIntervals;

// https://leetcode.com/problems/merge-intervals/description/
// https://neetcode.io/problems/merge-intervals/question?list=blind75
public class Solution
{
    public int[][] Merge(int[][] intervals)
    {
        int max = 0;
        for (int i = 0; i < intervals.Length; i++)
        {
            max = Math.Max(intervals[i][0], max);
        }

        int[] mp = new int[max + 1];
        for (int i = 0; i < intervals.Length; i++)
        {
            int start = intervals[i][0];
            int end = intervals[i][1];
            mp[start] = Math.Max(end + 1, mp[start]);
        }

        var res = new List<int[]>();
        int have = -1;
        int intervalStart = -1;
        for (int i = 0; i < mp.Length; i++)
        {
            if (mp[i] != 0)
            {
                if (intervalStart == -1)
                    intervalStart = i;
                have = Math.Max(mp[i] - 1, have);
            }
            if (have == i)
            {
                res.Add(new int[] { intervalStart, have });
                have = -1;
                intervalStart = -1;
            }
        }

        if (intervalStart != -1)
        {
            res.Add(new int[] { intervalStart, have });
        }

        return res.ToArray();
    }
}
