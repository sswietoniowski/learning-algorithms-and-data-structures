namespace neetcode.P1200_MinimumAbsoluteDifference;

// https://leetcode.com/problems/minimum-absolute-difference/description/?envType=daily-question&envId=2026-01-26
// v1
/*
public class Solution
{
    public IList<IList<int>> MinimumAbsDifference(int[] arr)
    {
        Array.Sort(arr);
        var minimumDifference = int.MaxValue;
        for (int i = 1; i < arr.Length; i++)
        {
            minimumDifference = Math.Min(minimumDifference, arr[i] - arr[i - 1]);
        }
        var result = new List<IList<int>>();
        for (int i = 1; i < arr.Length; i++)
        {
            if (arr[i] - arr[i - 1] == minimumDifference)
            {
                var pair = new List<int> { arr[i - 1], arr[i] };
                result.Add(pair);
            }
        }
        return result;
    }
}
*/
// v2
public class Solution
{
    public IList<IList<int>> MinimumAbsDifference(int[] arr)
    {
        Array.Sort(arr);

        var result = new List<IList<int>>();
        int minDiff = int.MaxValue;

        for (int i = 0; i < arr.Length - 1; i++)
        {
            int currentDiff = arr[i + 1] - arr[i];

            if (currentDiff < minDiff)
            {
                minDiff = currentDiff;
                result.Clear();
                result.Add([arr[i], arr[i + 1]]);
            }
            else if (currentDiff == minDiff)
            {
                result.Add([arr[i], arr[i + 1]]);
            }
        }

        return result;
    }
}
