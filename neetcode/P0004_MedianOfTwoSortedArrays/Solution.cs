namespace neetcode.P0004_MedianOfTwoSortedArrays;

public class Solution
{
    // https://leetcode.com/problems/median-of-two-sorted-arrays
    // https://neetcode.io/problems/median-of-two-sorted-arrays?list=neetcode150
    public double FindMedianSortedArrays(int[] nums1, int[] nums2)
    {
        int[] A = nums1;
        int[] B = nums2;
        int total = A.Length + B.Length;
        int half = (total + 1) / 2;

        if (B.Length < A.Length)
        {
            int[] temp = A;
            A = B;
            B = temp;
        }

        int l = 0;
        int r = A.Length;
        while (l <= r)
        {
            int i = (l + r) / 2;
            int j = half - i;

            int Aleft = i > 0 ? A[i - 1] : int.MinValue;
            int Aright = i < A.Length ? A[i] : int.MaxValue;
            int Bleft = j > 0 ? B[j - 1] : int.MinValue;
            int Bright = j < B.Length ? B[j] : int.MaxValue;

            if (Aleft <= Bright && Bleft <= Aright)
            {
                if (total % 2 != 0)
                {
                    return Math.Max(Aleft, Bleft);
                }
                return (Math.Max(Aleft, Bleft) + Math.Min(Aright, Bright)) / 2.0;
            }
            else if (Aleft > Bright)
            {
                r = i - 1;
            }
            else
            {
                l = i + 1;
            }
        }
        return -1;
    }
}
