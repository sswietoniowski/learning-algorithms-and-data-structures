using System.Collections;

namespace neetcode.P0253_MeetingRoomsII;

public class Interval
{
    public int start,
        end;

    public Interval(int start, int end)
    {
        this.start = start;
        this.end = end;
    }
}

// https://leetcode.com/problems/meeting-rooms-ii
// https://neetcode.io/problems/meeting-schedule-ii/question?list=blind75
/**
 * Definition of Interval:
 * public class Interval {
 *     public int start, end;
 *     public Interval(int start, int end) {
 *         this.start = start;
 *         this.end = end;
 *     }
 * }
 */

public class Solution
{
    public int MinMeetingRooms(List<Interval> intervals)
    {
        List<int[]> time = new List<int[]>();
        foreach (var i in intervals)
        {
            time.Add(new int[] { i.start, 1 });
            time.Add(new int[] { i.end, -1 });
        }

        time.Sort((a, b) => a[0] == b[0] ? a[1].CompareTo(b[1]) : a[0].CompareTo(b[0]));

        int res = 0,
            count = 0;
        foreach (var t in time)
        {
            count += t[1];
            res = Math.Max(res, count);
        }
        return res;
    }
}
