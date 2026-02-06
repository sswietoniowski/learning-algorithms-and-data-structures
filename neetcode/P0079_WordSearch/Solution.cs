namespace neetcode.P0079_WordSearch;

// https://leetcode.com/problems/word-search/
// https://youtu.be/pfiQ_PS1g8E
public class Solution
{
    public bool Exist(char[][] board, string word)
    {
        var rows = board.Length;
        var columns = board[0].Length;
        var path = new HashSet<(int, int)>();

        bool Backtrack(int row, int column, int index)
        {
            if (index == word.Length)
            {
                return true;
            }

            if (
                row < 0
                || row >= rows
                || column < 0
                || column >= columns
                || word[index] != board[row][column]
                || path.Contains((row, column))
            )
            {
                return false;
            }

            path.Add((row, column));
            var result =
                Backtrack(row + 1, column, index + 1)
                || Backtrack(row - 1, column, index + 1)
                || Backtrack(row, column + 1, index + 1)
                || Backtrack(row, column - 1, index + 1);
            path.Remove((row, column));

            return result;
        }

        for (var row = 0; row < rows; row++)
        {
            for (var column = 0; column < columns; column++)
            {
                if (Backtrack(row, column, 0))
                {
                    return true;
                }
            }
        }

        return false;
    }
}
