namespace neetcode.P1675_MinimizeDeviationInArray;

public class Solution
{
    public int MinimumDeviation(int[] nums)
    {
        var maxHeap = new PriorityQueue<int, int>(Comparer<int>.Create((a, b) => b.CompareTo(a)));
        int minVal = int.MaxValue;

        foreach (int num in nums)
        {
            int n = num;
            if (n % 2 == 1)
                n *= 2;
            maxHeap.Enqueue(n, n);
            minVal = Math.Min(minVal, n);
        }

        int res = int.MaxValue;

        while (maxHeap.Count > 0)
        {
            int maxVal = maxHeap.Dequeue();
            res = Math.Min(res, maxVal - minVal);

            if (maxVal % 2 == 1)
                break;

            int nextVal = maxVal / 2;
            maxHeap.Enqueue(nextVal, nextVal);
            minVal = Math.Min(minVal, nextVal);
        }

        return res;
    }
}
