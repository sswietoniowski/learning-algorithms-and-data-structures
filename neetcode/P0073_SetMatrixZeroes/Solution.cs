namespace neetcode.P0073_SetMatrixZeroes;

// https://leetcode.com/problems/set-matrix-zeroes/
// https://youtu.be/T41rL0L3Pnw
public class Solution
{
    public void SetZeroes(int[][] matrix)
    {
        HashSet<int> zeroedRows = new();
        HashSet<int> zeroedColumns = new();

        int row = 0;
        int column = 0;
        int rowLength = matrix.Length;
        int columnLength = matrix[0].Length;

        while (row < rowLength && column < columnLength)
        {
            if (matrix[row][column] == 0)
            {
                zeroedRows.Add(row);
                zeroedColumns.Add(column);
            }

            column = (column + 1) % columnLength;
            row = column == 0 ? row + 1 : row;
        }

        row = 0;
        column = 0;
        while (row < rowLength && column < columnLength)
        {
            if (zeroedRows.Contains(row) || zeroedColumns.Contains(column))
            {
                matrix[row][column] = 0;
            }

            column = (column + 1) % columnLength;
            row = column == 0 ? row + 1 : row;
        }
    }
}