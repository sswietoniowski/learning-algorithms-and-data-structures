namespace leetcode.P0239_SlidingWindowMaximum;

public class Solution
{
    // https://leetcode.com/problems/sliding-window-maximum
    public int[] MaxSlidingWindow(int[] nums, int k)
    { 
        if (nums == null || nums.Length == 0 || k <= 0) return [];

        int n = nums.Length;
        int[] result = new int[n - k + 1];
        var windowHeap = new PriorityQueue<(int, int), int>();
        var windowElements = new HashSet<int>();


        for (int i = 0; i < k; i++)
        {
            windowHeap.Enqueue((nums[i], i), -nums[i]);
            windowElements.Add(i);
        }

        result[0] = windowHeap.Peek().Item1;

        for (int i = 1; i <= n - k; i++)
        {
            while (windowHeap.Count > 0 && !windowElements.Contains(windowHeap.Peek().Item2))
            {
                windowHeap.Dequeue();
            }

            result[i - 1] = windowHeap.Peek().Item1;
            windowElements.Remove(i - 1);
            windowHeap.Enqueue((nums[i + k - 1], i + k - 1), -nums[i + k - 1]);
            windowElements.Add(i + k - 1);
        }

        while (windowHeap.Count > 0 && !windowElements.Contains(windowHeap.Peek().Item2))
        {
            windowHeap.Dequeue();
        }

        result[n - k] = windowHeap.Peek().Item1;

        return result;
    }
}