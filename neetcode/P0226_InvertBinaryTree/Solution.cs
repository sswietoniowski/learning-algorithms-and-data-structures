namespace neetcode.P0226_InvertBinaryTree;

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

    // https://leetcode.com/problems/invert-binary-tree/
    // https://youtu.be/OnSn2XEQ4MY
    public TreeNode InvertTree(TreeNode root)
    {
        // v1
        //if (root == null)
        //{
        //    return null;
        //}
        //else
        //{
        //    var left = InvertTree(root.right);
        //    var right = InvertTree(root.left);
        //    root.left = left;
        //    root.right = right;
        //}
        //return root;

        // v2
        if (root == null)
        {
            return null;
        }
        Queue<TreeNode> queue = new();
        queue.Enqueue(root);
        while (queue.Count > 0)
        {
            var current = queue.Dequeue();
            var tmp = current.left;
            current.left = current.right;
            current.right = tmp;
            if (current.left != null)
            {
                queue.Enqueue(current.left);
            }
            if (current.right != null)
            {
                queue.Enqueue(current.right);
            }
        }
        return root;
    }
}
