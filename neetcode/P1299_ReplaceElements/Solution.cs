namespace neetcode.P1299_ReplaceElements;

// https://leetcode.com/problems/replace-elements-with-greatest-element-on-right-side/description/
// https://neetcode.io/problems/replace-elements-with-greatest-element-on-right-side/question
public class Solution
{
    public int[] ReplaceElements(int[] arr)
    {
        int n = arr.Length;
        int[] ans = new int[n];
        int max = arr[n - 1];

        ans[n - 1] = -1;
        for (int i = n - 2; i >= 0; i--)
        {
            ans[i] = max;
            max = Math.Max(max, arr[i]);
        }

        return ans;
    }
}
