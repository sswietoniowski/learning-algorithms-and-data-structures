namespace neetcode.P0417_PacificAtlanticWaterFlow;

// https://leetcode.com/problems/pacific-atlantic-water-flow/
// https://youtu.be/s-VkcjHqkGI
public class Solution
{
    public IList<IList<int>> PacificAtlantic(int[][] heights)
    {
        int rows = heights.Length;
        int columns = heights[0].Length;

        var pacific = new HashSet<(int, int)>();
        var atlantic = new HashSet<(int, int)>();

        void dfs(int row, int column, HashSet<(int, int)> visited, int previousHeight)
        {
            if (row < 0 || row >= rows || column < 0 || column >= columns 
                || visited.Contains((row, column)) 
                || heights[row][column] < previousHeight)
            {
                return;
            }

            visited.Add((row, column));

            dfs(row + 1, column, visited, heights[row][column]);
            dfs(row - 1, column, visited, heights[row][column]);
            dfs(row, column + 1, visited, heights[row][column]);
            dfs(row, column - 1, visited, heights[row][column]);
        }

        for (int i = 0; i < columns; i++)
        {
            dfs(0, i, pacific, heights[0][i]);
            dfs(rows - 1, i, atlantic, heights[rows - 1][i]);
        }

        for (int i = 0; i < rows; i++)
        {
            dfs(i, 0, pacific, heights[i][0]);
            dfs(i, columns - 1, atlantic, heights[i][columns - 1]);
        }

        var result = new List<IList<int>>();

        foreach (var item in pacific)
        {
            if (atlantic.Contains(item))
            {
                result.Add(new List<int> { item.Item1, item.Item2 });
            }
        }

        return result;
    }
}