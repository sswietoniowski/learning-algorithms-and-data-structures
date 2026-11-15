namespace neetcode.P2542_MaximumSubsequenceScore;

public class Solution
{
    public long MaxScore(int[] nums1, int[] nums2, int k)
    {
        int n = nums1.Length;
        long[] arr = new long[n];

        for (int i = 0; i < n; i++)
        {
            // Pack nums2[i] into the upper bits and nums1[i] into the lower 30 bits
            arr[i] = ((long)nums2[i] << 30) | (long)nums1[i];
        }

        // Sort ascending, then reverse to get descending order
        Array.Sort(arr);
        Array.Reverse(arr);

        // Min-heap using PriorityQueue (stores value and priority)
        PriorityQueue<int, int> minHeap = new PriorityQueue<int, int>();
        long n1Sum = 0;
        long res = 0;

        foreach (long num in arr)
        {
            // Unpack the values
            int n1 = (int)(num & ((1L << 30) - 1));
            int n2 = (int)(num >> 30);

            n1Sum += n1;
            minHeap.Enqueue(n1, n1); // Enqueue with n1 as both element and priority

            if (minHeap.Count > k)
            {
                n1Sum -= minHeap.Dequeue();
            }

            if (minHeap.Count == k)
            {
                res = Math.Max(res, n1Sum * n2);
            }
        }

        return res;
    }
}
