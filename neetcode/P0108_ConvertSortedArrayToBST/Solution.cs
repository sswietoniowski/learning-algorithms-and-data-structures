namespace neetcode.P0108_ConvertSortedArrayToBST;

// https://leetcode.com/problems/convert-sorted-array-to-binary-search-tree/
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
    public TreeNode SortedArrayToBST(int[] nums)
    {
        return BuildTree(nums, 0, nums.Length - 1);
    }

    private TreeNode BuildTree(int[] nums, int left, int right)
    {
        if (left > right)
        {
            return null;
        }

        int middle = left + (right - left) / 2;

        var node = new TreeNode(nums[middle]);
        node.left = BuildTree(nums, left, middle - 1);
        node.right = BuildTree(nums, middle + 1, right);

        return node;
    }
}
