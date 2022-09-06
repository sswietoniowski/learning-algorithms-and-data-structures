namespace neetcode.P0036_ValidSudoku
{
    // https://leetcode.com/problems/valid-sudoku/
    // https://youtu.be/TjFXEUCMqI8
    public class Solution
    {
        public bool IsValidSudoku(char[][] board)
        {
            Dictionary<int, HashSet<char>> rows = new();
            Dictionary<int, HashSet<char>> columns = new();
            Dictionary<(int, int), HashSet<char>> squares = new();

            for (int r = 0; r < 9; r++)
            {
                for (int c = 0; c < 9; c++)
                {
                    char current = board[r][c];

                    if (current == '.')
                    {
                        continue;
                    }

                    if (!rows.ContainsKey(r))
                    {
                        rows.Add(r, new HashSet<char>());
                    }
                    else if (rows[r].Contains(current))
                    {
                        return false;
                    }

                    if (!columns.ContainsKey(c))
                    {
                        columns.Add(c, new HashSet<char>());
                    }
                    else if (columns[c].Contains(current))
                    {
                        return false;
                    }

                    (int r, int c) coordinates = (r / 3, c / 3);

                    if (!squares.ContainsKey(coordinates))
                    {
                        squares[coordinates] = new HashSet<char>();
                    }
                    else if (squares[coordinates].Contains(current))
                    {
                        return false;
                    }

                    rows[r].Add(current);
                    columns[c].Add(current);
                    squares[coordinates].Add(current);
                }
            }

            return true;
        }
    }
}
