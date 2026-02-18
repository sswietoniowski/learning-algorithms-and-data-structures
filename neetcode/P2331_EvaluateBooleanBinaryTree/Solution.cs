namespace neetcode.P2331_EvaluateBooleanBinaryTree;

// https://leetcode.com/problems/evaluate-boolean-binary-tree/description/
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
    public bool EvaluateTree(TreeNode root)
    {
        if (root.left == null && root.right == null)
        {
            return root.val == 1;
        }

        bool leftEval = EvaluateTree(root.left);
        bool rightEval = EvaluateTree(root.right);

        if (root.val == 2)
        {
            return leftEval || rightEval;
        }
        else
        {
            return leftEval && rightEval;
        }
    }
}
