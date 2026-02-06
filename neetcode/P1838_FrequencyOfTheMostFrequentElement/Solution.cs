namespace neetcode.P1838_FrequencyOfTheMostFrequentElement;

// https://leetcode.com/problems/frequency-of-the-most-frequent-element/description/
// https://youtu.be/RR1n-d4oYqE
public class Solution
{
    public int MaxFrequency(int[] nums, int k)
    {
        Array.Sort(nums);

        int n = nums.Length;
        int left = 0;
        long currentSum = 0;
        int maxFrequency = 0;

        for (int right = 0; right < n; right++)
        {
            currentSum += nums[right];

            while ((long)nums[right] * (right - left + 1) - currentSum > k)
            {
                currentSum -= nums[left];
                left++;
            }

            maxFrequency = Math.Max(maxFrequency, right - left + 1);
        }

        return maxFrequency;
    }
}
