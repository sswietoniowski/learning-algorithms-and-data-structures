namespace neetcode.P1011_CapacityToShipPackagesWithinDDays;

// https://leetcode.com/problems/capacity-to-ship-packages-within-d-days/description/
// https://neetcode.io/problems/capacity-to-ship-packages-within-d-days/question
public class Solution
{
    public int ShipWithinDays(int[] weights, int days)
    {
        int maxWeight = 0;
        int sumOfWeights = 0;
        foreach (var weight in weights)
        {
            maxWeight = Math.Max(weight, maxWeight);
            sumOfWeights += weight;
        }

        int start = maxWeight;
        int end = sumOfWeights;
        while (start < end)
        {
            int mid = start + (end - start) / 2;

            if (IsEnoughCapacity(weights, days, mid))
            {
                end = mid;
            }
            else
            {
                start = mid + 1;
            }
        }

        return start;
    }

    private bool IsEnoughCapacity(int[] weights, int days, int capacity)
    {
        int totalDays = 1;
        int currentDayLoad = 0;

        foreach (var weight in weights)
        {
            if (currentDayLoad + weight > capacity)
            {
                currentDayLoad = weight;
                totalDays++;
            }
            else
            {
                currentDayLoad += weight;
            }
        }

        return totalDays <= days;
    }
}
