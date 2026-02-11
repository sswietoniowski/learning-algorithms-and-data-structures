namespace neetcode.P2058_FindTheMinimumAndMaximumNumber;

// https://leetcode.com/problems/find-the-minimum-and-maximum-number-of-nodes-between-critical-points/description/
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
    public int[] NodesBetweenCriticalPoints(ListNode head)
    {
        var minDistance = int.MaxValue;
        var firstCriticalIndex = -1;
        var lastCriticalIndex = -1;
        var currentIndex = 0;
        var prev = head;
        var current = head.next;
        while (current.next is not null)
        {
            if (
                (prev.val < current.val && current.val > current.next.val)
                || (prev.val > current.val && current.val < current.next.val)
            )
            {
                if (firstCriticalIndex == -1)
                {
                    firstCriticalIndex = currentIndex;
                    lastCriticalIndex = currentIndex;
                }
                else
                {
                    var currentDistance = currentIndex - lastCriticalIndex;
                    minDistance = Math.Min(currentDistance, minDistance);
                    lastCriticalIndex = currentIndex;
                }
            }
            prev = current;
            current = current.next;
            currentIndex++;
        }

        if (firstCriticalIndex == -1 || lastCriticalIndex - firstCriticalIndex == 0)
        {
            return [-1, -1];
        }
        else
        {
            return [minDistance, lastCriticalIndex - firstCriticalIndex];
        }
    }
}
