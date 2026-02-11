namespace neetcode.P2130_MaximumTwinSumOfALinkedList;

// https://leetcode.com/problems/maximum-twin-sum-of-a-linked-list/description/
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
// v1
/*
public class Solution
{
   public int PairSum(ListNode head)
   {
       ListNode middle = GetSecondHalfStart(head);
       var current = head;
       ListNode reversedHead = ReverseList(middle);
       var reversedCurrent = reversedHead;
       int maximumTwinSum = int.MinValue;
       while (reversedCurrent != null)
       {
           maximumTwinSum = Math.Max(current.val + reversedCurrent.val, maximumTwinSum);
           current = current.next;
           reversedCurrent = reversedCurrent.next;
       }
       ReverseList(reversedHead); // restore original structure
       return maximumTwinSum;
   }

   private ListNode GetSecondHalfStart(ListNode head)
   {
       ListNode slow = head;
       ListNode fast = head;
       while (fast != null && fast.next != null)
       {
           slow = slow.next;
           fast = fast.next.next;
       }
       return slow;
   }

   private ListNode ReverseList(ListNode head)
   {
       ListNode prev = null;
       ListNode current = head;
       while (current != null)
       {
           ListNode nextTemp = current.next;
           current.next = prev;
           prev = current;
           current = nextTemp;
       }
       return prev;
   }
}
*/
// v2
public class Solution
{
    public int PairSum(ListNode head)
    {
        ListNode middle = GetSecondHalfStart(head);
        var current = head;
        ListNode reversedHead = ReverseList(middle);
        var reversedCurrent = reversedHead;
        int maximumTwinSum = int.MinValue;
        while (reversedCurrent != null)
        {
            maximumTwinSum = Math.Max(current.val + reversedCurrent.val, maximumTwinSum);
            current = current.next;
            reversedCurrent = reversedCurrent.next;
        }
        ReverseList(reversedHead); // restore original structure
        return maximumTwinSum;
    }

    private ListNode GetSecondHalfStart(ListNode head)
    {
        ListNode slow = head;
        ListNode fast = head;
        while (fast != null && fast.next != null)
        {
            slow = slow.next;
            fast = fast.next.next;
        }
        return slow;
    }

    private ListNode ReverseList(ListNode head)
    {
        ListNode prev = null;
        ListNode current = head;
        while (current != null)
        {
            ListNode nextTemp = current.next;
            current.next = prev;
            prev = current;
            current = nextTemp;
        }
        return prev;
    }
}
