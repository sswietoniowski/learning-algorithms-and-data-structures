namespace leetcode.P1689_PartitioningIntoMinimumNumber;

// https://leetcode.com/problems/partitioning-into-minimum-number-of-deci-binary-numbers/?envType=daily-question&envId=2026-03-01
public class Solution
{
    public int MinPartitions(string n)
    {
        int maxDigit = 0;

        foreach (char c in n)
        {
            int currentDigit = c - '0';

            if (currentDigit > maxDigit)
            {
                maxDigit = currentDigit;
            }

            if (maxDigit == 9)
                return 9;
        }

        return maxDigit;
    }
}
