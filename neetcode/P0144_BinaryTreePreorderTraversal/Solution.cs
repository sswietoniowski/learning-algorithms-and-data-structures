namespace neetcode.P0144_BinaryTreePreorderTraversal;

// https://leetcode.com/problems/binary-tree-preorder-traversal/description/
// https://neetcode.io/problems/binary-tree-preorder-traversal/question?list=neetcode250
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
public class Solution
{
    public IList<int> PreorderTraversal(TreeNode root)
    {
        var result = new List<int>();

        if (root is null)
        {
            return result;
        }

        Stack<TreeNode> stack = new();
        TreeNode current = null;

        stack.Push(root);
        while (stack.Count > 0)
        {
            current = stack.Pop();
            result.Add(current.val);

            if (current.right is not null)
            {
                stack.Push(current.right);
            }
            if (current.left is not null)
            {
                stack.Push(current.left);
            }
        }

        return result;
    }
}
