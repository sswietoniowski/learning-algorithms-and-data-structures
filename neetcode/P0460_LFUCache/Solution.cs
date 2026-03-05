namespace neetcode.P0460_LFUCache;

// https://leetcode.com/problems/lfu-cache/description/
// https://neetcode.io/problems/lfu-cache/question
public class LFUCache
{
    // Internal classes to manage the data structure
    private class Node
    {
        public int Key,
            Value,
            Freq;
        public Node Prev,
            Next;

        public Node(int key, int value)
        {
            Key = key;
            Value = value;
            Freq = 1;
        }
    }

    private class DoublyLinkedList
    {
        private Node head,
            tail;
        public int Size;

        public DoublyLinkedList()
        {
            head = new Node(0, 0);
            tail = new Node(0, 0);
            head.Next = tail;
            tail.Prev = head;
            Size = 0;
        }

        public void AddNode(Node node)
        {
            node.Next = head.Next;
            node.Prev = head;
            head.Next.Prev = node;
            head.Next = node;
            Size++;
        }

        public void RemoveNode(Node node)
        {
            node.Prev.Next = node.Next;
            node.Next.Prev = node.Prev;
            Size--;
        }

        public Node RemoveTail()
        {
            if (Size > 0)
            {
                Node node = tail.Prev;
                RemoveNode(node);
                return node;
            }
            return null;
        }
    }

    private int capacity,
        minFreq;
    private Dictionary<int, Node> cache;
    private Dictionary<int, DoublyLinkedList> freqMap;

    public LFUCache(int capacity)
    {
        this.capacity = capacity;
        this.minFreq = 0;
        this.cache = new Dictionary<int, Node>();
        this.freqMap = new Dictionary<int, DoublyLinkedList>();
    }

    public int Get(int key)
    {
        if (!cache.ContainsKey(key))
            return -1;

        Node node = cache[key];
        UpdateFreq(node);
        return node.Value;
    }

    public void Put(int key, int value)
    {
        if (capacity == 0)
            return;

        if (cache.ContainsKey(key))
        {
            Node node = cache[key];
            node.Value = value;
            UpdateFreq(node);
        }
        else
        {
            if (cache.Count >= capacity)
            {
                // Evict the LRU node from the minFreq list
                DoublyLinkedList minFreqList = freqMap[minFreq];
                Node toRemove = minFreqList.RemoveTail();
                cache.Remove(toRemove.Key);
            }

            Node newNode = new Node(key, value);
            cache.Add(key, newNode);
            minFreq = 1; // Reset minFreq for a brand new element

            if (!freqMap.ContainsKey(1))
                freqMap[1] = new DoublyLinkedList();
            freqMap[1].AddNode(newNode);
        }
    }

    private void UpdateFreq(Node node)
    {
        int oldFreq = node.Freq;
        DoublyLinkedList oldList = freqMap[oldFreq];
        oldList.RemoveNode(node);

        // If the current minFreq list becomes empty, increment global minFreq
        if (oldFreq == minFreq && oldList.Size == 0)
        {
            minFreq++;
        }

        node.Freq++;
        if (!freqMap.ContainsKey(node.Freq))
        {
            freqMap[node.Freq] = new DoublyLinkedList();
        }
        freqMap[node.Freq].AddNode(node);
    }
}

/**
 * Your LFUCache object will be instantiated and called as such:
 * LFUCache obj = new LFUCache(capacity);
 * int param_1 = obj.Get(key);
 * obj.Put(key,value);
 */
