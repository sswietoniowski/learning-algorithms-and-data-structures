namespace neetcode.P0622_DesignCircularQueue;

// https://leetcode.com/problems/design-circular-queue/description/
// https://neetcode.io/problems/design-circular-queue/question?list=neetcode250
public class MyCircularQueue
{
    private int[] data;
    private int head;
    private int count;
    private int capacity;

    public MyCircularQueue(int k)
    {
        this.capacity = k;
        this.data = new int[k];
        this.head = 0;
        this.count = 0;
    }

    public bool EnQueue(int value)
    {
        if (IsFull())
            return false;

        // Calculate the tail position: (head + count) % capacity
        int tail = (head + count) % capacity;
        data[tail] = value;
        count++;
        return true;
    }

    public bool DeQueue()
    {
        if (IsEmpty())
            return false;

        // Move the head forward and reduce the count
        head = (head + 1) % capacity;
        count--;
        return true;
    }

    public int Front()
    {
        if (IsEmpty())
            return -1;
        return data[head];
    }

    public int Rear()
    {
        if (IsEmpty())
            return -1;
        // The tail is the index of the last element added
        int tail = (head + count - 1) % capacity;
        return data[tail];
    }

    public bool IsEmpty()
    {
        return count == 0;
    }

    public bool IsFull()
    {
        return count == capacity;
    }
}

/**
 * Your MyCircularQueue object will be instantiated and called as such:
 * MyCircularQueue obj = new MyCircularQueue(k);
 * bool param_1 = obj.EnQueue(value);
 * bool param_2 = obj.DeQueue();
 * int param_3 = obj.Front();
 * int param_4 = obj.Rear();
 * bool param_5 = obj.IsEmpty();
 * bool param_6 = obj.IsFull();
 */
