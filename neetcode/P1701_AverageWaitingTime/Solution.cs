namespace neetcode.P1701_AverageWaitingTime;

// https://leetcode.com/problems/average-waiting-time/description/
// v1
/*
public class Solution
{
    public double AverageWaitingTime(int[][] customers)
    {
        if (customers.Length == 1)
        {
            return customers[0][1];
        }

        long start = customers[0][0];
        long waiting = customers[0][1];
        long end = start + waiting;

        for (int i = 1; i < customers.Length; i++)
        {
            long arrival = customers[i][0];
            long time = customers[i][1];
            if (arrival < end)
            {
                start = end;
            }
            else
            {
                start = arrival;
            }
            end = start + time;
            waiting += end - arrival;
        }

        return waiting / ((double)customers.Length);
    }
}
*/
// v2
public class Solution
{
    public double AverageWaitingTime(int[][] customers)
    {
        long chefFreeAt = 0;
        long totalWaitTime = 0;

        foreach (var customer in customers)
        {
            long arrival = customer[0];
            long cookTime = customer[1];

            chefFreeAt = Math.Max(chefFreeAt, arrival) + cookTime;

            totalWaitTime += (chefFreeAt - arrival);
        }

        return (double)totalWaitTime / customers.Length;
    }
}
