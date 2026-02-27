namespace leetcode.P3666_MinimumOperationsToEqualizeBinaryString;

// https://leetcode.com/problems/minimum-operations-to-equalize-binary-string/description/?envType=daily-question&envId=2026-02-27
public class Solution
{
    public int MinOperations(string s, int k)
    {
        int n = s.Length;
        int initialZeros = s.Count(c => c == '0');

        if (initialZeros == 0)
            return 0;

        int[] dist = new int[n + 1];
        Array.Fill(dist, -1);

        SortedSet<int>[] unvisited = new SortedSet<int>[2];
        unvisited[0] = new SortedSet<int>();
        unvisited[1] = new SortedSet<int>();

        for (int i = 0; i <= n; i++)
        {
            unvisited[i % 2].Add(i);
        }

        Queue<int> queue = new Queue<int>();
        queue.Enqueue(initialZeros);
        dist[initialZeros] = 0;
        unvisited[initialZeros % 2].Remove(initialZeros);

        while (queue.Count > 0)
        {
            int z = queue.Dequeue();

            int minFlippedZeros = Math.Max(0, k - (n - z));
            int maxFlippedZeros = Math.Min(k, z);

            int low = z + k - 2 * maxFlippedZeros;
            int high = z + k - 2 * minFlippedZeros;

            var targetSet = unvisited[low % 2];

            var reachable = targetSet.GetViewBetween(low, high).ToList();

            foreach (int nextZ in reachable)
            {
                if (nextZ == 0)
                    return dist[z] + 1;

                dist[nextZ] = dist[z] + 1;
                queue.Enqueue(nextZ);
                targetSet.Remove(nextZ);
            }
        }

        return -1;
    }
}
