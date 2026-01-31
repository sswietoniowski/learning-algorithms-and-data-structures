namespace neetcode.P2965_FindMissingAndRepeatedValues;

// https://leetcode.com/problems/find-missing-and-repeated-values/description/
// https://neetcode.io/problems/find-missing-and-repeated-values/question?list=allNC
// v1
/*
public class Solution
{
    public int[] FindMissingAndRepeatedValues(int[][] grid)
    {
        (int r, int c) GetCoordinates(int i)
        {
            int n = grid.Length;

            return (r: (i - 1) / n, c: (i - 1) % n);
        }

        int n = grid.Length;
        int a = -1;
        int b = -1;
        for (int i = 1; i <= n * n; i++)
        {
            var (r1, c1) = GetCoordinates(i);
            var index = Math.Abs(grid[r1][c1]);
            var (r2, c2) = GetCoordinates(index);

            if (grid[r2][c2] >= 0)
            {
                grid[r2][c2] = -grid[r2][c2];
            }
            else
            {
                a = index;
            }
        }

        for (int i = 1; i <= n * n; i++)
        {
            var (r, c) = GetCoordinates(i);

            if (grid[r][c] > 0)
            {
                b = i;
            }
        }

        int[] result = new int[2];
        result[0] = a;
        result[1] = b;

        return result;
    }
}
*/
// v2
public class Solution
{
    public int[] FindMissingAndRepeatedValues(int[][] grid)
    {
        int n = grid.Length;
        int totalNumbers = n * n;

        int[] counts = new int[totalNumbers + 1];

        foreach (var row in grid)
        {
            foreach (var num in row)
            {
                counts[num]++;
            }
        }

        int repeated = -1;
        int missing = -1;

        for (int i = 1; i <= totalNumbers; i++)
        {
            if (counts[i] == 2)
            {
                repeated = i;
            }
            else if (counts[i] == 0)
            {
                missing = i;
            }
        }

        return new[] { repeated, missing };
    }
}
