namespace neetcode.P1046_LastStoneWeight
{
    // https://leetcode.com/problems/last-stone-weight/
    // https://youtu.be/B-QCq79-Vfw
    public class Solution
    {
        public int LastStoneWeight(int[] stones)
        {
            var pq = new PriorityQueue<int, int>();
            foreach (var stone in stones)
            {
                pq.Enqueue(stone, -stone);
            }
            while (pq.Count > 1)
            {
                var a = pq.Dequeue();
                var b = pq.Dequeue();
                if (a != b)
                {
                    pq.Enqueue(a - b, -(a - b));
                }
            }
            return pq.Count == 0 ? 0 : pq.Dequeue();
        }
    }
}
