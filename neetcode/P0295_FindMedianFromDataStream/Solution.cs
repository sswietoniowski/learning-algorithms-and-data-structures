namespace neetcode.P0295_FindMedianFromDataStream;

// https://leetcode.com/problems/find-median-from-data-stream/
// https://neetcode.io/problems/find-median-in-a-data-stream?list=neetcode150
public class MedianFinder
{
    private readonly PriorityQueue<int, int> _leftMaxHeap = new();
    private readonly PriorityQueue<int, int> _rightMinHeap = new();

    public MedianFinder() { }

    public void AddNum(int num)
    {
        _leftMaxHeap.Enqueue(num, -num);

        if (
            _leftMaxHeap.Count > 0
            && _rightMinHeap.Count > 0
            && _leftMaxHeap.Peek() > _rightMinHeap.Peek()
        )
        {
            int toRight = _leftMaxHeap.Dequeue();
            _rightMinHeap.Enqueue(toRight, toRight);
        }

        if (_leftMaxHeap.Count > _rightMinHeap.Count + 1)
        {
            int toRight = _leftMaxHeap.Dequeue();
            _rightMinHeap.Enqueue(toRight, toRight);
        }
        else if (_rightMinHeap.Count > _leftMaxHeap.Count + 1)
        {
            int toLeft = _rightMinHeap.Dequeue();
            _leftMaxHeap.Enqueue(toLeft, -toLeft);
        }
    }

    public double FindMedian()
    {
        if (_leftMaxHeap.Count > _rightMinHeap.Count)
        {
            return _leftMaxHeap.Peek();
        }
        else if (_rightMinHeap.Count > _leftMaxHeap.Count)
        {
            return _rightMinHeap.Peek();
        }
        else
        {
            return (_leftMaxHeap.Peek() + _rightMinHeap.Peek()) / 2.0;
        }
    }
}

/**
 * Your MedianFinder object will be instantiated and called as such:
 * MedianFinder obj = new MedianFinder();
 * obj.AddNum(num);
 * double param_2 = obj.FindMedian();
 */
