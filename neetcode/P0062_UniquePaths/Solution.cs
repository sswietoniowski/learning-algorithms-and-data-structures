namespace neetcode.P0062_UniquePaths
{
    // https://leetcode.com/problems/unique-paths/
    // https://youtu.be/IlEsdxuD4lY
    public class Solution
    {
        public int UniquePaths(int m, int n)
        {
            int[] row = Enumerable.Repeat(1, n).ToArray();
            for (int i = 0; i < m - 1; i++)
            {
                int[] newRow = Enumerable.Repeat(1, n).ToArray();
                for (int j = n - 2; j >= 0; j--)
                {
                    newRow[j] = newRow[j + 1] + row[j];
                }

                row = newRow;
            }

            return row[0];
        }
    }
}
