namespace neetcode.P3264_FinalArrayStateAfterKMultiplicationOperationsI;

public class Solution
{
    public int[] GetFinalState(int[] nums, int k, int multiplier)
    {
        int n = nums.Length;
        int[] res = new int[n];
        Array.Copy(nums, res, n);

        var minHeap = new PriorityQueue<int, (int, int)>();
        for (int i = 0; i < n; i++)
        {
            minHeap.Enqueue(i, (res[i], i));
        }

        for (int _ = 0; _ < k; _++)
        {
            int i = minHeap.Dequeue();
            res[i] *= multiplier;
            minHeap.Enqueue(i, (res[i], i));
        }

        return res;
    }
}
