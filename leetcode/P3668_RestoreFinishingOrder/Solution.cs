namespace leetcode.P3668_RestoreFinishingOrder;

// https://leetcode.com/problems/restore-finishing-order/description/
// v1
/*
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
*/
// v2
public class Solution
{
    public int[] RecoverOrder(int[] order, int[] friends)
    {
        int friendCount = friends.Length;
        var result = new int[friendCount];

        bool[] isFriend = new bool[101];
        foreach (int f in friends)
        {
            isFriend[f] = true;
        }

        int found = 0;
        foreach (int person in order)
        {
            if (isFriend[person])
            {
                result[found++] = person;

                if (found == friendCount)
                    break;
            }
        }

        return result;
    }
}
