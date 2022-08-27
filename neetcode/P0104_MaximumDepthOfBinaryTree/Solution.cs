namespace neetcode.P0104_MaximumDepthOfBinaryTree
{
    public class Solution
    {
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

        // https://leetcode.com/problems/maximum-depth-of-binary-tree/
        // https://youtu.be/hTM3phVI6YQ
        public int MaxDepth(TreeNode root)
        {
            if (root == null)
            {
                return 0;
            }

            int leftDepth = 1 + MaxDepth(root.left);
            int rightDepth = 1 + MaxDepth(root.right);
            if (leftDepth >= rightDepth)
            {
                return leftDepth;
            }
            else
            {
                return rightDepth;
            }
        }
    }
}
