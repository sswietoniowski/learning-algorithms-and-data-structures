using System.Collections;

namespace neetcode.P0252_MeetingRooms
{
    public class Solution
    {
        public class StartComparer : IComparer
        {
            public int Compare(Object x, Object y)
            {
                int[] first = x as int[];
                int[] second = y as int[];

                if (first == null || second == null)
                {
                    throw new ArgumentException();
                }

                if (first[0] > second[0])
                {
                    return 1;
                }
                else if (first[0] < second[0])
                {
                    return -1;
                }
                else
                {
                    return 0;
                }
            }
        }

        public bool CanAttendMeetings(int[][] intervals)
        {
            Array.Sort(intervals, new StartComparer());
            for (int i = 1; i < intervals.Length; i++)
            {
                if (intervals[i - 1][1] > intervals[i][0])
                {
                    return false;
                }
            }
            return true;
        }
    }
}
