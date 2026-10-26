namespace neetcode.P0997_FindTheTownJudge;

public class Solution
{
    public int FindJudge(int n, int[][] trust)
    {
        int[] delta = new int[n + 1];

        foreach (int[] t in trust)
        {
            int a = t[0];
            int b = t[1];
            delta[a]--;
            delta[b]++;
        }

        for (int i = 1; i <= n; i++)
        {
            if (delta[i] == n - 1)
            {
                return i;
            }
        }
        return -1;
    }
}
