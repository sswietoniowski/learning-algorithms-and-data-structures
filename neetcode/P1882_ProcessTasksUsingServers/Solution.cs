namespace neetcode.P1882_ProcessTasksUsingServers;

public class Solution
{
    public int[] AssignTasks(int[] servers, int[] tasks)
    {
        int m = tasks.Length,
            n = servers.Length;
        int[] res = new int[m];

        var available = new PriorityQueue<int[], int[]>(
            Comparer<int[]>.Create(
                (a, b) =>
                {
                    if (a[0] != b[0])
                        return a[0].CompareTo(b[0]);
                    if (a[1] != b[1])
                        return a[1].CompareTo(b[1]);
                    return a[2].CompareTo(b[2]);
                }
            )
        );

        var unavailable = new PriorityQueue<int[], int[]>(
            Comparer<int[]>.Create(
                (a, b) =>
                {
                    if (a[0] != b[0])
                        return a[0].CompareTo(b[0]);
                    if (a[1] != b[1])
                        return a[1].CompareTo(b[1]);
                    return a[2].CompareTo(b[2]);
                }
            )
        );

        for (int i = 0; i < n; i++)
        {
            var arr = new int[] { servers[i], i, 0 };
            available.Enqueue(arr, arr);
        }

        for (int i = 0; i < m; i++)
        {
            while ((unavailable.Count > 0 && unavailable.Peek()[0] <= i) || available.Count == 0)
            {
                var server = unavailable.Dequeue();
                var arr = new int[] { server[1], server[2], server[0] };
                available.Enqueue(arr, arr);
            }
            var best = available.Dequeue();
            res[i] = best[1];
            var newArr = new int[] { Math.Max(best[2], i) + tasks[i], best[0], best[1] };
            unavailable.Enqueue(newArr, newArr);
        }

        return res;
    }
}
