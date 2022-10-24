namespace neetcode.P0133_CloneGraph;

/*
// Definition for a Node.
public class Node {
public int val;
public IList<Node> neighbors;

public Node() {
    val = 0;
    neighbors = new List<Node>();
}

public Node(int _val) {
    val = _val;
    neighbors = new List<Node>();
}

public Node(int _val, List<Node> _neighbors) {
    val = _val;
    neighbors = _neighbors;
}
}
*/

public class Node
{
    public int val;
    public IList<Node> neighbors;

    public Node()
    {
        val = 0;
        neighbors = new List<Node>();
    }

    public Node(int _val)
    {
        val = _val;
        neighbors = new List<Node>();
    }

    public Node(int _val, List<Node> _neighbors)
    {
        val = _val;
        neighbors = _neighbors;
    }
}


// https://leetcode.com/problems/clone-graph/
// https://youtu.be/mQeF6bN8hMk
public class Solution
{
    public Node CloneGraph(Node node)
    {
        if (node == null)
        {
            return null;
        }

        var oldToNew = new Dictionary<Node, Node>();

        Node dfs(Node node)
        {
            if (oldToNew.ContainsKey(node))
            {
                return oldToNew[node];
            }

            var newNode = new Node(node.val);
            oldToNew[node] = newNode;

            foreach (var neighbor in node.neighbors)
            {
                newNode.neighbors.Add(dfs(neighbor));
            }

            return newNode;
        }

        return dfs(node);
    }
}