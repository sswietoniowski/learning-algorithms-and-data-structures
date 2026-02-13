namespace neetcode.P0061_RotateList;

// https://leetcode.com/problems/rotate-list/description/
// https://neetcode.io/problems/rotate-list/question?list=allNC
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
    public ListNode RotateRight(ListNode head, int k)
    {
        if (head is null)
        {
            return head;
        }

        int n = 1;
        ListNode tail = head;
        while (tail.next is not null)
        {
            n++;
            tail = tail.next;
        }
        tail.next = head;

        int rotate = n - (k % n) - 1;

        tail = head;
        for (int i = 0; i < rotate; i++)
        {
            tail = tail.next;
        }
        head = tail.next;
        tail.next = null;

        return head;
    }
}
