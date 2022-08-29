namespace neetcode.P0703_KthLargestElementInAStream
{
    public class KthLargest
    {
        private readonly int _k;
        private readonly int[] _nums;
        private readonly PriorityQueue<int, int> priorityQueue = new();

        public KthLargest(int k, int[] nums)
        {
            _k = k;
            foreach (var num in nums)
            {
                priorityQueue.Enqueue(num, num);
            }
        }

        public int Add(int val)
        {
            priorityQueue.Enqueue(val, val);
            return 0;
        }
    }

    /**
     * Your KthLargest object will be instantiated and called as such:
     * KthLargest obj = new KthLargest(k, nums);
     * int param_1 = obj.Add(val);
     */
}
