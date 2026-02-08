namespace neetcode.P0110_BalancedBinaryTree;

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

// https://leetcode.com/problems/balanced-binary-tree/
// https://youtu.be/QfJsau0ItOY
// v1
/*
public class Solution
{
    private (bool, int) dfs(TreeNode root)
    {
        if (root is null)
        {
            return (true, 0);
        }

        var (leftBalanced, leftHeight) = dfs(root.left);
        var (rightBalanced, rightHeight) = dfs(root.right);

        var balanced = leftBalanced && rightBalanced && Math.Abs(leftHeight - rightHeight) <= 1;

        return (balanced, Math.Max(leftHeight, rightHeight) + 1);
    }
    
    public bool IsBalanced(TreeNode root)
    {
        var (balanced, _) = dfs(root);
        return balanced;
    }
}
*/
// v2
public class Solution
{
    private (bool, int) dfs(TreeNode root)
    {
        if (root is null)
        {
            return (true, 0);
        }

        var (leftBalanced, leftHeight) = dfs(root.left);
        // Optimization: Stop immediately if left is bad
        if (!leftBalanced)
            return (false, 0);

        var (rightBalanced, rightHeight) = dfs(root.right);
        // Optimization: Stop immediately if right is bad
        if (!rightBalanced)
            return (false, 0);

        // Now we only need to check the height difference
        bool balanced = Math.Abs(leftHeight - rightHeight) <= 1;

        return (balanced, Math.Max(leftHeight, rightHeight) + 1);
    }

    public bool IsBalanced(TreeNode root)
    {
        var (balanced, _) = dfs(root);
        return balanced;
    }
}
