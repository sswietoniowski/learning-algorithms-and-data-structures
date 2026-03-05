namespace leetcode.P1758_MinimumChanges;

// https://leetcode.com/problems/minimum-changes-to-make-alternating-binary-string/description/?envType=daily-question&envId=2026-03-05
public class Solution
{
    public int MinOperations(string s)
    {
        int count0 = 0;
        int n = s.Length;

        for (int i = 0; i < n; i++)
        {
            if (i % 2 == 0)
            {
                if (s[i] != '0')
                    count0++;
            }
            else
            {
                if (s[i] != '1')
                    count0++;
            }
        }

        return Math.Min(count0, n - count0);
    }
}
