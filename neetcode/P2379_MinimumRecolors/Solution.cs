namespace neetcode.P2379_MinimumRecolors;

// https://leetcode.com/problems/minimum-recolors-to-get-k-consecutive-black-blocks/description/
// https://neetcode.io/problems/minimum-recolors-to-get-k-consecutive-black-blocks/question?list=allNC
public class Solution
{
    public int MinimumRecolors(string blocks, int k)
    {
        int count_w = 0;
        for (int i = 0; i < k; i++)
        {
            if (blocks[i] == 'W')
            {
                count_w++;
            }
        }

        int res = count_w;
        for (int i = k; i < blocks.Length; i++)
        {
            if (blocks[i - k] == 'W')
            {
                count_w--;
            }
            if (blocks[i] == 'W')
            {
                count_w++;
            }
            res = Math.Min(res, count_w);
        }

        return res;
    }
}
