namespace neetcode.P1325_DeleteLeavesWithAGivenValue;

// https://leetcode.com/problems/delete-leaves-with-a-given-value/
/**
 * Definition for a binary tree node.
 * public class TreeNode {
 *     public int val;
 *     public TreeNode left;
 *     public TreeNode right;
 *     public TreeNode(int val=0, TreeNode left=null, TreeNode right=null) {
 *         this.val = val;
 *         this.left = left;
 *         this.right = right;
 *     }
 * }
 */

public class TreeNode
{
    public int val;
    public TreeNode left;
    public TreeNode right;

    public TreeNode(int val = 0, TreeNode left = null, TreeNode right = null)
    {
        this.val = val;
        this.left = left;
        this.right = right;
    }
}

public class Solution
{
    public TreeNode RemoveLeafNodes(TreeNode root, int target)
    {
        if (root == null)
            return null;

        Stack<TreeNode> stack = new Stack<TreeNode>();
        TreeNode cur = root;
        TreeNode visited = null;

        while (stack.Count > 0 || cur != null)
        {
            while (cur != null)
            {
                stack.Push(cur);
                cur = cur.left;
            }

            cur = stack.Peek();
            if (cur.right != null && cur.right != visited)
            {
                cur = cur.right;
                continue;
            }

            stack.Pop();
            if (cur.left == null && cur.right == null && cur.val == target)
            {
                if (stack.Count == 0)
                    return null;

                TreeNode parent = stack.Peek();
                if (parent.left == cur)
                {
                    parent.left = null;
                }
                else if (parent.right == cur)
                {
                    parent.right = null;
                }
            }
            else
            {
                visited = cur;
            }

            cur = null;
        }

        return root;
    }
}
