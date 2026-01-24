namespace neetcode.P0229_MajorityElementII;

// https://leetcode.com/problems/majority-element-ii/
// https://neetcode.io/problems/majority-element-ii/question
// v1
/*
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
*/
// v2
public class Solution
{
    public List<int> MajorityElement(int[] nums)
    {
        int n = nums.Length;
        int num1 = -1,
            num2 = -1;
        int cnt1 = 0,
            cnt2 = 0;

        foreach (int num in nums)
        {
            if (num == num1)
            {
                cnt1++;
            }
            else if (num == num2)
            {
                cnt2++;
            }
            else if (cnt1 == 0)
            {
                num1 = num;
                cnt1 = 1;
            }
            else if (cnt2 == 0)
            {
                num2 = num;
                cnt2 = 1;
            }
            else
            {
                cnt1--;
                cnt2--;
            }
        }

        cnt1 = cnt2 = 0;
        foreach (int num in nums)
        {
            if (num == num1)
                cnt1++;
            else if (num == num2)
                cnt2++;
        }

        List<int> res = new List<int>();
        if (cnt1 > n / 3)
            res.Add(num1);
        if (cnt2 > n / 3)
            res.Add(num2);

        return res;
    }
}
