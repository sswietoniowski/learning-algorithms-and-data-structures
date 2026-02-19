namespace neetcode.P0189_RotateArray;

// https://leetcode.com/problems/rotate-array/description/
// https://neetcode.io/problems/rotate-array/solution

// v1
/*
public class Solution
{
    public void Rotate(int[] nums, int k)
    {
        int n = nums.Length;
        k = k % n;
        int[] result = new int[n];
        for (int i = 0; i < n; i++)
        {
            result[(i + k) % n] = nums[i];
        }
        for (int i = 0; i < n; i++)
        {
            nums[i] = result[i];
        }
    }
}
*/
// v2
public class Solution
{
    public void Rotate(int[] nums, int k)
    {
        int n = nums.Length;
        k %= n;
        int count = 0;

        for (int start = 0; count < n; start++)
        {
            int current = start;
            int prev = nums[start];

            do
            {
                int nextIdx = (current + k) % n;
                int temp = nums[nextIdx];
                nums[nextIdx] = prev;
                prev = temp;
                current = nextIdx;
                count++;
            } while (start != current);
        }
    }
}
