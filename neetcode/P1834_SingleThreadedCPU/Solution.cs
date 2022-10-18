namespace neetcode.P1834_SingleThreadedCPU
{
    // https://leetcode.com/problems/single-threaded-cpu/
    // https://youtu.be/RR1n-d4oYqE
    public class Solution
    {
        public int[] GetOrder(int[][] tasks)
        {
            var sorted = new (int start, int time, int index)[tasks.Length];
            for (int i = 0; i < tasks.Length; i++)
                sorted[i] = (tasks[i][0], tasks[i][1], i);
            Array.Sort(sorted);

            var result = new List<int>();
            var heap = new SortedSet<(int time, int index)>();
            var index = 0;
            var tick = 0;
            while (result.Count < tasks.Length)
            {
                while (index < sorted.Length && sorted[index].start <= tick)
                {
                    heap.Add((sorted[index].time, sorted[index].index));
                    index++;
                }

                if (heap.Count > 0)
                {
                    var min = heap.Min;
                    heap.Remove(min);
                    result.Add(min.index);
                    tick += min.time;
                }
                else
                    tick = sorted[index].start;
            }
            return result.ToArray();
        }
    }
}
