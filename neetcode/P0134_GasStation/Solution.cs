namespace neetcode.P0134_GasStation;

// https://leetcode.com/problems/gas-station/description/
// https://neetcode.io/problems/gas-station/question?list=neetcode150
public class Solution
{
    public int CanCompleteCircuit(int[] gas, int[] cost)
    {
        int n = gas.Length;
        int start = n - 1,
            end = 0;
        int tank = gas[start] - cost[start];
        while (start > end)
        {
            if (tank < 0)
            {
                start--;
                tank += gas[start] - cost[start];
            }
            else
            {
                tank += gas[end] - cost[end];
                end++;
            }
        }
        return tank >= 0 ? start : -1;
    }
}
