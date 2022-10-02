namespace neetcode.P0100_SameTree;

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


// https://leetcode.com/problems/same-tree/
// https://youtu.be/vRbbcKXCxOw
public class Solution
{
    private bool dfs(TreeNode p, TreeNode q)
    {
        if (p == null && q == null)
        {
            return true;
        }
        else if (p == null || q == null)
        {
            return false;
        }
        else if (p.val != q.val)
        {
            return false;
        }
        else
        {
            return dfs(p.left, q.left) && dfs(p.right, q.right);
        }
    }
    
    public bool IsSameTree(TreeNode p, TreeNode q)
    {
        return dfs(p, q);
    }
}