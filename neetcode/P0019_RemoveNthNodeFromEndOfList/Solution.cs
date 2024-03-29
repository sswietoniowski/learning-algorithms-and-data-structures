﻿namespace neetcode.P0019_RemoveNthNodeFromEndOfList;

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

// https://leetcode.com/problems/remove-nth-node-from-end-of-list/
// https://youtu.be/XVuQxVej6y8
public class Solution
{
    public ListNode RemoveNthFromEnd(ListNode head, int n)
    {
        // v1
        ListNode left = head;
        ListNode right = head;

        for (int i = 0; i < n; i++)
        {
            right = right.next;
        }

        if (right == null)
        {
            return head.next;
        }

        while (right.next != null)
        {
            left = left.next;
            right = right.next;
        }

        left.next = left.next.next;

        return head;

        // v2
        //ListNode dummy = new ListNode(0, head);
        //ListNode left = dummy;
        //ListNode right = head;

        //int i = n;
        //while (i > 0 && right != null)
        //{
        //    right = right.next;
        //    i--;
        //}

        //while (right != null)
        //{
        //    left = left.next;
        //    right = right.next;
        //}

        //left.next = left.next.next;

        //return dummy.next;
    }
}