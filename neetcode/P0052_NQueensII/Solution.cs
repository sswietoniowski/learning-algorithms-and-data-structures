namespace neetcode.P0052_NQueensII;

// https://leetcode.com/problems/n-queens-ii/description/
// https://neetcode.io/problems/n-queens-ii/question?list=neetcode250
public class Solution
{
    private int count = 0;
    private bool[] cols;
    private bool[] diag1; // (row + col)
    private bool[] diag2; // (row - col)

    public int TotalNQueens(int n)
    {
        count = 0;
        cols = new bool[n];
        // There are 2n - 1 diagonals in an n x n board
        diag1 = new bool[2 * n];
        diag2 = new bool[2 * n];

        Backtrack(0, n);
        return count;
    }

    private void Backtrack(int row, int n)
    {
        // Base Case: If we've placed queens in all rows, we found a solution
        if (row == n)
        {
            count++;
            return;
        }

        for (int col = 0; col < n; col++)
        {
            // Calculate diagonal IDs
            // For diag2, we add (n - 1) to ensure the index is never negative
            int d1 = row + col;
            int d2 = row - col + (n - 1);

            // If the column or either diagonal is under attack, skip this spot
            if (cols[col] || diag1[d1] || diag2[d2])
            {
                continue;
            }

            // 1. "Choose" - Place the queen and mark the paths as attacked
            cols[col] = true;
            diag1[d1] = true;
            diag2[d2] = true;

            // 2. "Explore" - Move to the next row
            Backtrack(row + 1, n);

            // 3. "Un-choose" (Backtrack) - Remove the queen to try the next column
            cols[col] = false;
            diag1[d1] = false;
            diag2[d2] = false;
        }
    }
}
