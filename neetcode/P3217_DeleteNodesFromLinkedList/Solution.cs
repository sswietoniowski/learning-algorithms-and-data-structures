namespace neetcode.P3217_DeleteNodesFromLinkedList;

// https://leetcode.com/problems/delete-nodes-from-linked-list-present-in-array/description/
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
    public ListNode ModifiedList(int[] nums, ListNode head)
    {
        var numSet = new HashSet<int>(nums);

        var sentinel = new ListNode(0, head);
        var current = sentinel;

        while (current.next != null)
        {
            if (numSet.Contains(current.next.val))
            {
                current.next = current.next.next;
            }
            else
            {
                current = current.next;
            }
        }

        return sentinel.next;
    }
}
