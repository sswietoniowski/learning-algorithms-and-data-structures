namespace neetcode.P0901_OnlineStockSpan;

// https://leetcode.com/problems/online-stock-span/description/
// https://neetcode.io/problems/online-stock-span/question?list=neetcode250
public class StockSpanner
{
    private Stack<(int price, int span)> _stack;

    public StockSpanner()
    {
        _stack = new Stack<(int price, int span)>();
    }

    public int Next(int price)
    {
        int currentSpan = 1;

        while (_stack.Count > 0 && _stack.Peek().price <= price)
        {
            currentSpan += _stack.Pop().span;
        }

        _stack.Push((price, currentSpan));

        return currentSpan;
    }
}

/**
 * Your StockSpanner object will be instantiated and called as such:
 * StockSpanner obj = new StockSpanner();
 * int param_1 = obj.Next(price);
 */
