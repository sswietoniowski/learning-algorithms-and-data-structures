namespace neetcode.P0199_BinaryTreeRightSideView;

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

// https://leetcode.com/problems/binary-tree-right-side-view/
// https://youtu.be/d4zLyf32e3I
public class Solution
{
    public IList<int> RightSideView(TreeNode root)
    {
        var node = root;

        var result = new List<int>();

        if (node is null)
        {
            return result;
        }

        var queue = new Queue<TreeNode>();

        queue.Enqueue(node);

        while (queue.Count > 0)
        {
            var size = queue.Count;

            for (var i = 0; i < size; i++)
            {
                node = queue.Dequeue();

                if (i == size - 1)
                {
                    result.Add(node.val);
                }

                if (node.left is not null)
                {
                    queue.Enqueue(node.left);
                }

                if (node.right is not null)
                {
                    queue.Enqueue(node.right);
                }
            }
        }

        return result;
    }
}