namespace neetcode.P0703_KthLargestElementInAStream
{
    public class MinBinaryHeap
    {
        public MinBinaryHeap(int[] input, int length)
        {
            this.Length = 0;
            this._array = new int[Math.Max(length + 1, input.Length)];
            for (int i = 0; i < input.Length; i++)
            {
                Add(input[i]);
            }
        }

        private int[] _array { get; set; }

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
            if (left <= this.Length && this._array[left - 1] < this._array[index - 1])
            {
                Min = left;
            }

            if (right <= this.Length && this._array[right - 1] < this._array[Min - 1])
            {
                Min = right;
            }

            if (Min != index)
            {
                int temp = this._array[Min - 1];
                this._array[Min - 1] = this._array[index - 1];
                this._array[index - 1] = temp;
                MinHeapify(Min);
            }

            return;
        }

        public int RemoveMinimum()
        {
            int Minimum = this._array[0];

            this._array[0] = this._array[this.Length - 1];
            this.Length--;
            MinHeapify(1);
            return Minimum;
        }

        public int Peek()
        {
            return this._array[0];
        }

        public void Add(int value)
        {
            this.Length++;
            this._array[this.Length - 1] = value;
            int index = this.Length - 1;
            while (index > 0 && this._array[index] < this._array[(index - 1) / 2])
            {
                int temp = this._array[index];
                this._array[index] = this._array[(index - 1) / 2];
                this._array[(index - 1) / 2] = temp;
                index = (index - 1) / 2;
            }
        }
    }

    // v1
    // https://leetcode.com/problems/kth-largest-element-in-a-stream/
    // https://youtu.be/hOjcdrqMoQ8
    //public class KthLargest
    //{
    //    private readonly int _k;
    //    private readonly MinBinaryHeap _minBinaryHeap;

    //    public KthLargest(int k, int[] nums)
    //    {
    //        _k = k;
    //        _minBinaryHeap = new MinBinaryHeap(nums, nums.Length);
    //        while (_minBinaryHeap.Length > _k)
    //        {
    //            _minBinaryHeap.RemoveMinimum();
    //        }
    //    }

    //    public int Add(int val)
    //    {
    //        _minBinaryHeap.Add(val);
    //        while (_minBinaryHeap.Length > _k)
    //        {
    //            _minBinaryHeap.RemoveMinimum();
    //        }
    //        return _minBinaryHeap.Peek();
    //    }
    //}

    // v2
    public class KthLargest
    {
        private readonly int _k;
        private readonly PriorityQueue<int, int> _priorityQueue;

        public KthLargest(int k, int[] nums)
        {
            _priorityQueue = new PriorityQueue<int, int>(Math.Max(nums.Length, k + 1));
            _k = k;
            for (int i = 0; i < nums.Length; i++)
            {
                _priorityQueue.Enqueue(nums[i], nums[i]);
            }
            while (_priorityQueue.Count > k)
            {
                _priorityQueue.Dequeue();
            }
        }

        public int Add(int val)
        {
            _priorityQueue.Enqueue(val, val);
            while (_priorityQueue.Count > _k)
            {
                _priorityQueue.Dequeue();
            }
            return _priorityQueue.Peek();
        }
    }

    /**
     * Your KthLargest object will be instantiated and called as such:
     * KthLargest obj = new KthLargest(k, nums);
     * int param_1 = obj.Add(val);
     */
}
