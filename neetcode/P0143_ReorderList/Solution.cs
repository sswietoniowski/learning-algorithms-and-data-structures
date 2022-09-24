namespace neetcode.P0143_ReorderList;

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


// https://leetcode.com/problems/reorder-list/
// https://youtu.be/S5bfdUTrKLM
public class Solution
{
    public void ReorderList(ListNode head)
    {
        if (head == null || head.next == null)
        {
            return;
        }

        ListNode slow = head;
        ListNode fast = head.next;

        while (fast != null && fast.next != null)
        {
            slow = slow.next;
            fast = fast.next.next;
        }

        ListNode secondHalf = slow.next;

        slow.next = null;

        ListNode previousNode = null;
        while (secondHalf != null)
        {
            ListNode tmp = secondHalf.next;
            secondHalf.next = previousNode;
            previousNode = secondHalf;
            secondHalf = tmp;
        }

        ListNode firstHalf = head;

        while (firstHalf != null && previousNode != null)
        {
            ListNode tmp = firstHalf.next;
            firstHalf.next = previousNode;
            previousNode = previousNode.next;
            firstHalf.next.next = tmp;
            firstHalf = tmp;
        }
    }
}