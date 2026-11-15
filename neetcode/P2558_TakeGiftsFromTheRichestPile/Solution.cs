namespace neetcode.P2558_TakeGiftsFromTheRichestPile;

public class Solution
{
    public long PickGifts(int[] gifts, int k)
    {
        var pq = new PriorityQueue<int, int>();

        foreach (var g in gifts)
        {
            pq.Enqueue(g, -g);
        }

        for (int t = 0; t < k; t++)
        {
            int n = pq.Dequeue();
            pq.Enqueue((int)Math.Floor(Math.Sqrt(n)), -(int)Math.Floor(Math.Sqrt(n)));
        }

        long sum = 0;
        while (pq.Count > 0)
        {
            sum += pq.Dequeue();
        }
        return sum;
    }
}
