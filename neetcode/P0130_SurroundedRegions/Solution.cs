namespace neetcode.P0130_SurroundedRegions;

// https://leetcode.com/problems/surrounded-regions/
// https://youtu.be/9z2BunfoZ5Y
public class Solution
{
    private void DFS(char[][] board, int i, int j)
    {
        if (i < 0 || i >= board.Length || j < 0 || j >= board[0].Length 
            || board[i][j] != 'O')
        {
            return;
        }

        board[i][j] = 'A';

        DFS(board, i + 1, j);
        DFS(board, i - 1, j);
        DFS(board, i, j + 1);
        DFS(board, i, j - 1);
    }

    public void Solve(char[][] board)
    {
        var rows = board.Length;
        if (rows == 0) return;
        var cols = board[0].Length;

        for (var i = 0; i < rows; i++)
        {
            if (board[i][0] == 'O') DFS(board, i, 0);
            if (board[i][cols - 1] == 'O') DFS(board, i, cols - 1);
        }

        for (var j = 0; j < cols; j++)
        {
            if (board[0][j] == 'O') DFS(board, 0, j);
            if (board[rows - 1][j] == 'O') DFS(board, rows - 1, j);
        }

        for (var i = 0; i < rows; i++)
        {
            for (var j = 0; j < cols; j++)
            {
                if (board[i][j] == 'O') board[i][j] = 'X';
                if (board[i][j] == 'A') board[i][j] = 'O';
            }
        }
    }
}