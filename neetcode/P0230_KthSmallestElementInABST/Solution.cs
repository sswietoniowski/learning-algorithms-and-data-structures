using System.ComponentModel.Design;

namespace neetcode.P0230_KthSmallestElementInABST;

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

// https://leetcode.com/problems/kth-smallest-element-in-a-bst/
// https://youtu.be/5LUXSvjmGCw
public class Solution
{
    private int dfs(TreeNode root, int k, ref int count)
    {
        if (root == null)
            return -1;

        var left = dfs(root.left, k, ref count);
        if (left != -1)
            return left;

        count++;
        if (count == k)
            return root.val;

        var right = dfs(root.right, k, ref count);
        if (right != -1)
            return right;

        return -1;
    }


    public int KthSmallest(TreeNode root, int k)
    {
        int count = 0;

        return dfs(root, k, ref count);
    }
}