namespace leetcode.P0589_NaryTreePreorderTraversal;

// https://leetcode.com/problems/n-ary-tree-preorder-traversal/description/
public class Node
{
    public int val;
    public IList<Node> children;

    public Node() { }

    public Node(int _val)
    {
        val = _val;
    }

    public Node(int _val, IList<Node> _children)
    {
        val = _val;
        children = _children;
    }
}

/*
// Definition for a Node.
public class Node {
    public int val;
    public IList<Node> children;

    public Node() {}

    public Node(int _val) {
        val = _val;
    }

    public Node(int _val,IList<Node> _children) {
        val = _val;
        children = _children;
    }
}
*/
public class Solution
{
    public IList<int> Preorder(Node root)
    {
        List<int> result = new();

        if (root is null)
        {
            return result;
        }

        Stack<Node> stack = new();

        stack.Push(root);
        while (stack.Count > 0)
        {
            Node current = stack.Pop();
            result.Add(current.val);

            if (current.children is null || current.children.Count == 0)
            {
                continue;
            }

            for (int i = current.children.Count - 1; i >= 0; i--)
            {
                if (current.children[i] is not null)
                {
                    stack.Push(current.children[i]);
                }
            }
        }

        return result;
    }
}
