namespace neetcode.P0105_ConstructBinaryTreeFromPreorderAndInorderTraversal;

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

// https://leetcode.com/problems/construct-binary-tree-from-preorder-and-inorder-traversal/
// https://youtu.be/ihj4IQGZ2zc
public class Solution
{
    private TreeNode BuildTree(int[] preorder, int[] inorder, int preorderStart, int preorderEnd, int inorderStart, int inorderEnd)
    {
        if (preorderStart > preorderEnd || inorderStart > inorderEnd)
        {
            return null;
        }

        var root = new TreeNode(preorder[preorderStart]);
        var rootIndex = -1;
        for (var i = inorderStart; i <= inorderEnd; i++)
        {
            if (inorder[i] == root.val)
            {
                rootIndex = i;
                break;
            }
        }

        var leftSubtreeSize = rootIndex - inorderStart;
        root.left = BuildTree(preorder, inorder, preorderStart + 1, preorderStart + leftSubtreeSize, inorderStart, rootIndex - 1);
        root.right = BuildTree(preorder, inorder, preorderStart + leftSubtreeSize + 1, preorderEnd, rootIndex + 1, inorderEnd);
        return root;
    }

    public TreeNode BuildTree(int[] preorder, int[] inorder)
    {
        return BuildTree(preorder, inorder, 0, preorder.Length - 1, 0, inorder.Length - 1);
    }
}