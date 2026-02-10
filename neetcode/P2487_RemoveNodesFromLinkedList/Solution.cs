namespace neetcode.P2487_RemoveNodesFromLinkedList;

// https://leetcode.com/problems/remove-nodes-from-linked-list/description/
// https://neetcode.io/problems/append-characters-to-string-to-make-subsequence/question?list=allNC
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

/**
 * Definition for singly-linked list.
 * public class ListNode {
 *     public int val;
 *     public ListNode next;
 *     public ListNode(int val=0, ListNode next=null) {
 *         this.val = val;
 *         this.next = next;
 *     }
 * }
 */
public class Solution
{
    public ListNode RemoveNodes(ListNode head)
    {
        if (head == null)
            return null;

        ListNode reversedHead = ReverseNodes(head);
        ListNode current = reversedHead;
        while (current.next != null)
        {
            if (current.val > current.next.val)
            {
                current.next = current.next.next;
            }
            else
            {
                current = current.next;
            }
        }
        return ReverseNodes(reversedHead);
    }

    private ListNode ReverseNodes(ListNode head)
    {
        ListNode previous = null;
        ListNode current = head;

        while (current != null)
        {
            ListNode tmp = current.next;
            current.next = previous;
            previous = current;
            current = tmp;
        }
        return previous;
    }
}
