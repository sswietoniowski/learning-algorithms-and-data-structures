namespace leetcode.P1878_GetBiggestThreeRhombusSumsInAGrid;

// https://leetcode.com/problems/get-biggest-three-rhombus-sums-in-a-grid/description/?envType=daily-question&envId=2026-03-16
using System;
using System.Collections.Generic;
using System.Linq;

public class Solution
{
    public int[] GetBiggestThree(int[][] grid)
    {
        int m = grid.Length;
        int n = grid[0].Length;

        // Use a SortedSet to keep unique sums and automatically maintain order
        SortedSet<int> topSums = new SortedSet<int>();

        for (int r = 0; r < m; r++)
        {
            for (int c = 0; c < n; c++)
            {
                // Case 1: Radius 0 (just the single cell)
                UpdateTopThree(topSums, grid[r][c]);

                // Case 2: Radius k > 0
                for (int k = 1; ; k++)
                {
                    // Boundary check: all 4 corners must be within the grid
                    if (r - k < 0 || r + k >= m || c - k < 0 || c + k >= n)
                        break;

                    int currentSum = 0;

                    // Traverse the 4 sides of the rhombus
                    // We iterate k times for each of the 4 edges
                    for (int i = 0; i < k; i++)
                    {
                        currentSum += grid[r - k + i][c + i]; // Top to Right edge
                        currentSum += grid[r + i][c + k - i]; // Right to Bottom edge
                        currentSum += grid[r + k - i][c - i]; // Bottom to Left edge
                        currentSum += grid[r - i][c - k + i]; // Left to Top edge
                    }

                    UpdateTopThree(topSums, currentSum);
                }
            }
        }

        // Return the top 3 (or fewer) in descending order
        return topSums.Reverse().Take(3).ToArray();
    }

    private void UpdateTopThree(SortedSet<int> set, int sum)
    {
        set.Add(sum);
        // If we have more than 3, remove the smallest to keep the "Top 3"
        if (set.Count > 3)
        {
            set.Remove(set.Min);
        }
    }
}
