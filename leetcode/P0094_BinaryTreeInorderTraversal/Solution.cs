namespace leetcode.P0094_BinaryTreeInorderTraversal
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

    public class Solution
    {
        public IList<int> InorderTraversal(TreeNode root)
        {
            var result = new LinkedList<int>();
            if (root == null)
            {
                return result.ToList();
            }

            var left = InorderTraversal(root.left);
            foreach (var item in left)
            {
                result.AddLast(item);
            }
            result.AddLast(root.val);
            var right = InorderTraversal(root.right);
            foreach (var item in right)
            {
                result.AddLast(item);
            }

            return result.ToList();
        }
    }
}
