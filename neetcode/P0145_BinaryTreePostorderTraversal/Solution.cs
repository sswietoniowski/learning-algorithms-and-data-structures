namespace neetcode.P0145_BinaryTreePostorderTraversal;

// https://leetcode.com/problems/binary-tree-postorder-traversal/description/
// https://neetcode.io/problems/binary-tree-postorder-traversal/question
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
    public IList<int> PostorderTraversal(TreeNode root)
    {
        var result = new List<int>();
        Stack<TreeNode> stack = new();
        TreeNode current = root;
        while (current is not null || stack.Count > 0)
        {
            if (current is not null)
            {
                result.Add(current.val);
                stack.Push(current);
                current = current.right;
            }
            else
            {
                current = stack.Pop();
                current = current.left;
            }
        }

        result.Reverse();
        return result;
    }
}
