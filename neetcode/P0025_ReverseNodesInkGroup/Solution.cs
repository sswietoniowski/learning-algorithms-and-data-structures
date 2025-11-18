namespace neetcode.P0025_ReverseNodesInkGroup;

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

// https://leetcode.com/problems/reverse-nodes-in-k-group/
// https://neetcode.io/problems/reverse-nodes-in-k-group/question?list=neetcode150
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
    public ListNode ReverseKGroup(ListNode head, int k)
    {
        ListNode dummy = new ListNode(0, head);
        ListNode groupPrev = dummy;

        while (true)
        {
            ListNode kth = GetKth(groupPrev, k);
            if (kth == null)
            {
                break;
            }
            ListNode groupNext = kth.next;

            ListNode prev = kth.next;
            ListNode curr = groupPrev.next;
            while (curr != groupNext)
            {
                ListNode tmp = curr.next;
                curr.next = prev;
                prev = curr;
                curr = tmp;
            }

            ListNode tmpNode = groupPrev.next;
            groupPrev.next = kth;
            groupPrev = tmpNode;
        }
        return dummy.next;
    }

    private ListNode GetKth(ListNode curr, int k)
    {
        while (curr != null && k > 0)
        {
            curr = curr.next;
            k--;
        }
        return curr;
    }
}
