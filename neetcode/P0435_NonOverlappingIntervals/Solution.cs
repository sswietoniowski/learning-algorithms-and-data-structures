namespace neetcode.P0435_NonOverlappingIntervals;

// https://leetcode.com/problems/non-overlapping-intervals/description/
// https://neetcode.io/problems/non-overlapping-intervals/question?list=blind75
public class Solution
{
    public int EraseOverlapIntervals(int[][] intervals)
    {
        Array.Sort(intervals, (a, b) => a[1].CompareTo(b[1]));
        int res = 0;
        int prevEnd = intervals[0][1];

        for (int i = 1; i < intervals.Length; i++)
        {
            int start = intervals[i][0];
            int end = intervals[i][1];
            if (start < prevEnd)
            {
                res++;
            }
            else
            {
                prevEnd = end;
            }
        }
        return res;
    }
}
