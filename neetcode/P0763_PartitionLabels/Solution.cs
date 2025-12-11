namespace neetcode.P0763_PartitionLabels;

// https://leetcode.com/problems/partition-labels/description/
// https://neetcode.io/problems/partition-labels/question?list=neetcode150
public class Solution
{
    public List<int> PartitionLabels(string s)
    {
        Dictionary<char, int> lastIndex = new Dictionary<char, int>();
        for (int i = 0; i < s.Length; i++)
        {
            lastIndex[s[i]] = i;
        }

        List<int> res = new List<int>();
        int size = 0,
            end = 0;
        for (int i = 0; i < s.Length; i++)
        {
            size++;
            end = Math.Max(end, lastIndex[s[i]]);

            if (i == end)
            {
                res.Add(size);
                size = 0;
            }
        }
        return res;
    }
}
