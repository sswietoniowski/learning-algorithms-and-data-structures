namespace leetcode.P0083_RemoveDuplicatesFromSortedList;

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

public class Solution
{
    public ListNode DeleteDuplicates(ListNode head)
    {
        if (head == null)
        {
            return head;
        }

        ListNode previous = head;
        ListNode current = head.next;

        while (current != null)
        {
            if (current.val == previous.val)
            {
                previous.next = current.next;
            }
            else
            {
                previous = current;
            }

            current = current.next;
        }

        return head;
    }
}