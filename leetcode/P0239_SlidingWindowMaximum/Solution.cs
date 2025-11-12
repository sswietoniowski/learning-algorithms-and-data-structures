namespace leetcode.P0239_SlidingWindowMaximum;

public class Solution
{
    // https://leetcode.com/problems/sliding-window-maximum
    public int[] MaxSlidingWindow(int[] nums, int k)
    {
        if (nums == null || nums.Length == 0 || k <= 0)
            return [];

        int n = nums.Length;
        int[] output = new int[n - k + 1];
        var q = new LinkedList<int>();
        int l = 0,
            r = 0;

        while (r < n)
        {
            while (q.Count > 0 && nums[q.Last.Value] < nums[r])
            {
                q.RemoveLast();
            }
            q.AddLast(r);

            if (l > q.First.Value)
            {
                q.RemoveFirst();
            }

            if ((r + 1) >= k)
            {
                output[l] = nums[q.First.Value];
                l++;
            }
            r++;
        }

        return output;
    }
}
