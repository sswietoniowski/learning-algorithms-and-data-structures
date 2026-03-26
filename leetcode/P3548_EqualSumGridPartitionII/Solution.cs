// https://leetcode.com/problems/equal-sum-grid-partition-ii/description/?envType=daily-question&envId=2026-03-26
using System;
using System.Collections.Generic;
using System.Linq;

namespace leetcode.P3548_EqualSumGridPartitionII;

public class Solution
{
    public bool CanPartitionGrid(int[][] grid)
    {
        int m = grid.Length;
        int n = grid[0].Length;

        // 1. Check Horizontal Cuts
        if (CheckCuts(grid, m, n, true))
            return true;

        // 2. Check Vertical Cuts (by treating columns as rows)
        // To avoid rewriting logic, we can pass a flag or transpose mentally
        if (CheckCuts(grid, m, n, false))
            return true;

        return false;
    }

    private bool CheckCuts(int[][] grid, int m, int n, bool horizontal)
    {
        int rows = horizontal ? m : n;
        int cols = horizontal ? n : m;

        long[] rowSums = new long[rows];
        Dictionary<int, int> topFreq = new Dictionary<int, int>();
        Dictionary<int, int> bottomFreq = new Dictionary<int, int>();

        long totalSum = 0;
        for (int i = 0; i < rows; i++)
        {
            for (int j = 0; j < cols; j++)
            {
                int val = horizontal ? grid[i][j] : grid[j][i];
                rowSums[i] += val;
                bottomFreq[val] = bottomFreq.GetValueOrDefault(val) + 1;
            }
            totalSum += rowSums[i];
        }

        long currentTopSum = 0;
        // i is the last row of the 'Top' section.
        // We can cut after row 0 up to row rows-2.
        for (int i = 0; i < rows - 1; i++)
        {
            currentTopSum += rowSums[i];
            long currentBottomSum = totalSum - currentTopSum;

            // Move current row from bottom frequency map to top frequency map
            for (int j = 0; j < cols; j++)
            {
                int val = horizontal ? grid[i][j] : grid[j][i];
                bottomFreq[val]--;
                if (bottomFreq[val] == 0)
                    bottomFreq.Remove(val);
                topFreq[val] = topFreq.GetValueOrDefault(val) + 1;
            }

            // Case A: Sums are already equal
            if (currentTopSum == currentBottomSum)
                return true;

            // Case B: Discount from Top
            // Requirement: currentTopSum - cell = currentBottomSum => cell = top - bottom
            long diffTop = currentTopSum - currentBottomSum;
            if (diffTop > 0 && diffTop <= int.MaxValue)
            {
                if (CanDiscount(grid, (int)diffTop, i + 1, cols, topFreq, true, i, horizontal))
                    return true;
            }

            // Case C: Discount from Bottom
            // Requirement: currentBottomSum - cell = currentTopSum => cell = bottom - top
            long diffBottom = currentBottomSum - currentTopSum;
            if (diffBottom > 0 && diffBottom <= int.MaxValue)
            {
                if (
                    CanDiscount(
                        grid,
                        (int)diffBottom,
                        rows - (i + 1),
                        cols,
                        bottomFreq,
                        false,
                        i,
                        horizontal
                    )
                )
                    return true;
            }
        }

        return false;
    }

    private bool CanDiscount(
        int[][] grid,
        int target,
        int sectionHeight,
        int sectionWidth,
        Dictionary<int, int> freq,
        bool isTop,
        int cutIdx,
        bool horizontal
    )
    {
        if (!freq.ContainsKey(target))
            return false;

        // If the section is 2D (height > 1 AND width > 1), any cell can be removed.
        if (sectionHeight > 1 && sectionWidth > 1)
            return true;

        // If it's a 1D section, we can only remove the ends.
        // If height is 1, section is [1 x Width]. Ends are (0) and (Width-1).
        if (sectionHeight == 1)
        {
            int r = isTop ? cutIdx : cutIdx + 1; // The single row index
            int valStart = horizontal ? grid[r][0] : grid[0][r];
            int valEnd = horizontal ? grid[r][sectionWidth - 1] : grid[sectionWidth - 1][r];
            if (valStart == target || valEnd == target)
                return true;
        }
        // If width is 1, section is [Height x 1]. Ends are row 0 and row Height-1 of that section.
        else if (sectionWidth == 1)
        {
            int startR = isTop ? 0 : cutIdx + 1;
            int endR = isTop ? cutIdx : grid.Length - 1; // This part needs careful indexing based on 'horizontal'

            // Simplified: in a 1xHeight vertical strip, any cell is an "end" if it's the top or bottom-most cell.
            // But if width is 1, the ONLY way it stays connected is if we pick the very first or very last cell of the strip.
            int valStart = horizontal
                ? grid[isTop ? 0 : cutIdx + 1][0]
                : grid[0][isTop ? 0 : cutIdx + 1];
            int valEnd = horizontal
                ? grid[isTop ? cutIdx : grid.Length - 1][0]
                : grid[0][isTop ? cutIdx : grid[0].Length - 1];

            if (valStart == target || valEnd == target)
                return true;
        }

        return false;
    }
}
