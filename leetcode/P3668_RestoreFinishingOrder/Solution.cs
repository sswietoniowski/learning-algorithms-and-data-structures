namespace leetcode.P3668_RestoreFinishingOrder;

// https://leetcode.com/problems/restore-finishing-order/description/
public class Solution
{
    public int[] RecoverOrder(int[] order, int[] friends)
    {
        var result = new int[friends.Length];
        var set = new HashSet<int>();
        foreach (var f in friends)
        {
            set.Add(f);
        }
        int i = 0;
        foreach (var o in order)
        {
            if (set.Contains(o))
            {
                result[i] = o;
                i++;
            }
        }
        return result;
    }
}
