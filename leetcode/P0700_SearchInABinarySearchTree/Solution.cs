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
// v1
/*
public class Solution
{
   public TreeNode SearchBST(TreeNode root, int val)
   {
       if (root == null || root.val == val)
           return root;

       return val < root.val ? SearchBST(root.left, val) : SearchBST(root.right, val);
   }
}
*/
// v2
public class Solution
{
    public TreeNode SearchBST(TreeNode root, int val)
    {
        TreeNode current = root;

        while (current is not null)
        {
            if (current.val == val)
            {
                return current;
            }

            current = (val < current.val) ? current.left : current.right;
        }

        return null;
    }
}
