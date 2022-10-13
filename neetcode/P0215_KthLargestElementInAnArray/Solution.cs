namespace neetcode.P0215_KthLargestElementInAnArray;

// https://leetcode.com/problems/kth-largest-element-in-an-array/
// https://youtu.be/XEmy13g1Qxc
public class Solution
{
    public int FindKthLargest(int[] nums, int k)
    {
        var heap = new PriorityQueue<int, int>();

        foreach (var num in nums)
        {
            heap.Enqueue(num, -num);
        }

        for (int i = 0; i < k - 1; i++)
        {
            heap.Dequeue();
        }

        return heap.Dequeue();
    }
}