namespace neetcode.P0450_DeleteNodeInABST;

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

// https://leetcode.com/problems/delete-node-in-a-bst/description/
// https://neetcode.io/problems/delete-node-in-a-bst/question?list=neetcode250
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
    public TreeNode DeleteNode(TreeNode root, int key)
    {
        if (root == null)
            return null;

        // Step 1: Search for the node
        if (key < root.val)
        {
            root.left = DeleteNode(root.left, key);
        }
        else if (key > root.val)
        {
            root.right = DeleteNode(root.right, key);
        }
        else
        {
            // Step 2: Found the node! Handle the three scenarios:

            // Case 1 & 2: Node has 0 or 1 child
            if (root.left == null)
            {
                return root.right; // If left is null, return right (covers leaf if right is also null)
            }
            else if (root.right == null)
            {
                return root.left; // If right is null, return left
            }

            // Case 3: Node has 2 children
            // Find the In-order Successor (smallest value in the right subtree)
            TreeNode successor = FindMin(root.right);

            // Replace current node's value with the successor's value
            root.val = successor.val;

            // Delete the successor node from the right subtree
            root.right = DeleteNode(root.right, successor.val);
        }

        return root;
    }

    private TreeNode FindMin(TreeNode node)
    {
        while (node.left != null)
        {
            node = node.left;
        }
        return node;
    }
}
