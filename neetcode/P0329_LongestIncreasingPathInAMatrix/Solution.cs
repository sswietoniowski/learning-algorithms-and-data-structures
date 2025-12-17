namespace neetcode.P0329_LongestIncreasingPathInAMatrix;

// https://leetcode.com/problems/longest-increasing-path-in-a-matrix/description/
// https://neetcode.io/problems/longest-increasing-path-in-matrix/question?list=neetcode150
public class Solution
{
    public int LongestIncreasingPath(int[][] matrix)
    {
        int ROWS = matrix.Length,
            COLS = matrix[0].Length;
        int[][] indegree = new int[ROWS][];
        for (int i = 0; i < ROWS; i++)
        {
            indegree[i] = new int[COLS];
        }
        int[][] directions = new int[][]
        {
            new int[] { -1, 0 },
            new int[] { 1, 0 },
            new int[] { 0, -1 },
            new int[] { 0, 1 },
        };

        for (int r = 0; r < ROWS; r++)
        {
            for (int c = 0; c < COLS; c++)
            {
                foreach (var d in directions)
                {
                    int nr = r + d[0],
                        nc = c + d[1];
                    if (
                        nr >= 0
                        && nr < ROWS
                        && nc >= 0
                        && nc < COLS
                        && matrix[nr][nc] < matrix[r][c]
                    )
                    {
                        indegree[r][c]++;
                    }
                }
            }
        }

        Queue<int[]> q = new Queue<int[]>();
        for (int r = 0; r < ROWS; r++)
        {
            for (int c = 0; c < COLS; c++)
            {
                if (indegree[r][c] == 0)
                {
                    q.Enqueue(new int[] { r, c });
                }
            }
        }

        int LIS = 0;
        while (q.Count > 0)
        {
            int size = q.Count;
            for (int i = 0; i < size; i++)
            {
                int[] node = q.Dequeue();
                int r = node[0],
                    c = node[1];
                foreach (var d in directions)
                {
                    int nr = r + d[0],
                        nc = c + d[1];
                    if (
                        nr >= 0
                        && nr < ROWS
                        && nc >= 0
                        && nc < COLS
                        && matrix[nr][nc] > matrix[r][c]
                    )
                    {
                        if (--indegree[nr][nc] == 0)
                        {
                            q.Enqueue(new int[] { nr, nc });
                        }
                    }
                }
            }
            LIS++;
        }
        return LIS;
    }
}
