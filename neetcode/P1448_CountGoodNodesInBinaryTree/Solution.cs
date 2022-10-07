namespace neetcode.P1448_CountGoodNodesInBinaryTree;

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

// https://leetcode.com/problems/count-good-nodes-in-binary-tree/
// https://youtu.be/7cp5imvDzl4
public class Solution
{
    public int GoodNodes(TreeNode root)
    {
        return dfs(root, root.val);
    }

    private int dfs(TreeNode node, int max)
    {
        if (node == null)
        {
            return 0;
        }

        var good = node.val >= max ? 1 : 0;
        max = Math.Max(max, node.val);
        return good + dfs(node.left, max) + dfs(node.right, max);
    }
}