namespace neetcode.P0225_ImplementStackUsingQueues;

// https://leetcode.com/problems/implement-stack-using-queues/description/
// https://neetcode.io/problems/implement-stack-using-queues/question
// v1
/*
public class MyStack
{
    private Queue<int>[] queues;
    private int activeQueue;

    public MyStack()
    {
        queues = new Queue<int>[2];
        queues[0] = new Queue<int>();
        queues[1] = new Queue<int>();
        activeQueue = 0;
    }

    public void Push(int x)
    {
        int newActiveQueue = (activeQueue + 1) % 2;
        queues[newActiveQueue].Enqueue(x);
        while (queues[activeQueue].Count > 0)
        {
            queues[newActiveQueue].Enqueue(queues[activeQueue].Dequeue());
        }
        activeQueue = newActiveQueue;
    }

    public int Pop()
    {
        return queues[activeQueue].Dequeue();
    }

    public int Top()
    {
        return queues[activeQueue].Peek();
    }

    public bool Empty()
    {
        return queues[activeQueue].Count() == 0;
    }
}
*/
// v2
public class MyStack
{
    private readonly Queue<int> _queue;

    public MyStack()
    {
        _queue = new Queue<int>();
    }

    public void Push(int x)
    {
        int size = _queue.Count;
        _queue.Enqueue(x);

        for (int i = 0; i < size; i++)
        {
            _queue.Enqueue(_queue.Dequeue());
        }
    }

    public int Pop()
    {
        return _queue.Dequeue();
    }

    public int Top()
    {
        return _queue.Peek();
    }

    public bool Empty()
    {
        return _queue.Count == 0;
    }
}


/**
 * Your MyStack object will be instantiated and called as such:
 * MyStack obj = new MyStack();
 * obj.Push(x);
 * int param_2 = obj.Pop();
 * int param_3 = obj.Top();
 * bool param_4 = obj.Empty();
 */
