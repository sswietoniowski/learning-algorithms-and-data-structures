namespace leetcode.P0239_SlidingWindowMaximum;

public class Solution
{
    // https://leetcode.com/problems/sliding-window-maximum
    public int[] MaxSlidingWindow(int[] nums, int k)
    {
        if (nums == null || nums.Length == 0 || k <= 0) return [];

        int n = nums.Length;
        int[] result = new int[n - k + 1];
        LinkedList<int> dq = new LinkedList<int>();

        int ri = 0;
        for (int i = 0; i < n; i++)
        {
            if (dq.Count > 0 && dq.First.Value <= i - k) dq.RemoveFirst();

            while (dq.Count > 0 && nums[dq.Last.Value] <= nums[i])
                dq.RemoveLast();

            dq.AddLast(i);

            if (i >= k - 1)
                result[ri++] = nums[dq.First.Value];
        }

        return result;
    }
}