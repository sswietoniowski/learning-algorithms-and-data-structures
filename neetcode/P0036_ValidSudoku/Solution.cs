using System.Xml.Schema;

namespace neetcode.P0036_ValidSudoku
{
    // https://leetcode.com/problems/valid-sudoku/
    // https://youtu.be/TjFXEUCMqI8
    public class Solution
    {
        public bool IsValidSudoku(char[][] board)
        {
            for (int i = 0; i < 9; i++)
            {
                HashSet<char> digitsRow = new();
                HashSet<char> digitsColumn = new();

                for (int j = 0; j < 9; j++)
                {
                    char currentRow = board[i][j];
                    char currentColumn = board[j][i];

                    if (currentRow != '.')
                    {
                        if (digitsRow.Contains(currentRow))
                        {
                            return false;
                        }

                        digitsRow.Add(currentRow);
                    }

                    if (currentColumn != '.')
                    {
                        if (digitsColumn.Contains(currentColumn))
                        {
                            return false;
                        }

                        digitsColumn.Add(currentColumn);
                    }
                }
            }

            for (int i = 0; i < 3; i++)
            {
                for (int j = 0; j < 3; j++)
                {
                    HashSet<char> digitsGroup = new();
                    
                    for (int k = 0; k < 3; k++)
                    {
                        for (int m = 0; m < 3; m++)
                        {
                            char current = board[(i * 3) + k][(j * 3) + m];

                            if (current == '.')
                            {
                                continue;
                            }

                            if (digitsGroup.Contains(current))
                            {
                                return false;
                            }

                            digitsGroup.Add(current);
                        }
                    }
                }
            }

            return true;
        }
    }
}
