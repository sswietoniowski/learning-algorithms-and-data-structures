namespace neetcode.P0701_InsertIntoABST;

// https://leetcode.com/problems/insert-into-a-binary-search-tree/description/
// https://neetcode.io/problems/insert-into-a-binary-search-tree/question?list=neetcode250
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
    public TreeNode InsertIntoBST(TreeNode root, int val)
    {
        if (root == null)
        {
            return new TreeNode(val);
        }

        if (val > root.val)
        {
            root.right = InsertIntoBST(root.right, val);
        }
        else
        {
            root.left = InsertIntoBST(root.left, val);
        }

        return root;
    }
}
