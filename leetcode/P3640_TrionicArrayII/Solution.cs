namespace leetcode.P3640_TrionicArrayII;

// https://leetcode.com/problems/trionic-array-ii/description/?envType=daily-question&envId=2026-02-04
public class Solution
{
    public long MaxSumTrionic(int[] nums)
    {
        long inf = -1_000_000_000_000_000L;
        long inc1_len1 = nums[0];
        long inc1_len2 = inf;
        long dec = inf;
        long inc2 = inf;
        long maxTrionic = inf;
        for (int i = 1; i < nums.Length; i++)
        {
            long val = nums[i];
            long prev = nums[i - 1];
            long next_inc1_len1 = inf;
            long next_inc1_len2 = inf;
            long next_dec = inf;
            long next_inc2 = inf;
            if (val > prev)
            {
                next_inc1_len1 = Math.Max(val, inc1_len1 + val);
                next_inc1_len2 = inc1_len1 + val;
                next_inc2 = Math.Max(inc2, dec) + val;
            }
            else if (val < prev)
            {
                next_inc1_len1 = val;
                next_dec = Math.Max(dec, inc1_len2) + val;
            }
            else
            {
                next_inc1_len1 = val;
            }
            inc1_len1 = next_inc1_len1;
            inc1_len2 = next_inc1_len2;
            dec = next_dec;
            inc2 = next_inc2;
            if (inc2 > maxTrionic)
            {
                maxTrionic = inc2;
            }
        }
        return maxTrionic;
    }
}
