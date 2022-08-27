namespace neetcode.P0021_MergeTwoSortedLists
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

        // https://leetcode.com/problems/merge-two-sorted-lists/
        // https://youtu.be/XIdigk956u0
        public ListNode MergeTwoLists(ListNode list1, ListNode list2)
        {
            // v1
            //ListNode head = null;
            //ListNode currentNode = null;
            //ListNode previousNode = null;

            //while (list1 != null || list2 != null)
            //{
            //    if (list1 == null)
            //    {
            //        currentNode = new ListNode(list2.val, null);
            //        list2 = list2.next;
            //    }
            //    else if (list2 == null)
            //    {
            //        currentNode = new ListNode(list1.val, null);
            //        list1 = list1.next;
            //    }
            //    else if (list1.val <= list2.val)
            //    {
            //        currentNode = new ListNode(list1.val, null);
            //        list1 = list1.next;
            //    }
            //    else
            //    {
            //        currentNode = new ListNode(list2.val, null);
            //        list2 = list2.next;
            //    }

            //    if (head == null)
            //    {
            //        head = currentNode;
            //    }

            //    if (previousNode != null)
            //    {
            //        previousNode.next = currentNode;
            //    }

            //    previousNode = currentNode;
            //}

            //return head;

            // v2
            ListNode dummyHead = new ListNode(0);
            ListNode previousHead = dummyHead;

            while (list1 != null && list2 != null)
            {
                if (list1.val <= list2.val)
                {
                    previousHead.next = list1;
                    list1 = list1.next;
                }
                else
                {
                    previousHead.next = list2;
                    list2 = list2.next;
                }

                previousHead = previousHead.next;
            }

            previousHead.next = list1 == null ? list2 : list1;

            return dummyHead.next;
        }

    }
}
