namespace neetcode.P0083_RemoveDuplicatesFromSortedList;

// https://leetcode.com/problems/remove-duplicates-from-sorted-list/description/
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

// v1
/*
public class Solution
{
    public ListNode DeleteDuplicates(ListNode head)
    {
        ListNode dummy = new ListNode(int.MinValue, head);
        ListNode current = dummy;
        while (current.next is not null)
        {
            if (current.val == current.next.val)
            {
                current.next = current.next.next;
            }
            else
            {
                current = current.next;
            }
        }
        return dummy.next;
    }
}
*/
// v2
public class Solution
{
    public ListNode DeleteDuplicates(ListNode head)
    {
        if (head is null || head.next is null)
        {
            return head;
        }
        ListNode current = head;
        while (current.next is not null)
        {
            if (current.val == current.next.val)
            {
                current.next = current.next.next;
            }
            else
            {
                current = current.next;
            }
        }
        return head;
    }
}
