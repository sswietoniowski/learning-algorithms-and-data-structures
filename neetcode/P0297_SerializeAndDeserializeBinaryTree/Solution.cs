namespace neetcode.P0297_SerializeAndDeserializeBinaryTree;

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

// https://leetcode.com/problems/serialize-and-deserialize-binary-tree/description/
// https://neetcode.io/problems/serialize-and-deserialize-binary-tree/question?list=neetcode150
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

public class Codec
{
    // Encodes a tree to a single string.
    public string serialize(TreeNode root)
    {
        List<string> res = new List<string>();
        dfsSerialize(root, res);
        return String.Join(",", res);
    }

    private void dfsSerialize(TreeNode node, List<string> res)
    {
        if (node == null)
        {
            res.Add("N");
            return;
        }
        res.Add(node.val.ToString());
        dfsSerialize(node.left, res);
        dfsSerialize(node.right, res);
    }

    // Decodes your encoded data to tree.
    public TreeNode deserialize(string data)
    {
        string[] vals = data.Split(',');
        int i = 0;
        return dfsDeserialize(vals, ref i);
    }

    private TreeNode dfsDeserialize(string[] vals, ref int i)
    {
        if (vals[i] == "N")
        {
            i++;
            return null;
        }
        TreeNode node = new TreeNode(Int32.Parse(vals[i]));
        i++;
        node.left = dfsDeserialize(vals, ref i);
        node.right = dfsDeserialize(vals, ref i);
        return node;
    }
}
