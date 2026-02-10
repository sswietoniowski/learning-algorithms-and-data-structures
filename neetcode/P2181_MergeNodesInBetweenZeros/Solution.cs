namespace neetcode.P2181_MergeNodesInBetweenZeros;

// https://leetcode.com/problems/merge-nodes-in-between-zeros/description/
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
    public ListNode MergeNodes(ListNode head)
    {
        ListNode write = head;
        ListNode read = head.next;
        int currentSum = 0;
        while (read != null)
        {
            if (read.val == 0)
            {
                write.val = currentSum;
                currentSum = 0;
                write.next = read.next;
                write = write.next;
            }
            else
            {
                currentSum += read.val;
            }

            read = read.next;
        }
        return head;
    }
}
