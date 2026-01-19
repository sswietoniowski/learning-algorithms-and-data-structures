namespace neetcode.P2053_KthDistinctStringInAnArray;

// https://leetcode.com/problems/kth-distinct-string-in-an-array/description/
public class Solution
{
    public string KthDistinct(string[] arr, int k)
    {
        var counts = new Dictionary<string, int>();

        foreach (var s in arr)
        {
            counts[s] = counts.GetValueOrDefault(s) + 1;
        }

        int distinctCount = 0;
        foreach (var s in arr)
        {
            if (counts[s] == 1)
            {
                distinctCount++;
                if (distinctCount == k)
                {
                    return s;
                }
            }
        }

        return "";
    }
}
