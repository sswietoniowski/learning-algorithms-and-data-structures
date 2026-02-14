namespace leetcode.P1290_ConvertBinaryNumber;

// https://leetcode.com/problems/convert-binary-number-in-a-linked-list-to-integer/description/
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
    public int GetDecimalValue(ListNode head)
    {
        ListNode reversedHead = ReverseList(head);
        int number = 0;
        int positionValue = 1;
        ListNode current = reversedHead;
        while (current is not null)
        {
            number += current.val * positionValue;

            current = current.next;
            positionValue *= 2;
        }
        ReverseList(reversedHead);
        return number;
    }

    private ListNode ReverseList(ListNode head)
    {
        ListNode prev = null;
        ListNode current = head;
        while (current is not null)
        {
            ListNode next = current.next;
            current.next = prev;
            prev = current;
            current = next;
        }
        return prev;
    }
}
