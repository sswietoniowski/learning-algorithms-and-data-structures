namespace leetcode.P1563_StoneGameV;

// https://leetcode.com/problems/stone-game-v/description/?envType=daily-question&envId=2026-08-17
public class Solution
{
    private int[,] memo;
    private int[] prefix;

    public int StoneGameV(int[] stoneValue)
    {
        int n = stoneValue.Length;

        // memo[i, j] stores the max score for subarray stoneValue[i...j]
        memo = new int[n, n];
        prefix = new int[n + 1];

        // Calculate prefix sums for O(1) range sum queries
        for (int i = 0; i < n; i++)
        {
            prefix[i + 1] = prefix[i] + stoneValue[i];
        }

        return DFS(0, n - 1);
    }

    private int DFS(int i, int j)
    {
        // Base case: only one stone left, game ends, score is 0
        if (i == j)
        {
            return 0;
        }

        // Return already computed result
        if (memo[i, j] > 0)
        {
            return memo[i, j];
        }

        int maxScore = 0;

        // Try all possible splits for the current segment [i...j]
        for (int k = i; k < j; k++)
        {
            int leftSum = prefix[k + 1] - prefix[i];
            int rightSum = prefix[j + 1] - prefix[k + 1];

            if (leftSum < rightSum)
            {
                // Bob throws away the right row
                maxScore = Math.Max(maxScore, leftSum + DFS(i, k));
            }
            else if (leftSum > rightSum)
            {
                // Bob throws away the left row
                maxScore = Math.Max(maxScore, rightSum + DFS(k + 1, j));
            }
            else
            {
                // Sums are equal, Alice gets to choose the most optimal row to throw away
                maxScore = Math.Max(maxScore, leftSum + Math.Max(DFS(i, k), DFS(k + 1, j)));
            }
        }

        memo[i, j] = maxScore;
        return maxScore;
    }
}
