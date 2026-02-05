namespace leetcode.P0349_IntersectionOfTwoArrays;

// https://leetcode.com/problems/intersection-of-two-arrays/description/
// v1
/*
public class Solution
{
    public int[] Intersection(int[] nums1, int[] nums2)
    {
        Array.Sort(nums2);
        var result = new HashSet<int>();
        foreach (var n in nums1)
        {
            if (Found(nums2, n))
            {
                result.Add(n);
            }
        }
        return result.ToArray();
    }

    private bool Found(int[] array, int number)
    {
        int left = 0;
        int right = array.Length - 1;
        while (left <= right)
        {
            int mid = left + (right - left) / 2;

            if (array[mid] == number)
            {
                return true;
            }
            else if (array[mid] > number)
            {
                right = mid - 1;
            }
            else
            {
                left = mid + 1;
            }
        }
        return false;
    }
}
*/
// v2
public class Solution
{
    public int[] Intersection(int[] nums1, int[] nums2)
    {
        return nums1.Intersect(nums2).ToArray();
    }
}
