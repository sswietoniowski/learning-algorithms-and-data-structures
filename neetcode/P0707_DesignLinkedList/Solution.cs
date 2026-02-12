namespace neetcode.P0707_DesignLinkedList;

// https://leetcode.com/problems/design-linked-list/description/
public class ListNode
{
    public int val;
    public ListNode next;

    public ListNode(int val = 0, ListNode next = null)
    {
        this.val = val;
        this.next = next;
    }
}

public class MyLinkedList
{
    ListNode sentinel;
    int size;

    public MyLinkedList()
    {
        sentinel = new ListNode(0) { next = null };
        size = 0;
    }

    public int Get(int index)
    {
        if (index < 0 || index >= size)
            return -1;

        ListNode current = sentinel.next;
        for (int i = 0; i < index; i++)
        {
            current = current.next;
        }
        return current.val;
    }

    public void AddAtHead(int val)
    {
        AddAtIndex(0, val);
    }

    public void AddAtTail(int val)
    {
        AddAtIndex(size, val);
    }

    public void AddAtIndex(int index, int val)
    {
        if (index > size)
            return;
        if (index < 0)
            index = 0;

        ListNode current = sentinel;
        for (int i = 0; i < index; i++)
        {
            current = current.next;
        }

        ListNode node = new ListNode(val, current.next);
        current.next = node;
        size++;
    }

    public void DeleteAtIndex(int index)
    {
        if (index < 0 || index >= size)
            return;

        ListNode current = sentinel;
        for (int i = 0; i < index; i++)
        {
            current = current.next;
        }

        current.next = current.next.next;
        size--;
    }
}

/**
 * Your MyLinkedList object will be instantiated and called as such:
 * MyLinkedList obj = new MyLinkedList();
 * int param_1 = obj.Get(index);
 * obj.AddAtHead(val);
 * obj.AddAtTail(val);
 * obj.AddAtIndex(index,val);
 * obj.DeleteAtIndex(index);
 */
