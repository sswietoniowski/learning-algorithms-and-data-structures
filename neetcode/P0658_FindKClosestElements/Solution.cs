namespace neetcode.P0658_FindKClosestElements;

// https://leetcode.com/problems/find-k-closest-elements/description/
// https://neetcode.io/problems/find-k-closest-elements/question?list=neetcode250
public class Solution
{
    public IList<int> FindClosestElements(int[] arr, int k, int x)
    {
        int l = 0,
            r = arr.Length - k;
        while (l < r)
        {
            int m = (l + r) / 2;
            if (x - arr[m] > arr[m + k] - x)
            {
                l = m + 1;
            }
            else
            {
                r = m;
            }
        }
        var result = new List<int>();
        for (int i = l; i < l + k; i++)
        {
            result.Add(arr[i]);
        }
        return result;
    }
}
