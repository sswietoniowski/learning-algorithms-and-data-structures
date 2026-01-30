namespace neetcode.P0977_SquaresOfASortedArray;

// https://leetcode.com/problems/squares-of-a-sorted-array/description/
// https://neetcode.io/problems/squares-of-a-sorted-array/question?list=allNC
// v1
/*
public class Solution
{
    public int[] SortedSquares(int[] nums)
    {
        for (int i = 0; i < nums.Length; i++)
        {
            nums[i] *= nums[i];
        }
        Array.Sort(nums);
        return nums;
    }
}
*/
// v2
/*
public class Solution
{
    public int[] SortedSquares(int[] nums)
    {
        int[] result = new int[nums.Length];

        int l = 0;
        int r = nums.Length - 1;
        int k = nums.Length - 1;

        while (l <= r)
        {
            if (Math.Abs(nums[l]) >= Math.Abs(nums[r]))
            {
                result[k] = nums[l];
                l++;
            }
            else
            {
                result[k] = nums[r];
                r--;
            }
            k--;
        }

        for (int i = 0; i < result.Length; i++)
        {
            result[i] *= result[i];
        }

        return result;
    }
}
*/
// v3
public class Solution
{
    public int[] SortedSquares(int[] nums)
    {
        int n = nums.Length;
        int[] result = new int[n];

        int left = 0;
        int right = n - 1;

        for (int i = n - 1; i >= 0; i--)
        {
            int leftSquare = nums[left] * nums[left];
            int rightSquare = nums[right] * nums[right];

            if (leftSquare > rightSquare)
            {
                result[i] = leftSquare;
                left++;
            }
            else
            {
                result[i] = rightSquare;
                right--;
            }
        }

        return result;
    }
}
