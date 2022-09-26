namespace neetcode.P0138_CopyListWithRandomPointer;

public class Node
{
    public int val;
    public Node next;
    public Node random;

    public Node(int _val)
    {
        val = _val;
        next = null;
        random = null;
    }
}

/*
// Definition for a Node.
public class Node {
public int val;
public Node next;
public Node random;

public Node(int _val) {
    val = _val;
    next = null;
    random = null;
}
}
*/

// https://leetcode.com/problems/copy-list-with-random-pointer/
// https://youtu.be/5Y2EiZST97Y
public class Solution
{
    public Node CopyRandomList(Node head)
    {
        if (head == null)
        {
            return null;
        }

        Dictionary<Node, Node> oldToCopy = new();

        Node current = head;

        while (current != null)
        {
            Node newNode = new Node(current.val);
            oldToCopy.Add(current, newNode);
            current = current.next;
        }

        current = head;

        while (current != null)
        {
            Node newNode = oldToCopy[current];
            newNode.next = current.next != null ? oldToCopy.GetValueOrDefault(current.next) : null;
            newNode.random = current.random != null ? oldToCopy.GetValueOrDefault(current.random) : null;
            current = current.next;
        }

        return oldToCopy.GetValueOrDefault(head);
    }
}