namespace leetcode.P0350_IntersectionOfTwoArraysII;

// https://leetcode.com/problems/intersection-of-two-arrays-ii/description/
// v1
/*
public class Solution
{
    public int[] Intersect(int[] nums1, int[] nums2)
    {
        int[] counts1 = new int[1001];
        foreach (var n in nums1)
        {
            counts1[n]++;
        }
        int[] counts2 = new int[1001];
        foreach (var n in nums2)
        {
            counts2[n]++;
        }
        var result = new List<int>();
        for (int i = 0; i < counts1.Length; i++)
        {
            if (counts1[i] > 0 && counts2[i] > 0)
            {
                for (int j = 0; j < Math.Min(counts1[i], counts2[i]); j++)
                {
                    result.Add(i);
                }
            }
        }
        return result.ToArray();
    }
}
*/
// v2
public class Solution
{
    public int[] Intersect(int[] nums1, int[] nums2)
    {
        if (nums1.Length > nums2.Length)
        {
            return Intersect(nums2, nums1);
        }

        var counts = new Dictionary<int, int>();
        foreach (int n in nums1)
        {
            counts[n] = counts.GetValueOrDefault(n) + 1;
        }

        var result = new List<int>();
        foreach (int n in nums2)
        {
            if (counts.TryGetValue(n, out int count) && count > 0)
            {
                result.Add(n);
                counts[n]--;
            }
        }

        return result.ToArray();
    }
}
