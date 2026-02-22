namespace neetcode.P0881_BoatsToSavePeople;

// https://leetcode.com/problems/boats-to-save-people/
// https://neetcode.io/problems/boats-to-save-people/history?submissionIndex=0
public class Solution
{
    public int NumRescueBoats(int[] people, int limit)
    {
        Array.Sort(people);

        int boatCount = 0;
        int left = 0;
        int right = people.Length - 1;

        while (left <= right)
        {
            if (people[left] + people[right] <= limit)
            {
                left++;
            }

            right--;

            boatCount++;
        }

        return boatCount;
    }
}
