namespace neetcode.P0200_NumberOfIslands;

// https://leetcode.com/problems/number-of-islands/
// https://youtu.be/pV2kpPD66nE
public class Solution
{
    private void bfs(char[][] grid, int row, int column, HashSet<(int, int)> visited)
    {
        int rows = grid.Length;
        int columns = grid[0].Length;

        Queue<(int, int)> queue = new();
        visited.Add((row, column));
        queue.Enqueue((row, column));

        (int, int)[] directions = new (int, int)[]
        {
            (1, 0),
            (-1, 0),
            (0, 1),
            (0, -1)
        };

        while (queue.Count > 0)
        {
            (int r, int c) = queue.Dequeue();
            foreach ((int dr, int dc) in directions)
            {
                int rl = r + dr;
                int cl = c + dc;
                var location = (rl, cl);
                if (rl >= 0 && rl < rows
                            && cl >= 0 && cl < columns
                            && grid[rl][cl] == '1'
                            && !visited.Contains(location))
                {
                    queue.Enqueue(location);
                    visited.Add(location);
                }
            }
        }
    }

    public int NumIslands(char[][] grid)
    {
        if (grid.Length == 0)
        {
            return 0;
        }

        int rows = grid.Length;
        int columns = grid[0].Length;
        HashSet<(int, int)> visited = new();
        int islands = 0;

        for (int row = 0; row < rows; row++)
        {
            for (int column = 0; column < columns; column++)
            {
                if (grid[row][column] == '1' && !visited.Contains((row, column)))
                {
                    bfs(grid, row, column, visited);
                    islands += 1;
                }
            }
        }

        return islands;
    }
}