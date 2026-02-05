namespace leetcode.P3190_FindMinimumOperations;

// https://leetcode.com/problems/find-minimum-operations-to-make-all-elements-divisible-by-three/description/
public class Solution
{
    public int MinimumOperations(int[] nums)
    {
        int operations = 0;
        foreach (var n in nums)
        {
            if (n % 3 != 0)
            {
                operations++;
            }
        }
        return operations;
    }
}
