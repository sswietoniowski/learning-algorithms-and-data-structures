namespace leetcode.P3721_LongestBalancedSubarrayII;

// https://leetcode.com/problems/longest-balanced-subarray-ii/description/?envType=daily-question&envId=2026-02-11
public class Solution
{
    private int[] minTree;
    private int[] maxTree;
    private int[] lazy;
    private int n;

    public int LongestBalanced(int[] nums)
    {
        n = nums.Length;
        int size = 4 * n;

        minTree = new int[size];
        maxTree = new int[size];
        lazy = new int[size];

        Dictionary<int, int> lastSeen = new Dictionary<int, int>();

        int maxLen = 0;

        for (int right = 0; right < n; right++)
        {
            int num = nums[right];
            int prevIndex = lastSeen.ContainsKey(num) ? lastSeen[num] : -1;

            int val = (num % 2 == 0) ? 1 : -1;

            Update(1, 0, n - 1, prevIndex + 1, right, val);

            lastSeen[num] = right;

            int left = FindLeftmostZero(1, 0, n - 1);

            if (left != -1)
            {
                maxLen = Math.Max(maxLen, right - left + 1);
            }
        }

        return maxLen;
    }

    private void Push(int node)
    {
        if (lazy[node] != 0)
        {
            int leftChild = 2 * node;
            int rightChild = 2 * node + 1;

            lazy[leftChild] += lazy[node];
            minTree[leftChild] += lazy[node];
            maxTree[leftChild] += lazy[node];

            lazy[rightChild] += lazy[node];
            minTree[rightChild] += lazy[node];
            maxTree[rightChild] += lazy[node];

            lazy[node] = 0;
        }
    }

    private void Update(int node, int start, int end, int l, int r, int val)
    {
        if (l > r)
            return;

        if (l <= start && end <= r)
        {
            minTree[node] += val;
            maxTree[node] += val;
            lazy[node] += val;
            return;
        }

        Push(node);
        int mid = (start + end) / 2;

        if (l <= mid)
            Update(2 * node, start, mid, l, r, val);
        if (r > mid)
            Update(2 * node + 1, mid + 1, end, l, r, val);

        minTree[node] = Math.Min(minTree[2 * node], minTree[2 * node + 1]);
        maxTree[node] = Math.Max(maxTree[2 * node], maxTree[2 * node + 1]);
    }

    private int FindLeftmostZero(int node, int start, int end)
    {
        if (minTree[node] > 0 || maxTree[node] < 0)
            return -1;

        if (start == end)
        {
            return (minTree[node] == 0) ? start : -1;
        }

        Push(node);
        int mid = (start + end) / 2;

        int res = FindLeftmostZero(2 * node, start, mid);
        if (res != -1)
            return res;

        return FindLeftmostZero(2 * node + 1, mid + 1, end);
    }
}
