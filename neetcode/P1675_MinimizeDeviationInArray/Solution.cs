namespace neetcode.P1669_MergeInBetweenLinkedLists;

// https://leetcode.com/problems/merge-in-between-linked-lists/description/
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
   public ListNode MergeInBetween(ListNode list1, int a, int b, ListNode list2)
   {
       ListNode dummy = new ListNode(0, list1);
       ListNode current = dummy;
       for (int i = 0; i < a; i++)
       {
           current = current.next;
       }
       ListNode tmp = current;
       for (int i = 0; i < (b - a + 1); i++)
       {
           current = current.next;
       }
       ListNode list1End = current.next;
       current = tmp;
       current.next = list2;
       while (current.next != null)
       {
           current = current.next;
       }
       current.next = list1End;
       return dummy.next;
   }
}
*/
// v2
public class Solution
{
    public ListNode MergeInBetween(ListNode list1, int a, int b, ListNode list2)
    {
        ListNode startNode = list1;
        for (int i = 0; i < a - 1; i++)
        {
            startNode = startNode.next;
        }

        ListNode endNode = startNode;
        for (int i = 0; i < (b - a) + 2; i++)
        {
            endNode = endNode.next;
        }

        startNode.next = list2;

        while (list2.next != null)
        {
            list2 = list2.next;
        }

        list2.next = endNode;

        return list1;
    }
}
