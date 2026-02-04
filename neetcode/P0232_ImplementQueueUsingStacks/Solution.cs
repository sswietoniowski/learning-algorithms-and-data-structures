namespace neetcode.P0232_ImplementQueueUsingStacks;

// https://leetcode.com/problems/implement-queue-using-stacks/description/
// https://neetcode.io/problems/implement-queue-using-stacks/question?list=allNC
// v1
/*
public class MyQueue
{
    private Stack<int> activeStack = new();

    public MyQueue() { }

    public void Push(int x)
    {
        Stack<int> temporaryStack = new();
        while (activeStack.Count > 0)
        {
            temporaryStack.Push(activeStack.Pop());
        }
        temporaryStack.Push(x);
        while (temporaryStack.Count > 0)
        {
            activeStack.Push(temporaryStack.Pop());
        }
    }

    public int Pop()
    {
        return activeStack.Pop();
    }

    public int Peek()
    {
        return activeStack.Peek();
    }

    public bool Empty()
    {
        return activeStack.Count == 0;
    }
}
*/
// v2
public class MyQueue
{
    private readonly Stack<int> _stackIn = new();
    private readonly Stack<int> _stackOut = new();

    public MyQueue() { }

    public void Push(int x)
    {
        _stackIn.Push(x);
    }

    public int Pop()
    {
        EnsureStackOutHasData();
        return _stackOut.Pop();
    }

    public int Peek()
    {
        EnsureStackOutHasData();
        return _stackOut.Peek();
    }

    public bool Empty()
    {
        return _stackIn.Count == 0 && _stackOut.Count == 0;
    }

    private void EnsureStackOutHasData()
    {
        if (_stackOut.Count == 0)
        {
            while (_stackIn.Count > 0)
            {
                _stackOut.Push(_stackIn.Pop());
            }
        }
    }
}


/**
 * Your MyQueue object will be instantiated and called as such:
 * MyQueue obj = new MyQueue();
 * obj.Push(x);
 * int param_2 = obj.Pop();
 * int param_3 = obj.Peek();
 * bool param_4 = obj.Empty();
 */
