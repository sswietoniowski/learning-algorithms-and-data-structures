namespace leetcode.P0700_SearchInABinarySearchTree;

// https://leetcode.com/problems/search-in-a-binary-search-tree/description/
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
    public TreeNode SearchBST(TreeNode root, int val)
    {
        if (root is null)
        {
            return null;
        }

        if (root.left is null && root.right is null)
        {
            if (root.val == val)
            {
                return root;
            }
            else
            {
                return null;
            }
        }

        if (root.val == val)
        {
            return root;
        }
        else if (root.val < val)
        {
            return SearchBST(root.right, val);
        }
        else
        {
            return SearchBST(root.left, val);
        }
    }
}
