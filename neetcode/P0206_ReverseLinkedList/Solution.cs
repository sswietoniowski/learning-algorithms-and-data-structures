namespace neetcode.P0206_ReverseLinkedList
{
    public class Solution
    {
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

        // https://leetcode.com/problems/reverse-linked-list/
        // https://youtu.be/G0_I-ZF0S38
        public ListNode ReverseList(ListNode head)
        {
            ListNode oldHead = null;
            ListNode newHead = null;

            while (head != null)
            {
                oldHead = newHead;
                newHead = new ListNode()
                {
                    val = head.val,
                    next = oldHead
                };

                head = head.next;
            }

            return newHead;
        }

    }
}
