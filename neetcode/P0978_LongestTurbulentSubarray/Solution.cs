namespace neetcode.P0978_LongestTurbulentSubarray;

// https://leetcode.com/problems/longest-turbulent-subarray/description/
// https://neetcode.io/problems/longest-turbulent-subarray/question?list=neetcode250
public class Solution
{
    public int MaxTurbulenceSize(int[] arr)
    {
        int n = arr.Length;
        if (n < 2)
            return n;

        int maxLen = 1;
        int currentLen = 1;
        int prevSign = 0; // 0: equal, 1: >, -1: <

        for (int i = 1; i < n; i++)
        {
            // Compare current element with previous element
            // Returns 1 if arr[i-1] > arr[i], -1 if arr[i-1] < arr[i], 0 if equal
            int currentSign = arr[i - 1].CompareTo(arr[i]);

            if (currentSign == 0)
            {
                // Equality breaks all turbulence
                currentLen = 1;
            }
            else if (currentSign == -prevSign)
            {
                // The sign flipped! (e.g., previous was > and current is <)
                currentLen++;
            }
            else
            {
                // The sign stayed the same or we just started (prevSign was 0)
                // The current pair still forms a turbulent subarray of size 2
                currentLen = 2;
            }

            maxLen = Math.Max(maxLen, currentLen);
            prevSign = currentSign;
        }

        return maxLen;
    }
}
