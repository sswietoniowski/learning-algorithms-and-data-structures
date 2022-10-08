namespace neetcode.P0098_ValidateBinarySearchTree;

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

// https://leetcode.com/problems/validate-binary-search-tree/
// https://youtu.be/s6ATEkipzow
public class Solution
{
    private bool dfs(TreeNode root, long min, long max)
    {
        if (root == null)
        {
            return true;
        }

        if (root.val <= min || root.val >= max)
        {
            return false;
        }

        return dfs(root.left, min, root.val) && dfs(root.right, root.val, max);
    }

    public bool IsValidBST(TreeNode root)
    {
        return dfs(root, long.MinValue, long.MaxValue);
    }
}