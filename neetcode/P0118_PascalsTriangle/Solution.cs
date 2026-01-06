namespace neetcode.P0118_PascalsTriangle;

// https://leetcode.com/problems/pascals-triangle/description/
// https://neetcode.io/problems/pascals-triangle/question
public class Solution
{
    public IList<IList<int>> Generate(int numRows)
    {
        List<IList<int>> result = new List<IList<int>>(numRows);

        for (int i = 0; i < numRows; i++)
        {
            List<int> row = new List<int>(i + 1);

            for (int j = 0; j <= i; j++)
            {
                if (j == 0 || j == i)
                {
                    row.Add(1);
                }
                else
                {
                    var prevRow = result[i - 1];
                    row.Add(prevRow[j - 1] + prevRow[j]);
                }
            }
            result.Add(row);
        }

        return result;
    }
}
