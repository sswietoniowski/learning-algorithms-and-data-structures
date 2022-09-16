namespace neetcode.P0155_MinStack;

// https://leetcode.com/problems/min-stack/
// https://youtu.be/qkLl7nAwDPo
public class MinStack
{
    private readonly Stack<int> _stack = new();
    private readonly Stack<int> _minStack = new();
    
    public MinStack()
    {
    }

    public void Push(int val)
    {
        _stack.Push(val);
        if (_minStack.Count == 0 || val <= _minStack.Peek())
        {
            _minStack.Push(val);
        }
    }

    public void Pop()
    {
        var val = _stack.Pop();
        if (val == _minStack.Peek())
        {
            _minStack.Pop();
        }
    }

    public int Top()
    {
        return _stack.Peek();
    }

    public int GetMin()
    {
        return _minStack.Peek();
    }
}

/**
 * Your MinStack object will be instantiated and called as such:
 * MinStack obj = new MinStack();
 * obj.Push(val);
 * obj.Pop();
 * int param_3 = obj.Top();
 * int param_4 = obj.GetMin();
 */