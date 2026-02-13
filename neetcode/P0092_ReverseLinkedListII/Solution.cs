namespace neetcode.P0092_ReverseLinkedListII;

// https://leetcode.com/problems/reverse-linked-list-ii/description/
// https://neetcode.io/problems/reverse-linked-list-ii/question
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
 * public int val;
 * public ListNode next;
 * public ListNode(int val=0, ListNode next=null) {
 * this.val = val;
 * this.next = next;
 * }
 * }
 */
public class Solution
{
    public ListNode ReverseBetween(ListNode head, int left, int right)
    {
        if (head == null || left == right)
        {
            return head;
        }

        ListNode dummy = new ListNode(0);
        dummy.next = head;

        ListNode prev = dummy;
        for (int i = 0; i < left - 1; i++)
        {
            prev = prev.next;
        }

        ListNode curr = prev.next;
        ListNode nextNode = null;

        for (int i = 0; i < right - left; i++)
        {
            nextNode = curr.next;
            curr.next = nextNode.next;
            nextNode.next = prev.next;
            prev.next = nextNode;
        }

        return dummy.next;
    }
}
