namespace leetcode.P1382_BalanceABinarySearchTree;

// https://leetcode.com/problems/balance-a-binary-search-tree/?envType=daily-question&envId=2026-02-09
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
    private List<int> sortedValues = new List<int>();

    public TreeNode BalanceBST(TreeNode root)
    {
        InOrderTraversal(root);

        return BuildBalancedTree(0, sortedValues.Count - 1);
    }

    private void InOrderTraversal(TreeNode node)
    {
        if (node == null)
            return;

        InOrderTraversal(node.left);
        sortedValues.Add(node.val);
        InOrderTraversal(node.right);
    }

    private TreeNode BuildBalancedTree(int start, int end)
    {
        if (start > end)
            return null;

        int mid = (start + end) / 2;

        TreeNode newNode = new TreeNode(sortedValues[mid]);

        newNode.left = BuildBalancedTree(start, mid - 1);

        newNode.right = BuildBalancedTree(mid + 1, end);

        return newNode;
    }
}
