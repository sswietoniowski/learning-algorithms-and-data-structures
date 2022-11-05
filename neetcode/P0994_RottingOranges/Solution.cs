namespace neetcode.P0994_RottingOranges
{
    // https://leetcode.com/problems/rotting-oranges/
    // https://youtu.be/y704fEOx0s0
    public class Solution
    {
        public int OrangesRotting(int[][] grid)
        {
            var queue = new Queue<(int, int)>();
            var fresh = 0;
            for (var i = 0; i < grid.Length; i++)
            {
                for (var j = 0; j < grid[i].Length; j++)
                {
                    if (grid[i][j] == 2)
                    {
                        queue.Enqueue((i, j));
                    }
                    else if (grid[i][j] == 1)
                    {
                        fresh++;
                    }
                }
            }

            var minutes = 0;
            while (queue.Count > 0)
            {
                var size = queue.Count;
                for (var i = 0; i < size; i++)
                {
                    var (x, y) = queue.Dequeue();
                    if (x > 0 && grid[x - 1][y] == 1)
                    {
                        grid[x - 1][y] = 2;
                        fresh--;
                        queue.Enqueue((x - 1, y));
                    }
                    if (x < grid.Length - 1 && grid[x + 1][y] == 1)
                    {
                        grid[x + 1][y] = 2;
                        fresh--;
                        queue.Enqueue((x + 1, y));
                    }
                    if (y > 0 && grid[x][y - 1] == 1)
                    {
                        grid[x][y - 1] = 2;
                        fresh--;
                        queue.Enqueue((x, y - 1));
                    }
                    if (y < grid[x].Length - 1 && grid[x][y + 1] == 1)
                    {
                        grid[x][y + 1] = 2;
                        fresh--;
                        queue.Enqueue((x, y + 1));
                    }
                }
                minutes++;
            }

            return fresh == 0 ? Math.Max(0, minutes - 1) : -1;
        }
    }
}
