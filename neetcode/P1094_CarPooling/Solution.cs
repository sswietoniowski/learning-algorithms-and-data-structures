namespace neetcode.P1094_CarPooling;

// https://leetcode.com/problems/car-pooling/description/
// https://neetcode.io/problems/car-pooling/question?list=neetcode250
public class Solution
{
    public bool CarPooling(int[][] trips, int capacity)
    {
        // Since the problem constraints say locations are between 0 and 1000
        int[] occupancyChange = new int[1001];

        foreach (var trip in trips)
        {
            int numPassengers = trip[0];
            int start = trip[1];
            int end = trip[2];

            // Passengers get ON
            occupancyChange[start] += numPassengers;
            // Passengers get OFF
            occupancyChange[end] -= numPassengers;
        }

        int currentPassengers = 0;
        // Sweep through the timeline
        for (int i = 0; i < occupancyChange.Length; i++)
        {
            currentPassengers += occupancyChange[i];

            // Check if we ever exceed capacity
            if (currentPassengers > capacity)
            {
                return false;
            }
        }

        return true;
    }
}
