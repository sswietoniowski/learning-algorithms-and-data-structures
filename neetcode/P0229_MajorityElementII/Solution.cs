namespace neetcode.P0229_MajorityElementII;

// https://leetcode.com/problems/majority-element-ii/
// https://neetcode.io/problems/majority-element-ii/question
// v1
public class Solution
{
    public List<int> MajorityElement(int[] nums)
    {
        var numberFrequencies = new Dictionary<int, int>();
        var uniqueNumbers = new HashSet<int>();
        foreach (var number in nums)
        {
            if (!uniqueNumbers.Contains(number))
            {
                numberFrequencies.Add(number, 1);
                uniqueNumbers.Add(number);
            }
            else
            {
                numberFrequencies[number]++;
            }
        }
        var cutOffFrequency = Math.Floor(nums.Length / 3.0);
        var majorityElements = new List<int>();
        foreach (var (number, frequency) in numberFrequencies)
        {
            if (frequency > cutOffFrequency)
            {
                majorityElements.Add(number);
            }
        }
        return majorityElements;
    }
}
