namespace neetcode.P2402_MeetingRoomsIII;

// https://leetcode.com/problems/meeting-rooms-iii/description/
// https://neetcode.io/problems/meeting-rooms-iii/question?list=neetcode250
public class Solution
{
    public int MostBooked(int n, int[][] meetings)
    {
        // 1. Sort meetings by start time
        Array.Sort(meetings, (a, b) => a[0].CompareTo(b[0]));

        // 2. Track meeting counts for each room
        long[] count = new long[n];

        // 3. Min-Heap for unused rooms (stores room index)
        PriorityQueue<int, int> unusedRooms = new PriorityQueue<int, int>();
        for (int i = 0; i < n; i++)
        {
            unusedRooms.Enqueue(i, i);
        }

        // 4. Min-Heap for used rooms (stores (endTime, roomIndex))
        // We use a custom comparer to prioritize endTime, then roomIndex
        PriorityQueue<int, (long endTime, int roomIndex)> usedRooms = new PriorityQueue<
            int,
            (long endTime, int roomIndex)
        >(new RoomComparer());

        foreach (var meeting in meetings)
        {
            long start = meeting[0];
            long end = meeting[1];
            long duration = end - start;

            // Release rooms that have finished their meetings by the current meeting's start time
            while (usedRooms.Count > 0)
            {
                usedRooms.TryPeek(out int roomIdx, out var info);
                if (info.endTime <= start)
                {
                    usedRooms.Dequeue();
                    unusedRooms.Enqueue(roomIdx, roomIdx);
                }
                else
                {
                    break;
                }
            }

            if (unusedRooms.Count > 0)
            {
                // Case A: A room is free
                int room = unusedRooms.Dequeue();
                count[room]++;
                usedRooms.Enqueue(room, (end, room));
            }
            else
            {
                // Case B: No rooms free, wait for the earliest one to finish
                usedRooms.TryDequeue(out int room, out var info);
                long newStart = info.endTime;
                long newEnd = newStart + duration;

                count[room]++;
                usedRooms.Enqueue(room, (newEnd, room));
            }
        }

        // 5. Find the room with the most meetings (lowest index on tie)
        int resultRoom = 0;
        for (int i = 1; i < n; i++)
        {
            if (count[i] > count[resultRoom])
            {
                resultRoom = i;
            }
        }

        return resultRoom;
    }

    // Custom comparer for the PriorityQueue to sort by endTime first, then roomIndex
    private class RoomComparer : IComparer<(long endTime, int roomIndex)>
    {
        public int Compare((long endTime, int roomIndex) x, (long endTime, int roomIndex) y)
        {
            if (x.endTime != y.endTime)
            {
                return x.endTime.CompareTo(y.endTime);
            }
            return x.roomIndex.CompareTo(y.roomIndex);
        }
    }
}
