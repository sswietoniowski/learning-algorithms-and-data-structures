namespace neetcode.P0703_KthLargestElementInAStream
{
    // 
    // https://pragmaticdevs.wordpress.com/2015/09/15/heap-data-structure-using-c/
    public class MinHeap
    {
        public MinHeap(int[] input, int length)
        {

            this.Length = length;
            this.Array = input;
            BuildMinHeap();
        }

        public int[] Array { get; private set; }

        public int Length { get; private set; }

        private void BuildMinHeap()
        {
            for (int i = this.Length / 2; i > 0; i--)
            {
                MinHeapify(i);
            }

            return;
        }

        public void MinHeapify(int index)
        {
            var left = 2 * index;
            var right = 2 * index + 1;

            int Min = index;
            if (left <= this.Length && this.Array[left - 1] < this.Array[index - 1])
            {
                Min = left;
            }

            if (right <= this.Length && this.Array[right - 1] < this.Array[Min - 1])
            {
                Min = right;
            }

            if (Min != index)
            {
                int temp = this.Array[Min - 1];
                this.Array[Min - 1] = this.Array[index - 1];
                this.Array[index - 1] = temp;
                MinHeapify(Min);
            }

            return;
        }

        public int RemoveMinimum()
        {
            int Minimum = this.Array[0];

            this.Array[0] = this.Array[this.Length - 1];
            this.Length--;
            MinHeapify(1);
            return Minimum;
        }
    }

    // https://leetcode.com/problems/kth-largest-element-in-a-stream/
    // https://youtu.be/hOjcdrqMoQ8
    public class KthLargest
    {
        private readonly int _k;
        private readonly MinHeap _minHeap;

        public KthLargest(int k, int[] nums)
        {
            _k = k;
            _minHeap = new MinHeap(nums, nums.Length);
            while (_minHeap.Length > _k)
            {
                _minHeap.RemoveMinimum();
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
