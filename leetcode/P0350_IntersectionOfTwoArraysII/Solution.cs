namespace leetcode.P0350_IntersectionOfTwoArraysII;

// https://leetcode.com/problems/intersection-of-two-arrays-ii/description/
// v1
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
