namespace neetcode.P1721_SwappingNodesInALinkedList;

// https://leetcode.com/problems/swapping-nodes-in-a-linked-list/description/
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
    public ListNode SwapNodes(ListNode head, int k)
    {
        ListNode firstNode = head;
        ListNode secondNode = head;
        ListNode fast = head;

        for (int i = 1; i < k; i++)
        {
            fast = fast.next;
        }
        firstNode = fast;

        ListNode current = fast;
        while (current.next != null)
        {
            current = current.next;
            secondNode = secondNode.next;
        }

        int temp = firstNode.val;
        firstNode.val = secondNode.val;
        secondNode.val = temp;

        return head;
    }
}
