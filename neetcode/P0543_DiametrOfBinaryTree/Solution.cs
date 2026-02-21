namespace neetcode.P0543_DiametrOfBinaryTree;

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

// https://leetcode.com/problems/diameter-of-binary-tree/
// https://youtu.be/bkxqA8Rfv04
public class Solution
{
    private int HeightOfBinaryTree(TreeNode root)
    {
        if (root == null)
        {
            return 0;
        }

        return 1 + Math.Max(HeightOfBinaryTree(root.left), HeightOfBinaryTree(root.right));
    }

    public int DiameterOfBinaryTree(TreeNode root)
    {
        if (root == null)
        {
            return 0;
        }

        var leftHeight = HeightOfBinaryTree(root.left);
        var rightHeight = HeightOfBinaryTree(root.right);

        var leftDiameter = DiameterOfBinaryTree(root.left);
        var rightDiameter = DiameterOfBinaryTree(root.right);

        return Math.Max(Math.Max(leftDiameter, rightDiameter), leftHeight + rightHeight);
    }
}
