using System.Runtime.CompilerServices;

namespace neetcode.P0146_LRU_Cache;

// https://leetcode.com/problems/lru-cache/
// https://youtu.be/7ABFKPK2hD4
public class LRUCache
{
    private class Node<TK, TV>
    {
        public TK Key { get; set; }
        public TV Value { get; set; }
        public Node<TK, TV> Next { get; set; }
        public Node<TK, TV> Previous { get; set; }
    }

    private readonly int _capacity;
    private readonly Dictionary<int, Node<int, int>> _cache;
    private readonly Node<int, int> _left; // LRU
    private readonly Node<int, int> _right; // MRU

    public LRUCache(int capacity)
    {
        _capacity = capacity;
        _cache = new Dictionary<int, Node<int, int>>();
        _left = new Node<int, int> { Key = -1, Value = -1 };
        _right = new Node<int, int> { Key = -1, Value = -1 };
        (_left.Next, _right.Previous) = (_right, _left);
    }

    private void Remove(Node<int, int> node)
    {
        var (previous, next) = (node.Previous, node.Next);
        (previous.Next, next.Previous) = (next, previous);
    }

    private void Add(Node<int, int> node)
    {
        var (previous, next) = (_right.Previous, _right);
        (previous.Next, next.Previous) = (node, node);
        (node.Previous, node.Next) = (previous, next);
    }

    public int Get(int key)
    {
        if (_cache.ContainsKey(key))
        {
            var node = _cache[key];
            Remove(node);
            Add(node);
            return node.Value;
        }

        return -1;
    }

    public void Put(int key, int value)
    {
        if (_cache.ContainsKey(key))
        {
            var oldNode = _cache[key];
            Remove(oldNode);
        }
        var newNode = new Node<int, int> { Key = key, Value = value };
        Add(newNode);
        _cache[key] = newNode;
        
        if (_cache.Count > _capacity)
        {
            var lru = _left.Next;
            Remove(lru);
            _cache.Remove(lru.Key);
        }
    }
}

/**
 * Your LRUCache object will be instantiated and called as such:
 * LRUCache obj = new LRUCache(capacity);
 * int param_1 = obj.Get(key);
 * obj.Put(key,value);
 */