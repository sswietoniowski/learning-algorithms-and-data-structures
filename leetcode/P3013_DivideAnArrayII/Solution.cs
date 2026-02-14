namespace leetcode.P3013_DivideAnArrayII;

// https://leetcode.com/problems/divide-an-array-into-subarrays-with-minimum-cost-ii/description/?envType=daily-question&envId=2026-02-02
public class Solution
{
    public long MinimumCost(int[] nums, int k, int dist)
    {
        long minTotal = long.MaxValue;
        long sumLeft = 0;
        int target = k - 2;
        int n = nums.Length;

        var comparer = Comparer<(int val, int idx)>.Create(
            (a, b) =>
            {
                int cmp = a.val.CompareTo(b.val);
                return cmp == 0 ? a.idx.CompareTo(b.idx) : cmp;
            }
        );

        var left = new SortedSet<(int val, int idx)>(comparer);
        var right = new SortedSet<(int val, int idx)>(comparer);

        void Add(int val, int idx)
        {
            var item = (val, idx);

            right.Add(item);

            var minRight = right.Min;
            right.Remove(minRight);
            left.Add(minRight);
            sumLeft += minRight.val;

            if (left.Count > target)
            {
                var maxLeft = left.Max;
                left.Remove(maxLeft);
                sumLeft -= maxLeft.val;
                right.Add(maxLeft);
            }
        }

        void Remove(int val, int idx)
        {
            var item = (val, idx);
            if (left.Contains(item))
            {
                left.Remove(item);
                sumLeft -= val;
            }
            else
            {
                right.Remove(item);
            }

            if (left.Count < target && right.Count > 0)
            {
                var minRight = right.Min;
                right.Remove(minRight);
                left.Add(minRight);
                sumLeft += minRight.val;
            }
        }

        for (int i = 2; i <= 1 + dist && i < n; i++)
        {
            Add(nums[i], i);
        }

        for (int p = 1; p <= n - k + 1; p++)
        {
            if (left.Count == target)
            {
                long currentCost = (long)nums[0] + nums[p] + sumLeft;
                if (currentCost < minTotal)
                {
                    minTotal = currentCost;
                }
            }

            if (p + 1 < n)
            {
                Remove(nums[p + 1], p + 1);
            }

            if (p + 1 + dist < n)
            {
                Add(nums[p + 1 + dist], p + 1 + dist);
            }
        }

        return minTotal;
    }
}
