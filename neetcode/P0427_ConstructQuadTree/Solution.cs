namespace neetcode.P0427_ConstructQuadTree;

// https://leetcode.com/problems/construct-quad-tree/description/
// Definition for a QuadTree node.
public class Node
{
    public bool val;
    public bool isLeaf;
    public Node topLeft;
    public Node topRight;
    public Node bottomLeft;
    public Node bottomRight;

    public Node()
    {
        val = false;
        isLeaf = false;
        topLeft = null;
        topRight = null;
        bottomLeft = null;
        bottomRight = null;
    }

    public Node(bool _val, bool _isLeaf)
    {
        val = _val;
        isLeaf = _isLeaf;
        topLeft = null;
        topRight = null;
        bottomLeft = null;
        bottomRight = null;
    }

    public Node(
        bool _val,
        bool _isLeaf,
        Node _topLeft,
        Node _topRight,
        Node _bottomLeft,
        Node _bottomRight
    )
    {
        val = _val;
        isLeaf = _isLeaf;
        topLeft = _topLeft;
        topRight = _topRight;
        bottomLeft = _bottomLeft;
        bottomRight = _bottomRight;
    }
}

public class Solution
{
    public Node Construct(int[][] grid)
    {
        return Dfs(grid, grid.Length, 0, 0);
    }

    private Node Dfs(int[][] grid, int n, int r, int c)
    {
        bool allSame = true;
        for (int i = 0; i < n && allSame; i++)
        {
            for (int j = 0; j < n && allSame; j++)
            {
                if (grid[r][c] != grid[r + i][c + j])
                {
                    allSame = false;
                }
            }
        }

        if (allSame)
        {
            return new Node(grid[r][c] == 1, true);
        }

        int half = n / 2;
        Node topLeft = Dfs(grid, half, r, c);
        Node topRight = Dfs(grid, half, r, c + half);
        Node bottomLeft = Dfs(grid, half, r + half, c);
        Node bottomRight = Dfs(grid, half, r + half, c + half);

        return new Node(false, false, topLeft, topRight, bottomLeft, bottomRight);
    }
}
