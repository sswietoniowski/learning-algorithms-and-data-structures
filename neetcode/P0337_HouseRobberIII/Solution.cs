namespace neetcode.P0337_HouseRobberIII;

// https://leetcode.com/problems/house-robber-iii/
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
    public int Rob(TreeNode root)
    {
        var result = Dfs(root);
        return Math.Max(result.withRoot, result.withoutRoot);
    }

    private (int withRoot, int withoutRoot) Dfs(TreeNode root)
    {
        if (root == null)
            return (0, 0);

        var left = Dfs(root.left);
        var right = Dfs(root.right);

        int withRoot = root.val + left.withoutRoot + right.withoutRoot;
        int withoutRoot =
            Math.Max(left.withRoot, left.withoutRoot) + Math.Max(right.withRoot, right.withoutRoot);

        return (withRoot, withoutRoot);
    }
}
