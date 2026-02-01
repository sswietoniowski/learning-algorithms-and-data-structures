namespace neetcode.P2570_MergeTwo2DArrays;

// https://leetcode.com/problems/merge-two-2d-arrays-by-summing-values/description/
// v1
/*
public class Solution
{
    public int[][] MergeArrays(int[][] nums1, int[][] nums2)
    {
        var result = new List<int[]>();

        int l = 0;
        int r = 0;
        while (l < nums1.Length || r < nums2.Length)
        {
            var row = new int[2];
            if (l < nums1.Length && r < nums2.Length)
            {
                if (nums1[l][0] == nums2[r][0])
                {
                    row[0] = nums1[l][0];
                    row[1] = nums1[l][1] + nums2[r][1];
                    l++;
                    r++;
                }
                else if (nums1[l][0] < nums2[r][0])
                {
                    row[0] = nums1[l][0];
                    row[1] = nums1[l][1];
                    l++;
                }
                else
                {
                    row[0] = nums2[r][0];
                    row[1] = nums2[r][1];
                    r++;
                }
            }
            else if (l < nums1.Length)
            {
                row[0] = nums1[l][0];
                row[1] = nums1[l][1];
                l++;
            }
            else
            {
                row[0] = nums2[r][0];
                row[1] = nums2[r][1];
                r++;
            }
            result.Add(row);
        }

        return result.ToArray();
    }
}
*/
// v2
public class Solution
{
    public int[][] MergeArrays(int[][] nums1, int[][] nums2)
    {
        int n1 = nums1.Length,
            n2 = nums2.Length;
        var result = new List<int[]>();
        int i = 0,
            j = 0;

        while (i < n1 && j < n2)
        {
            if (nums1[i][0] == nums2[j][0])
            {
                result.Add(new int[] { nums1[i][0], nums1[i][1] + nums2[j][1] });
                i++;
                j++;
            }
            else if (nums1[i][0] < nums2[j][0])
            {
                result.Add(nums1[i]);
                i++;
            }
            else
            {
                result.Add(nums2[j]);
                j++;
            }
        }

        while (i < n1)
            result.Add(nums1[i++]);
        while (j < n2)
            result.Add(nums2[j++]);

        return result.ToArray();
    }
}
