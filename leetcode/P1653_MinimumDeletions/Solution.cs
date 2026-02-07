namespace leetcode.P1653_MinimumDeletions;

// https://leetcode.com/problems/minimum-deletions-to-make-string-balanced/?envType=daily-question&envId=2026-02-07
public class Solution
{
    public int MinimumDeletions(string s)
    {
        int deletions = 0;
        int bCount = 0;

        foreach (char c in s)
        {
            if (c == 'b')
            {
                bCount++;
            }
            else
            {
                if (bCount > 0)
                {
                    deletions = Math.Min(deletions + 1, bCount);
                }
            }
        }

        return deletions;
    }
}
