namespace leetcode.P3643_FlipSquareSubmatrixVertically;

// https://leetcode.com/problems/flip-square-submatrix-vertically/description/?envType=daily-question&envId=2026-03-21
public class Solution
{
    public int[][] ReverseSubmatrix(int[][] grid, int x, int y, int k)
    {
        // top starts at the first row of the submatrix
        // bottom starts at the last row of the submatrix
        int top = x;
        int bottom = x + k - 1;

        // We only need to swap until the pointers meet in the middle
        while (top < bottom)
        {
            // Iterate through each column within the submatrix width k
            for (int j = y; j < y + k; j++)
            {
                // Swap elements at (top, j) and (bottom, j)
                int temp = grid[top][j];
                grid[top][j] = grid[bottom][j];
                grid[bottom][j] = temp;
            }

            // Move pointers inward
            top++;
            bottom--;
        }

        return grid;
    }
}
