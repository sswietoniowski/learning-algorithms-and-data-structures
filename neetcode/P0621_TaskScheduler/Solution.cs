namespace neetcode.P0621_TaskScheduler;

// https://leetcode.com/problems/task-scheduler/
// https://youtu.be/s8p8ukTyA2I
public class Solution
{
    public int LeastInterval(char[] tasks, int n)
    {
        var map = new Dictionary<char, int>();
        
        foreach (var task in tasks)
        {
            if (!map.ContainsKey(task))
            {
                map.Add(task, 0);
            }

            map[task]++;
        }

        var maxHeap = new PriorityQueue<int, int>();

        foreach (var key in map.Keys)
        {
            maxHeap.Enqueue(map[key], -map[key]);
        }

        int time = 0;

        var queue = new Queue<(int, int)>();

        while (maxHeap.Count > 0 || queue.Count > 0)
        {
            time++;

            if (maxHeap.Count > 0)
            {
                var count = maxHeap.Dequeue();
                count--;

                if (count > 0)
                {
                    queue.Enqueue((count, time + n));
                }
            }

            if (queue.Count > 0)
            {
                var (count, timeToEnqueue) = queue.Peek();

                if (timeToEnqueue <= time)
                {
                    queue.Dequeue();
                    maxHeap.Enqueue(count, -count);
                }
            }

        }

        return time;
    }
}