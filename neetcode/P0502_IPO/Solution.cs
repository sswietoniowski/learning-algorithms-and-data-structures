namespace neetcode.P0502_IPO;

// https://leetcode.com/problems/ipo/description/
// https://neetcode.io/problems/ipo/question?list=neetcode250
public class Solution
{
    public int FindMaximizedCapital(int k, int w, int[] profits, int[] capital)
    {
        int n = profits.Length;
        // 1. Pair profits and capital together so we can sort them by capital
        (int cap, int prof)[] projects = new (int, int)[n];
        for (int i = 0; i < n; i++)
        {
            projects[i] = (capital[i], profits[i]);
        }

        // 2. Sort projects by the capital required (ascending)
        Array.Sort(projects, (a, b) => a.cap.CompareTo(b.cap));

        // 3. Max-Heap for profits (using a custom comparer to make it a Max-Heap)
        PriorityQueue<int, int> maxProfitHeap = new PriorityQueue<int, int>(
            Comparer<int>.Create((a, b) => b.CompareTo(a))
        );

        int currentProjectIndex = 0;

        // 4. Perform at most k projects
        for (int i = 0; i < k; i++)
        {
            // Add all projects we can now afford into the Max-Heap
            while (currentProjectIndex < n && projects[currentProjectIndex].cap <= w)
            {
                maxProfitHeap.Enqueue(
                    projects[currentProjectIndex].prof,
                    projects[currentProjectIndex].prof
                );
                currentProjectIndex++;
            }

            // If the heap is empty, we can't afford any more new projects
            if (maxProfitHeap.Count == 0)
            {
                break;
            }

            // Greedily pick the project with the highest profit
            w += maxProfitHeap.Dequeue();
        }

        return w;
    }
}
