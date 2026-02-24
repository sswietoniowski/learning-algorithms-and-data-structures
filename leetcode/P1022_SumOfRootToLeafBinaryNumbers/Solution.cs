namespace leetcode.P1022_SumOfRootToLeafBinaryNumbers;

// https://leetcode.com/problems/sum-of-root-to-leaf-binary-numbers/description/?envType=daily-question&envId=2026-02-24
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
    public int SumRootToLeaf(TreeNode root)
    {
        int DFSPreorderTraversal(TreeNode node, int currentSum)
        {
            if (node is null)
            {
                return 0;
            }

            currentSum = (currentSum << 1) | node.val;

            if (node.left is null && node.right is null)
            {
                return currentSum;
            }

            return DFSPreorderTraversal(node.left, currentSum)
                + DFSPreorderTraversal(node.right, currentSum);
        }

        return DFSPreorderTraversal(root, 0);
    }
}
