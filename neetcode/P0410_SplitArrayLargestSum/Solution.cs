namespace neetcode.P0410_SplitArrayLargestSum;

// https://leetcode.com/problems/split-array-largest-sum/description/
// https://neetcode.io/problems/split-array-largest-sum/question
public class Solution
{
    public int SplitArray(int[] nums, int k)
    {
        int low = 0;
        int high = 0;
        foreach (var n in nums)
        {
            low = Math.Max(n, low);
            high += n;
        }

        while (low < high)
        {
            int mid = low + (high - low) / 2;
            if (CanSplit(nums, k, mid))
            {
                high = mid;
            }
            else
            {
                low = mid + 1;
            }
        }

        return low;
    }

    private bool CanSplit(int[] nums, int k, long targetSum)
    {
        int count = 1;
        long currentSum = 0;

        foreach (int num in nums)
        {
            if (num > targetSum)
                return false;

            if (currentSum + num <= targetSum)
            {
                currentSum += num;
            }
            else
            {
                count++;
                currentSum = num;

                if (count > k)
                    return false;
            }
        }

        return count <= k;
    }
}
