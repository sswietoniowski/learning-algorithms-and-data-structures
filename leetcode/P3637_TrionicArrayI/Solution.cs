namespace leetcode.P3637_TrionicArrayI;

// https://leetcode.com/problems/trionic-array-i/description/?envType=daily-question&envId=2026-02-03
public class Solution
{
    public bool IsTrionic(int[] nums)
    {
        int n = nums.Length;
        if (n < 4)
            return false;

        int i = 0;

        while (i < n - 1 && nums[i] < nums[i + 1])
        {
            i++;
        }

        if (i == 0 || i >= n - 2)
            return false;

        int p = i;
        while (i < n - 1 && nums[i] > nums[i + 1])
        {
            i++;
        }

        if (i == p || i == n - 1)
            return false;

        while (i < n - 1 && nums[i] < nums[i + 1])
        {
            i++;
        }

        return i == n - 1;
    }
}
